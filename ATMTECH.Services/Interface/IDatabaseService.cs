using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.Services.Interface
{
    public interface IDatabaseService
    {
        string ExecuteSql(string sql);
    }
}
