using System.Configuration;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class ParameterService : BaseService, IParameterService
    {
        public IDAOParameter DAOParameter { get; set; }
        public ILocalizationService LocalizationService { get; set; }
        
        public string GetValue(string code)
        {
            Parameter parameter = DAOParameter.GetParameter(code, LocalizationService.CurrentLanguage);
            if (parameter != null)
            {
                return parameter.Description;
            }
            return ConfigurationManager.AppSettings.Get(code);
        }

        public void SetValue(string code, string value)
        {
            Parameter parameter = DAOParameter.GetParameter(code, LocalizationService.CurrentLanguage);
            parameter.Description = value;
            DAOParameter.UpdateParameter(parameter);
        }
    }
}
