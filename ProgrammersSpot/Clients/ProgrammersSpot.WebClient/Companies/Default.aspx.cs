using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Companies
{
    [PresenterBinding(typeof(FirmsPresenter))]
    public partial class Companies : MvpPage<FirmsViewModel>, IFirmsView
    {
        public event EventHandler<EventArgs> EventGetFirms;
        public event EventHandler<SearchEventArgs> EventSearchFirms;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<FirmUser> ListViewFirms_GetData([Control] string sortBy, [QueryString("companyName")] string query)
        {
            if (query == null)
            {
                this.EventGetFirms?.Invoke(this, new EventArgs());
            }
            else
            {
                this.EventSearchFirms?.Invoke(this, new SearchEventArgs(query));
            }

            var firms = this.Model.Firms;

            if (sortBy == "Rating")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    firms = firms.OrderByDescending(f => f.Rating);
                }
                else
                {
                    firms = firms.OrderBy(f => f.Rating);
                }
            }
            else if (sortBy == "CompanyName")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    firms = firms.OrderByDescending(f => f.FirmName);
                }
                else
                {
                    firms = firms.OrderBy(f => f.FirmName);
                }
            }
            else if (sortBy == "EmployeesCount")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    firms = firms.OrderByDescending(f => f.EmployeesCount);
                }
                else
                {
                    firms = firms.OrderBy(f => f.EmployeesCount);
                }
            }

            return firms;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string queryParam = string.Format("?companyName={0}", this.TextBoxSearch.Text);
            Response.Redirect(this.ResolveUrl("~/Companies" + queryParam));
        }
    }
}