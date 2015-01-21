using System.Windows.Forms;

namespace ATMTECH.PublierFtp
{
    public static class WinFormUtils
    {
        public static void DoPaintEvents()
        {
            Application.AddMessageFilter(PaintMessageFilter.Instance);
            Application.DoEvents();
            Application.RemoveMessageFilter(PaintMessageFilter.Instance);
        }

        private class PaintMessageFilter : IMessageFilter
        {
            static public IMessageFilter Instance = new PaintMessageFilter();
            public bool PreFilterMessage(ref Message m)
            {
                return (m.Msg != 0x000F);
            }
        }
    }
}
