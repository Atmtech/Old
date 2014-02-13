using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using OboutInc.SlideMenu;
using WebFormsMvp.Web;

namespace ATMTECH.BillardLoretteville.Website.CMS
{
    public partial class Menu : MvpUserControl, IMenuPresenter
    {
        public MenuPresenter Presenter { get; set; }

        public enum TypeMenu
        {
            MenuSlide = 0,
            MenuSimple = 1
        }

        public bool IsAdministratorOnly { get; set; }
        public bool IsVisible { set { menuHolder.Visible = value; } }
        public string MenuId { get; set; }
        public TypeMenu MenuType { get; set; }

        public IList<Entities.Menu> Menus
        {
            set
            {
                IList<Entities.Menu> menus = value;
                if (menus.Count > 0)
                {
                    menuHolder.Controls.Clear();

                    switch (MenuType)
                    {
                        case TypeMenu.MenuSlide:
                            SlideMenu slideMenu = new SlideMenu();
                            foreach (Entities.Menu menu in menus)
                            {
                                if (menu.SubMenu.Count == 0)
                                {
                                    slideMenu.AddParent(menu.Id.ToString(), menu.Title, menu.Url);
                                }
                                else
                                {
                                    slideMenu.AddParent(menu.Id.ToString(), menu.Title);
                                    foreach (Entities.Menu subMenu in menu.SubMenu)
                                    {
                                        slideMenu.AddChild(menu.Id + "_" + subMenu.Id, subMenu.Title, subMenu.Url);
                                    }
                                }
                            }

                            menuHolder.Controls.Add(slideMenu);
                            break;
                        case TypeMenu.MenuSimple:
                            foreach (Entities.Menu menu in menus)
                            {
                                if (menu.SubMenu.Count == 0)
                                {
                                    HyperLink hyperLink = new HyperLink() { Text = menu.Title, NavigateUrl = menu.Url };
                                    menuHolder.Controls.Add(hyperLink);
                                }
                                else
                                {
                                    HyperLink hyperLink = new HyperLink() { Text = menu.Title, NavigateUrl = menu.Url };
                                    menuHolder.Controls.Add(hyperLink);
                                    foreach (Entities.Menu subMenu in menu.SubMenu)
                                    {
                                        HyperLink hyperLinkSub = new HyperLink() { Text = subMenu.Title, NavigateUrl = subMenu.Url };
                                        menuHolder.Controls.Add(hyperLinkSub);
                                    }
                                }
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }



                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
    }
}