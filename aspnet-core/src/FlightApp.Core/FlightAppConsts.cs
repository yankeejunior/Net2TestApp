using FlightApp.Debugging;

namespace FlightApp
{
    public class FlightAppConsts
    {
        public const string LocalizationSourceName = "FlightApp";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "69918e9598f448fbbf4755824c9325a6";
    }
}
