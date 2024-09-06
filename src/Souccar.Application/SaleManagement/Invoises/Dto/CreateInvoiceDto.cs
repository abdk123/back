using System;
using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class CreateInvoiceDto : EntityDto<int>
    {
        public int Status { get; set; }
        public int? OfferId { get; set; }
    }
}

