using System;
using System.Reflection;
using System.Web.UI;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public partial class Default : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly()
           .GetName()
           .Version
           .ToString();
        }
    }
}