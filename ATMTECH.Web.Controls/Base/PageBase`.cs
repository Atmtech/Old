using WebFormsMvp;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Classe de base à utiliser pour toutes les pages ASPX
    /// </summary>
    public class PageBase<TPresenter> : PageBase
        where TPresenter : IPresenter
    {
        /// <summary>
        /// Instance du Presenter reliée à la page
        /// </summary>
        public TPresenter Presenter { get; set; }
    }
}