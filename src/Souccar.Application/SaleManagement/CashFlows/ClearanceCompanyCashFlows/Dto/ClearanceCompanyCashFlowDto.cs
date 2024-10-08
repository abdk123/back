﻿using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Companies.Dto;
using System;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows.Dto
{
    public class ClearanceCompanyCashFlowDto : EntityDto
    {
        public double AmountDollar { get; set; }
        public double CurrentBalanceDollar { get; set; }
        public double AmountDinar { get; set; }
        public double CurrentBalanceDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? ClearanceCompanyId { get; set; }
        public ClearanceCompanyDto ClearanceCompany { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
