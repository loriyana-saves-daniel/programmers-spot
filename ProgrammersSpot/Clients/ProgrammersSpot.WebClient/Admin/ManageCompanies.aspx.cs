using ProgrammersSpot.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersSpot.WebClient.Admin
{
    public partial class ManageCompanies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<FirmUser> GridViewFirms_GetData()
        {
            return (new List<FirmUser>() { new FirmUser() { Id=Guid.NewGuid().ToString() , AvatarUrl = ""} }).AsQueryable();
        }
        
        public void GridViewFirms_UpdateItem(FirmUser user)
        {
            
        }
    }
}