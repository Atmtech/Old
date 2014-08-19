namespace ATMTECH.DAO.Database
{
    public class DatabaseVendor
    {
        public enum DatabaseVendorType
        {
            MsSql = 1,
            MySql = 2
        }

        public static DatabaseVendorType GetCurrentDatabaseVendorType()
        {
//            string databaseVendor = Utils.Configuration.GetConfigurationKey("DatabaseVendor");
            return DatabaseVendorType.MsSql;
        }
    }
}
