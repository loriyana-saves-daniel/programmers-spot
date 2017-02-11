using System;
using WebFormsMvp;
using WebFormsMvp.Web;

using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;

namespace ProgramersSpot.Client
{
    [PresenterBinding(typeof(TestPresenter))]
    public partial class _Default : MvpPage<TestViewModel>, ITestView
    {
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);

            this.MessageLabel.Text = this.Model.Message;
        }
    }
}