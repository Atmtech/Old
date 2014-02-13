using System;

namespace ATMTECH.DAO.Database
{
    public class DatabaseBackup<TModel, TId>
    {
        public DatabaseVendor.DatabaseVendorType CurrentDatabaseVendor
        {
            get { return DatabaseVendor.GetCurrentDatabaseVendorType(); }
        }

        public SQLite<TModel, TId> SqLite { get { return new SQLite<TModel, TId>(); } }
        public MsSql<TModel, TId> MsSql { get { return new MsSql<TModel, TId>(); } }
        public MySql<TModel, TId> MySql { get { return new MySql<TModel, TId>(); } }

        public void RestoreFromXml(string zipFile)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.Sqlite:
                    SqLite.RestoreFromXml(zipFile);
                    break;
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    MsSql.RestoreFromXml(zipFile);
                    break;
                case DatabaseVendor.DatabaseVendorType.MySql:
                    MySql.RestoreFromXml(zipFile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void BackupToXml(string zipFile, bool allTableFromDatabase)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.Sqlite:
                    SqLite.BackupToXml(zipFile, allTableFromDatabase);
                    break;
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    MsSql.BackupToXml(zipFile, allTableFromDatabase);
                    break;
                case DatabaseVendor.DatabaseVendorType.MySql:
                    MySql.BackupToXml(zipFile, allTableFromDatabase);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
