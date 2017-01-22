using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2C_WebForms.Controls
{
    public partial class AccountControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkSignUp_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
           new AuthenticationProperties() { RedirectUri = "/" }, Startup.SignUpPolicyId);

            }
        }
        protected void LinkSignIn_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                // To execute a policy, you simply need to trigger an OWIN challenge.
                // You can indicate which policy to use by specifying the policy id as the AuthenticationType
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties() { RedirectUri = "/" }, Startup.SignInPolicyId);
            }
        }
        protected void LinkProfile_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
           new AuthenticationProperties() { RedirectUri = "/" }, Startup.ProfilePolicyId);

            }
        }
        protected void LinkSignOut_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                IEnumerable<AuthenticationDescription> authTypes = HttpContext.Current.GetOwinContext().Authentication.GetAuthenticationTypes();
                HttpContext.Current.GetOwinContext().Authentication.SignOut(authTypes.Select(t => t.AuthenticationType).ToArray());
                Request.GetOwinContext().Authentication.GetAuthenticationTypes();
            }
        }
    }
}