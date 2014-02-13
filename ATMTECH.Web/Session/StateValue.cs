using System.Web;

namespace ATMTECH.Web.Session
{
    public class StateValue<T> : IStateValue<T>
    {
        public string Clef { get; protected set; }
        public StateValue()
        { }
        public StateValue(string clef)
        {
            Clef = clef;
            if (HttpContext.Current.Session[Clef] == null)
            {
                HttpContext.Current.Session[Clef] = default(T);
            }
        }
        public virtual T Value
        {
            get
            {
                ValiderClef();
                return (T)HttpContext.Current.Session[Clef];
            }
            set { HttpContext.Current.Session[Clef] = value; }
        }

        protected void ValiderClef()
        {
            if (string.IsNullOrEmpty(Clef))
            {
//                throw new ExceptionTechnique("Le StateValue n'a pas été déclaré avec l'attribut [StateDependency]");
            }
        }
    }
}
