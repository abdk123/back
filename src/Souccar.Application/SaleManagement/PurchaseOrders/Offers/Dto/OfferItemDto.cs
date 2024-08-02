﻿using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Materials.Dto;
using Souccar.SaleManagement.Settings.Units.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.Offers.Dto
{
    public class OfferItemDto : EntityDto
    {
        public int? MaterialId { get; set; }
        public int? SizeId { get; set; }
        public int? UnitId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Specefecation { get; set; }
        public bool AddedBySmallUnit { get; set; }
        public SizeDto Size { get; set; }
        public MaterialDto Material { get; set; }
        public UnitDto Unit{ get; set; }
        public PoOfferDto Offer { get; set; }


    }
}
