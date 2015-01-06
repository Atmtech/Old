using System.Web.UI;

namespace ATMTECH.Controls
{
    public static class ControlBase
    {
        public static void IncorporerJavascript(this Page page, string cle, string js)
        {
            page.ClientScript.RegisterClientScriptBlock(typeof(Page), cle, js, true);
        }




    }
}
