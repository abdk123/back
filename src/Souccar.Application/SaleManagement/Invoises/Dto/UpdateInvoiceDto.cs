using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class UpdateInvoiceDto : EntityDto<int>
    {
        public UpdateInvoiceDto()
        {
            InvoiseDetails = new List<UpdateInvoiceItemDto>();
        }
        public int InvoiceType { get; set; }
        public int? OfferId { get; set; }
        public int? SupplierOfferId { get; set; }
        public int? SupplierId { get; set; }
        public Currency Currency { get; set; }
        public int Status { get; set; }
        public IList<UpdateInvoiceItemDto> InvoiseDetails { get; set; }
    }
}

