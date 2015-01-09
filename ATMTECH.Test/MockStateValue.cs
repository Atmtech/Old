using System;
using System.Collections.Generic;
using ATMTECH.Web.Session;

namespace ATMTECH.Shell.Tests
{
    public class MockStateValue<T> : StateValue<T>, IDisposable
    {
        public static IDictionary<string, T> Session { get; set; }
        static MockStateValue()
        {
            Session = new Dictionary<string, T>();
        }

        public override T Value
        {
            get
            {
                ValiderClef();
                return Session[Clef];
            }
            set { Session[Clef] = value; }
        }

        public MockStateValue()
        {
        }

        public MockStateValue(string clef)
        {
            Clef = clef;
            if (!Session.ContainsKey(clef)) Session[Clef] = default(T);
        }

        public void Dispose()
        {
            Session.Clear();
        }
    }
}
