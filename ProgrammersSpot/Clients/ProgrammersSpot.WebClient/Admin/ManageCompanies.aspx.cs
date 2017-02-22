using ProgrammersSpot.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgrammersSpot.WebClient.Admin
{
    public partial class ManageCompanies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FirmUser> GridViewFirms_GetData()
        {
            return (new List<FirmUser>() { new FirmUser() { Id=Guid.NewGuid().ToString()} }).AsQueryable();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewFirms_UpdateItem(int id)
        {

        }
    }
}