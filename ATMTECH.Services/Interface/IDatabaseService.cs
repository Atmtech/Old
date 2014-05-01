using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.Services.Interface
{
    public interface IDatabaseService
    {
        string ExecuteSql(string sql, EnumDatabaseVendor enumDatabaseVendor);
    }
    public enum EnumDatabaseVendor
    {
        Sqlite = 0, Mssql = 1
    }
}
