using Souccar.SaleManagement.Settings.Materials.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Events.Bus;
using Souccar.SaleManagement.StockHistories.Event;
using Souccar.SaleManagement.Stocks;
using Souccar.SaleManagement.Stocks.Services;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Offers.Services;
using Abp.UI;
using System;
using Souccar.SaleManagement.SupplierOffers.Services;


namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public class MaterialAppService :
        AsyncSouccarAppService<Material, MaterialDto, int, FullPagedRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialDomainService _materialDomainService;
        private readonly IStockDomainService _stockDomainService;
        private readonly IOfferDomainService _offerDomainService;
        private readonly ISupplierOfferDomainService _supplierOfferDomainService;
        public MaterialAppService(
            IMaterialDomainService materialDomainService, 
            IStockDomainService stockDomainService, 
            IOfferDomainService offerDomainService, 
            ISupplierOfferDomainService supplierOfferDomainService) 
            : base(materialDomainService)
        {
            _materialDomainService = materialDomainService;
            _stockDomainService = stockDomainService;
            _offerDomainService = offerDomainService;
            _supplierOfferDomainService = supplierOfferDomainService;
        }

        public IList<DropdownDto> GetForDropdown()
        {
            var entities = _materialDomainService.GetAll();
            if (entities.Any())
                return ObjectMapper.Map<List<DropdownDto>>(entities.ToList());

            return new List<DropdownDto>();
        }

        public override Task<UpdateMaterialDto> GetForEditAsync(EntityDto<int> input)
        {
            return base.GetForEditAsync(input);
        }
        public async override Task<MaterialDto> CreateAsync(CreateMaterialDto input)
        {
            var output = await base.CreateAsync(input);
            var material = _materialDomainService
                .Get(filter: x => x.Id == output.Id, include: new string[] { "Unit", "Stocks.Size" })
                .FirstOrDefault();
                
            foreach (var stock in material.Stocks)
            {
                await EventBus.Default.TriggerAsync(new StockHistoryEventUpdateData(
                    type: StockType.Entry,
                    reason: StockReason.InitialBalance,
                    title: L(LocalizationResource.InitialBalanceForMaterial, output.Name,stock.Size?.Name),
                    quantity: stock.Quantity,
                    relatedId: stock.Id,
                    unitId: material.UnitId,
                    sizeId: stock.SizeId,
                    materialId: output.Id,
                    price:stock.Price
                    ));
            }
            return output;
        }
        public async override Task<MaterialDto> UpdateAsync(UpdateMaterialDto input)
        {
            var material = await _materialDomainService.GetAsync(input.Id);
            var stocks = _stockDomainService.GetAll().Where(x => x.MaterialId == input.Id).ToList();
            ObjectMapper.Map<UpdateMaterialDto, Material>(input, material);
            var updatedMaterial = await _materialDomainService.UpdateAsync(material);

            //Stock
            var createdList = input.Stocks.Where(x=>x.Id == 0);
            var deletedList = stocks.ExceptBy(input.Stocks.Select(a => a.Id), e => e.Id);
            if (CheckStocksUsedInOffer(deletedList.Select(x=>x.Id)))
            {
                throw new UserFriendlyException(L("CanNotDeleteStockDueToRelatedOffer"));
            }
            foreach (var item in createdList)
            {
                var stock = ObjectMapper.Map<Stock>(item);
                await _stockDomainService.InsertAsync(stock);
            }
            foreach (var item in deletedList)
            {
                await _stockDomainService.DeleteAsync(item.Id);
            }
            var updatedList = stocks.Where(x 
                => !createdList.Any(y => y.Id == x.Id) 
                && !deletedList.Any(y => y.Id == x.Id));

            foreach (var item in updatedList)
            {
                var inputStock = input.Stocks.First(x => x.Id == item.Id);
                ObjectMapper.Map(inputStock, item);
                await _stockDomainService.UpdateAsync(item);
            }
            var materials = _materialDomainService
            .Get(filter: x => x.Id == updatedMaterial.Id, include: new string[] { "Unit", "Stocks.Size" })
            .FirstOrDefault();

            foreach (var stock in materials.Stocks)
            {
                await EventBus.Default.TriggerAsync(new StockHistoryEventUpdateData(
                    type: StockType.Entry,
                    reason: StockReason.InitialBalance,
                    title: L(LocalizationResource.InitialBalanceForMaterial, updatedMaterial.Name, stock.Size?.Name),
                    quantity: stock.Quantity,
                    relatedId: stock.Id,
                    unitId: material.UnitId,
                    sizeId: stock.SizeId,
                    materialId: updatedMaterial.Id,
                    price:stock.Price
                    ));
            }

            foreach (var stock in deletedList)
            {
                await EventBus.Default.TriggerAsync(new StockHistoryEventDeleteData(
                    type: StockType.Entry,
                    reason: StockReason.InitialBalance,
                    relatedId: stock.Id
                    ));
            }

            return ObjectMapper.Map<MaterialDto>(updatedMaterial);
        }

        private bool CheckStocksUsedInOffer(IEnumerable<int> stocksIds)
        {
            var isUsed = _offerDomainService.Get(x => x.OfferItems.Any(o => o.Material.Stocks.Any(s => stocksIds.Contains(s.Id)))).Any();
            if (isUsed)
                return isUsed;

            return _supplierOfferDomainService.Get(x => x.SupplierOfferItems.Any(o => o.Material.Stocks.Any(s => stocksIds.Contains(s.Id)))).Any();
        }

        private bool CheckMaterialUsedInOffer(int materialId)
        {
            var isUsed = _offerDomainService.Get(x => x.OfferItems.Any(o => o.Material.Id == materialId)).Any();
            if (isUsed)
                return isUsed;

            return _supplierOfferDomainService.Get(x => x.SupplierOfferItems.Any(o => o.Material.Id == materialId)).Any();
        }

        public IList<MaterialDto> GetAllByIds(int[] materialsIds)
        {
            var includes = new string[] 
            { 
                $"{nameof(Material.Unit)}",
                $"{nameof(Material.Stocks)}.{nameof(Stock.Size)}"
            };
            var materials = _materialDomainService.Get(
                filter: x => materialsIds.Contains(x.Id),
                include: includes).ToList();
            return ObjectMapper.Map<List<MaterialDto>>(materials);
        }
        public MaterialDto GetById(int id)
        {
            var includes = new string[]
            {
                $"{nameof(Material.Unit)}",
                $"{nameof(Material.Stocks)}.{nameof(Stock.Size)}",
                $"{nameof(Material.Stocks)}.{nameof(Stock.Store)}",
            };
            var material = _materialDomainService.Get(
                filter: x => x.Id == id,
                include: includes).FirstOrDefault();
            return ObjectMapper.Map<MaterialDto>(material);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            if (CheckMaterialUsedInOffer(input.Id))
            {
                throw new UserFriendlyException(L("CanNotDeleteMaterialDueToRelatedOffer"));
            }
            return base.DeleteAsync(input);
        }
    }
}

