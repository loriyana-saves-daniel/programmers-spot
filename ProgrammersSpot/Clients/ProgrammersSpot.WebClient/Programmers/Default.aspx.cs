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

namespace ProgrammersSpot.WebClient.Programmers
{
    [PresenterBinding(typeof(ProgrammersPresenter))]
    public partial class Programmers : MvpPage<ProgrammersViewModel>, IProgrammersView
    {
        public event EventHandler<EventArgs> EventGetProgrammers;
        public event EventHandler<SearchEventArgs> EventSearchProgrammers;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<RegularUser> ListViewProgrammers_GetData([Control] string sortBy, [QueryString("skill")] string query)
        {
            if (query == null)
            {
                this.EventGetProgrammers?.Invoke(this, new EventArgs());
            }
            else
            {
                this.EventSearchProgrammers?.Invoke(this, new SearchEventArgs(query));
            }

            var programmers = this.Model.Programmers;

            if (sortBy == "Stars")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    programmers = programmers.OrderByDescending(f => f.StarsCount);
                }
                else
                {
                    programmers = programmers.OrderBy(f => f.StarsCount);
                }
            }
            else if (sortBy == "Age")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    programmers = programmers.OrderByDescending(f => f.Age);
                }
                else
                {
                    programmers = programmers.OrderBy(f => f.Age);
                }
            }
            else if (sortBy == "FirstName")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    programmers = programmers.OrderByDescending(f => f.FirstName);
                }
                else
                {
                    programmers = programmers.OrderBy(f => f.FirstName);
                }
            }
            else if (sortBy == "LastName")
            {
                if (this.CheckBoxIsDescending.Checked)
                {
                    programmers = programmers.OrderByDescending(f => f.LastName);
                }
                else
                {
                    programmers = programmers.OrderBy(f => f.LastName);
                }
            }

            return programmers;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string queryParam = string.Format("?skill={0}", this.TextBoxSearch.Text);
            Response.Redirect(this.ResolveUrl("~/Programmers" + queryParam));
        }
    }
}