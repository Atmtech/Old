using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.Services.Interface
{
    public interface IDatabaseService
    {
        string ExecuteSql(string sql, EnumDatabaseVendor enumDatabaseVendor);
        string CreateMssqlBackup(string BackUpLocation, string BackUpFileName, string DatabaseName);
        string RestoreMssqlBackup(string BackUpLocation, string BackUpFileName, string DatabaseName);
        string GetServerName();
    }
    public enum EnumDatabaseVendor
    {
        Mssql = 1
    }
}
