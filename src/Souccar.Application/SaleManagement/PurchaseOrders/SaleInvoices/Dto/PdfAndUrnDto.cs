﻿using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto
{
    public class PdfAndUrnDto: EntityDto
    {
        public string PDFFilePath { get; set; }
        public string PillURN { get; set; }
    }
}
