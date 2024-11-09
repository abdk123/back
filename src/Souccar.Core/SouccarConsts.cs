using Souccar.Debugging;

namespace Souccar
{
    public class SouccarConsts
    {
        public const string LocalizationSourceName = "Souccar";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f48fc498a3ae485fa2d3bfa5043900fd";
    }

    public class ValidationMessage
    {
        public const string TheOfferMustBeApprovedFirst = "TheOfferMustBeApprovedFirst";
        public const string PoIsRequired = "PoIsRequired";
        public const string SupplierIsRequired = "SupplierIsRequired";
        public const string NameAlreadyExist = "NameAlreadyExist";
        public const string ValueAlreadyExist = "ValueAlreadyExist";
        public static string CheckMaterialQuantity(string name, string opertor, string value)
        {
            return $"المادة {name} يجب ان تكون {opertor} {value}";
        }

    }

    public class LocalizationResource
    { 
        public const string ClearanceCost = "ClearanceCost";
        public const string ClearanceCostFor = "ClearanceCostForCompany{0}InvoiceNumber{1}";
        public const string TransportCost = "TransportCost";
        public const string TransportCostFor = "TransportCostForCompany{0}InvoiceNumber{1}Driver{2}";
        public const string Materials = "Materials";
        public const string DriverName = "DriverName"; 
        public const string ForCompany = "ForCompany";
        public const string InvoiceNumber = "InvoiceNumber";
        public const string ReceivingCost = "ReceivingCost";
        public const string CostOfReceivingTheMaterial = "CostOfReceivingTheMaterial{0}";
        public const string DeliveryTransportCost = "DeliveryTransportCost";
        public const string DeliveryCost = "DeliveryCost";
        public const string DeliveryCostForMaterial = "DeliveryCostForMaterial{0}andOffer{1}";

    }
}
