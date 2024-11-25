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
using Abp.Domain.Uow;
using System.Transactions;
using Souccar.SaleManagement.Stocks.Dto;
using Souccar.SaleManagement.Settings.Units.Services;


namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public class MaterialAppService :
        AsyncSouccarAppService<Material, MaterialDto, int, FullPagedRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialDomainService _materialDomainService;
        private readonly IStockDomainService _stockDomainService;
        private readonly ISizeDomainService _sizeDomainService;
        public MaterialAppService(IMaterialDomainService materialDomainService, IStockDomainService stockDomainService, ISizeDomainService sizeDomainService) : base(materialDomainService)
        {
            _materialDomainService = materialDomainService;
            _stockDomainService = stockDomainService;
            _sizeDomainService = sizeDomainService;
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
                    materialId: output.Id
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
            foreach (var item in createdList)
            {
                var stock = ObjectMapper.Map<Stock>(item);
                await _stockDomainService.InsertAsync(stock);
            }
            foreach (var item in deletedList)
            {
                await _stockDomainService.DeleteAsync(item.Id);
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
                    materialId: updatedMaterial.Id
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
    }
}

