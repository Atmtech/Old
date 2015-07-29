using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.Common.Context;
using ATMTECH.Common.Utils;
using ATMTECH.Common.Utils.Web;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Interface;
using Parameter = ATMTECH.Entities.Parameter;

namespace ATMTECH.Web.Services
{
    public class LocalizationService : ILocalizationService
    {
        public IDAOLocalization DAOLocalization { get; set; }
        public IDAOParameter DAOParameter { get; set; }
        public INavigationService NavigationService { get; set; }

        public const string ENABLED_LOCALIZATION = "EnabledLocalization";

        public string CurrentLanguage
        {
            get
            {
                if (string.IsNullOrEmpty((string)ContextSessionManager.Session["currentLanguage"]))
                {
                    string configuration = Configuration.GetConfigurationKey("DefaultLanguage");
                    ContextSessionManager.Session["currentLanguage"] = !string.IsNullOrEmpty(configuration)
                                                                           ? configuration
                                                                           : LocalizationLanguage.FRENCH;
                }
                return (string)ContextSessionManager.Session["currentLanguage"];
            }
            set
            {
                ContextSessionManager.Session["currentLanguage"] = value;
            }
        }

        public void SaveLocalization(IList<Localization> localizations)
        {
            IList<Localization> list = DAOLocalization.GetAll();
            foreach (Localization localization in localizations)
            {
                if (list.Count(x => x.ObjectId == localization.ObjectId) == 0)
                {
                    DAOLocalization.Save(localization);
                }
            }
        }

        public string Localize(string controlId, string currentLanguage)
        {
            string page = Pages.GetCurrentPage();
            Localization localization =
                          DAOLocalization.GetLocalization(controlId, page);
            string localizeString = FindLocalizeString(currentLanguage, localization);
            return localizeString;
        }
        public void Localize(IList<Control> Controls, string currentLanguage)
        {
            Parameter parameter = DAOParameter.GetParameter(ENABLED_LOCALIZATION);
            if (parameter != null)
            {
                string isEnabled = parameter.Description;
                if (!string.IsNullOrEmpty(isEnabled) && isEnabled != "1") return;
            }

            string page = Pages.GetCurrentPage();
            if (Controls == null) return;

            foreach (Control control in Controls.Where(control => IsLocalizable(control)))
            {
                if (control is GridView)
                {
                    for (int i = 0; i < (control as GridView).Columns.Count - 1; i++)
                    {
                        Localization localization =
                            DAOLocalization.GetLocalization((control as GridView).ID + "[" + i + "]", page);
                        if (localization != null)
                        {
                            string localizeString = FindLocalizeString(currentLanguage, localization);
                            (control as GridView).Columns[i].HeaderText = localizeString;
                        }
                    }

                }
                else
                {
                    Localization localization = DAOLocalization.GetLocalization(control.ID, page);
                    if (localization != null)
                    {
                        string localizeString = FindLocalizeString(currentLanguage, localization);

                        if (control is Label)
                        {
                            (control as Label).Text = localizeString;
                        }

                        if (control is TextBox)
                        {
                            (control as TextBox).ToolTip = localizeString;
                            (control as TextBox).Attributes["placeholder"] = localizeString;
                        }
                        if (control is Button)
                        {
                            (control as Button).Text = localizeString;
                            (control as Button).ToolTip = localizeString;
                        }

                        if (control is LinkButton)
                        {
                            (control as LinkButton).Text = localizeString;
                            (control as LinkButton).ToolTip = localizeString;
                        }

                        if (control is HyperLink)
                        {
                            (control as HyperLink).Text = localizeString;
                            (control as HyperLink).ToolTip = localizeString;
                        }

                    }
                    else
                    {
                        if (control is Label)
                        {
                            (control as Label).Text += " (*Loc)";
                        }

                        if (control is Button)
                        {
                            (control as Button).Text += " (*Loc)";
                        }
                        if (control is LinkButton)
                        {
                            (control as LinkButton).Text += " (*Loc)";
                        }
                        if (control is HyperLink)
                        {
                            (control as HyperLink).Text += " (*Loc)";
                        }
                    }
                }
            }
        }

        private bool IsLocalizable(Control control)
        {
            if (control.ID == "lnkSearch")
            {
                return false;
            }

            if (control is Label)
            {
                return true;
            }

            if (control is TextBox)
            {
                return true;
            }
            if (control is Button)
            {
                return true;
            }
            if (control is LinkButton)
            {
                return true;
            }
            if (control is HyperLink)
            {
                return true;
            }
            if (control is GridView)
            {
                return true;
            }

            return false;
        }

        private static string FindLocalizeString(string currentLanguage, Localization localization)
        {
            string localizeString = string.Empty;
            if (currentLanguage == LocalizationLanguage.FRENCH)
            {
                localizeString = localization.French;
            }
            if (currentLanguage == LocalizationLanguage.ENGLISH)
            {
                localizeString = localization.English;
            }
            return localizeString;
        }
    }
}
