using System.Configuration;
using SolutionUtilities;
using TSIAesEncryption;

namespace MvcSample.Data.Abstracts
{
    public abstract class BaseDataManager : SqlServerDatabaseWorker
    {
        protected BaseDataManager() : base(DatabaseServer, DatabaseName, DatabaseUsername, DatabasePassword) { }

        #region PROPERTIES

        private static string DatabaseServer
        {
            get { return ConfigurationManager.AppSettings["SQLServerName"] ?? string.Empty; }
        }



        private static string DatabaseName
        {
            get { return ConfigurationManager.AppSettings["SQLDatabaseName"] ?? string.Empty; }
        }

        private static string DatabaseUsername
        {
            get { return ConfigurationManager.AppSettings["SQLUsername"] != null ? new TSICryptoAES().onDecrypt(ConfigurationManager.AppSettings["SQLUsername"]) : string.Empty; }
        }

        private static string DatabasePassword
        {
            get { return ConfigurationManager.AppSettings["SQLPassword"] != null ? new TSICryptoAES().onDecrypt(ConfigurationManager.AppSettings["SQLPassword"]) : string.Empty; }
        }

        #endregion PROPERTIES
    }
}