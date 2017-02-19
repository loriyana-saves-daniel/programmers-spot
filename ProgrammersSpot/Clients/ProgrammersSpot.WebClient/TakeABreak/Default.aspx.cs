using ProgrammersSport.Business.Models.UploadedImages;
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

namespace ProgrammersSpot.WebClient.TakeABreak
{
    [PresenterBinding(typeof(TakeABreakPresenter))]
    public partial class TakeABreak : MvpPage<TakeABreakViewModel>, ITakeABreakView
    {
        public event EventHandler<EventArgs> EventBindPageData;
        public event EventHandler<SearchEventArgs> EventSearchImages;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.EventBindPageData(sender, e);
        }

        public IQueryable<UploadedImage> ListViewImages_GetData([Control] string sortBy, [QueryString("imgTitle")] string query)
        {
            if (sortBy == null)
            {
                return this.Model.UploadedImages;
            }

            if (query != null)
            {
                this.EventSearchImages(this, new SearchEventArgs(query));
            }

            var images = this.Model.UploadedImages;
            if (sortBy == "DateUploaded")
            {
                if (!this.CheckBoxIsDescending.Checked)
                {
                    images = images.OrderBy(i => i.DateUploaded);
                }
                else
                {
                    images = images.OrderByDescending(i => i.DateUploaded);
                }
            }
            else if (sortBy == "LikesCount")
            {
                if (!this.CheckBoxIsDescending.Checked)
                {
                    images = images.OrderBy(i => i.LikesCount);
                }
                else
                {
                    images = images.OrderByDescending(i => i.LikesCount);
                }
            }

            return images;
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            string queryParam = string.Format("?imgTitle={0}", this.TextBoxSearch.Text);
            Response.Redirect("~/TakeABreak" + queryParam);
        }
    }
}