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

namespace Souccar.SaleManagement.Settings.Materials.Services
{
    public class MaterialAppService :
        AsyncSouccarAppService<Material, MaterialDto, int, FullPagedRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialDomainService _materialDomainService;
        private readonly IStockDomainService _stockDomainService;
        public MaterialAppService(IMaterialDomainService materialDomainService, IStockDomainService stockDomainService) : base(materialDomainService)
        {
            _materialDomainService = materialDomainService;
            _stockDomainService = stockDomainService;
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
                    quantity: stock.QuantityInLargeUnit,
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
            ObjectMapper.Map<UpdateMaterialDto, Material>(input, material);
            var output = await _materialDomainService.UpdateAsync(material);
            var materials = _materialDomainService
                .Get(filter: x => x.Id == output.Id, include: new string[] { "Stocks.Unit", "Stocks.Size" })
                .FirstOrDefault();

            foreach (var stock in materials.Stocks)
            {
                await EventBus.Default.TriggerAsync(new StockHistoryEventUpdateData(
                    type: StockType.Entry,
                    reason: StockReason.InitialBalance,
                    title: L(LocalizationResource.InitialBalanceForMaterial, output.Name, stock.Size?.Name),
                    quantity: stock.QuantityInLargeUnit,
                    relatedId: stock.Id,
                    unitId: material.UnitId,
                    sizeId: stock.SizeId,
                    materialId: output.Id
                    ));
            }
            return ObjectMapper.Map<MaterialDto>(output);
            
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
                $"{nameof(Material.Stocks)}.{nameof(Stock.Size)}"
            };
            var material = _materialDomainService.Get(
                filter: x => x.Id == id,
                include: includes).FirstOrDefault();
            return ObjectMapper.Map<MaterialDto>(material);
        }
    }
}

