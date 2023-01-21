using System;
using System.Windows.Forms;

namespace XRTSoft.PowerApps.PowerFind
{
    /// <summary>
    /// Extension methods for the app.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Thread safe invocation of a method on a control.
        /// </summary>
        /// <param name="c">The control to invoke the action against.</param>
        /// <param name="a">The action to be invoked.</param>
        public static void Invoke(this Control c, Action a)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(a);
            }
            else
            {
                a.Invoke();
            }
        }
    }
}
