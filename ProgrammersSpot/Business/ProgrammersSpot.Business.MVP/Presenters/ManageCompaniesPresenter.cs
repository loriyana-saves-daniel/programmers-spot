using Bytes2you.Validation;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.Data.SqlClient;
using WebFormsMvp;

namespace ProgrammersSpot.Business.MVP.Presenters
{
    public class ManageCompaniesPresenter : Presenter<IManageCompaniesView>
    {
        private IFirmService firmService;

        public ManageCompaniesPresenter(IManageCompaniesView view, IFirmService firmService) : base(view)
        {
            Guard.WhenArgument(firmService, "firmService").IsNull().Throw();

            this.firmService = firmService;
            view.EventLoadCompanies += this.OnLoadCompanies;
            view.EventUpdateFirm += this.OnUpdateFirm;
        }

        private void OnUpdateFirm(object sender, UpdateFirmEventArgs e)
        {
            try
            {
                this.firmService.UpdateFirmUser(e.FirmToUpdate);
            }
            catch (SqlException)
            {
            }
        }

        private void OnLoadCompanies(object sender, EventArgs e)
        {
            this.View.Model.Companies = this.firmService.GetAllFirmUsers();
        }
    }
}
