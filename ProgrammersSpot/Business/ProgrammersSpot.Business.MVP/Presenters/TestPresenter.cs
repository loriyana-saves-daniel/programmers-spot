using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Views;
using System;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class TestPresenter : Presenter<ITestView>
    {
        private readonly ITestView view;

        public TestPresenter(ITestView view) // inject providers/services here
            : base(view)
        {
            Guard.WhenArgument(view, "ITestView").IsNull().Throw();

            this.view = view;
            this.view.MyInit += this.View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.view.Model.Message = "All the awesome programmers are here!"; // data from provider
        }
    }
}
