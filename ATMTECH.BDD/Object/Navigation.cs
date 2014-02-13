using ATMTECH.BDD.Object.Base;

namespace ATMTECH.BDD.Object
{
    public class Navigation : Element
    {
        public void Navigate(string url)
        {
            new Page(url);
        }
    }
}
