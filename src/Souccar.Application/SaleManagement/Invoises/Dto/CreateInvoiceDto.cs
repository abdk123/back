using System.Collections.Generic;
using Souccar.SaleManagement.Settings.Currencies;

namespace Souccar.SaleManagement.Invoises.Dto
{
    public class CreateInvoiceDto //: ICustomValidate
    {
        public CreateInvoiceDto()
        {
            InvoiseDetails = new List<CreateInvoiceItemDto>();
        }
        public int InvoiceType { get; set; }
        public int? OfferId { get; set; }
        public int? SupplierOfferId { get; set; }
        public int? SupplierId { get; set; }
        public Currency Currency { get; set; }
        public IList<CreateInvoiceItemDto> InvoiseDetails { get; set; }

        //public void AddValidationErrors(CustomValidationContext context)
        //{
        //    using (var scope = context.IocResolver.CreateScope())
        //    {
        //        using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
        //        {
        //            var invoiceItemRepository = scope.Resolve<IRepository<PurchaseInvoiceItem, int>>();
        //            var offerItemRepository = scope.Resolve<IRepository<OfferItem, int>>();
        //            var supplierOfferItemRepository = scope.Resolve<IRepository<SupplierOfferItem, int>>();
        //            var materialRepository = scope.Resolve<IRepository<Material, int>>();
        //            if (InvoiceType == 0)
        //            {
        //                var offerItemsIds = InvoiseDetails.Select(x => x.OfferItemId);
        //                var invoicItems = invoiceItemRepository.GetAll()
        //                        .Include(x => x.Invoice)
        //                        .Include(x => x.OfferItem).ThenInclude(x => x.Material)
        //                        .Where(x => offerItemsIds.Contains(x.OfferItemId));
        //                foreach (var invoiceItem in InvoiseDetails)
        //                {
        //                    var offerItem = offerItemRepository.Get(invoiceItem.OfferItemId.Value);
        //                    var items = invoicItems.Where(x => x.OfferItemId == invoiceItem.OfferItemId );
        //                    var qty = items.Any() ? items.Sum(x => x.Quantity) : 0;
        //                    if (invoiceItem.Quantity > (offerItem.Quantity - qty))
        //                    {
        //                        var material = materialRepository.FirstOrDefault(x=>x.Id == );
        //                        var key = ValidationMessage.CheckMaterialQuantity(material.Name, "√’€— √Ê Ì”«ÊÌ", (offerItem.Quantity - qty).ToString());
        //                        var errorMessage = context.Localize(SouccarConsts.LocalizationSourceName, key);
        //                        var memberNames = new[] { nameof(InvoiseDetails) };
        //                        context.Results.Add(new ValidationResult(errorMessage, memberNames));
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                var ids = InvoiseDetails.Select(x => x.SupplierOfferItemId);
        //                var offersItems = invoiceItemRepository.GetAll()
        //                        .Include(x => x.SupplierOfferItem).ThenInclude(x => x.Material)
        //                        .Where(x => ids.Contains(x.SupplierOfferItemId));
        //                foreach (var invoiceItem in InvoiseDetails)
        //                {
        //                    var offerItem = supplierOfferItemRepository.Get(invoiceItem.SupplierOfferItemId.Value);
        //                    var items = offersItems.Where(x => x.SupplierOfferItemId == invoiceItem.SupplierOfferItemId);
        //                    var qty = items.Any() ? items.Sum(x => x.Quantity) : 0;
        //                    if (invoiceItem.Quantity > (offerItem.Quantity - qty))
        //                    {
        //                        var materialName = items.First().SupplierOfferItem.MaterialName;
        //                        var key = ValidationMessage.CheckMaterialQuantity(materialName, "√’€— √Ê Ì”«ÊÌ", (offerItem.Quantity - qty).ToString());
        //                        var errorMessage = context.Localize(SouccarConsts.LocalizationSourceName, key);
        //                        var memberNames = new[] { nameof(InvoiseDetails) };
        //                        context.Results.Add(new ValidationResult(errorMessage, memberNames));
        //                    }
        //                }
        //            }
                    

        //            uow.Complete();
        //        }
        //    }
        //}
    }
}

