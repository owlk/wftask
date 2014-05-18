using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace WebApplication2.App_Code
{

    public static class AlertUtils
    {

        public static void HandleCommunicate(HttpSessionState session, Label alertLabel)
        {
            string msg = session[Constants.SESSION_KEY_COMMUNICATE] as string;
            if (msg != null)
            {
                alertLabel.Visible = true;
                alertLabel.Text = msg;
                session.Remove(Constants.SESSION_KEY_COMMUNICATE);
            }
            else
            {

                alertLabel.Visible = false;
            }
        }

        public static void SetCommunicate(HttpSessionState session, string communicate)
        {
            session[Constants.SESSION_KEY_COMMUNICATE] = communicate;
        }
    }
}