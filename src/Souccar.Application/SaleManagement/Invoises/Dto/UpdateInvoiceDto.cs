using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class UpdateInvoiceDto : EntityDto<int>
    {
        public int Status { get; set; }
        public int? OfferId { get; set; }
    }
}

