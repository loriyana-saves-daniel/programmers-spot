using System;

namespace ProgrammersSpot.WebClient.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.User.IsInRole("Admin"))
            {
                this.Response.StatusCode = 401;
                this.Response.End();
            }
        }
    }
}