using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2C_WebForms
{
    public partial class Claims : System.Web.UI.Page
    {
        protected string DisplayName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Extract claims about the user
            Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);
            DisplayName = displayName != null ? displayName.Value : string.Empty;
        }
    }
}