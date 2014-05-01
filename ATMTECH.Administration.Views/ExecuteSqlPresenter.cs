using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class ExecuteSqlPresenter : BaseAdministrationPresenter<IExecuteSqlPresenter>
    {

        public IDatabaseService DatabaseService { get; set; }

        public ExecuteSqlPresenter(IExecuteSqlPresenter view)
            : base(view)
        {
        }


        public void ExecuteSql(string sql)
        {
            View.ReturnExecuteSql = DatabaseService.ExecuteSql(sql, EnumDatabaseVendor.Mssql);
        }
    }


}
