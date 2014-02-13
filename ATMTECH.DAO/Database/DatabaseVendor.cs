namespace ATMTECH.DAO.Database
{
    public class DatabaseVendor
    {
        public enum DatabaseVendorType
        {
            Sqlite = 0,
            MsSql = 1,
            MySql = 2
        }

        public static DatabaseVendorType GetCurrentDatabaseVendorType()
        {
            string databaseVendor = Utils.Configuration.GetConfigurationKey("DatabaseVendor");

            if (databaseVendor == "sqlite")
            {
                return DatabaseVendorType.Sqlite;
            }
            else if (databaseVendor == "mssql")
            {
                return DatabaseVendorType.MsSql;
            }
            else
            {
                return DatabaseVendorType.Sqlite;
            }
        }
    }
}
