using System;
using System.Web.UI;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Interface TrouverControle
    /// </summary>
    public interface ITrouveurControle
    {
        /// <summary>
        /// Retrouver un contrôle par son ID.
        /// </summary>
        /// <param name="id">L'id du contrôle.</param>
        /// <returns></returns>
        Control RetrouverControle(String id);
    }
}