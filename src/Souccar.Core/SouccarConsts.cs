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
}
