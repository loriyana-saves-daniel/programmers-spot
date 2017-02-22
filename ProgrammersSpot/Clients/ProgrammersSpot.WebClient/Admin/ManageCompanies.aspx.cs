using ProgrammersSpot.Business.Models.Users;
using ProgrammersSpot.Business.MVP.Args;
using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.ViewModels;
using ProgrammersSpot.Business.MVP.Views;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace ProgrammersSpot.WebClient.Admin
{
    [PresenterBinding(typeof(ManageCompaniesPresenter))]
    public partial class ManageCompanies : MvpPage<ManageCompaniesViewModel>, IManageCompaniesView
    {
        public event EventHandler<EventArgs> EventLoadCompanies;
        public event EventHandler<UpdateFirmEventArgs> EventUpdateFirm;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.User.IsInRole("Admin"))
            {
                this.Response.StatusCode = 401;
                this.Response.End();
            }

            this.EventLoadCompanies?.Invoke(this, new EventArgs());
        }

        public IQueryable<FirmUser> GridViewFirms_GetData()
        {
            return this.Model.Companies;
        }
        
        public void GridViewFirms_UpdateItem(FirmUser firm)
        {
            var firmFromDb = this.Model.Companies.First(c => c.Id == firm.Id);
            firm.CountryId = firmFromDb.CountryId;
            firm.CityId = firmFromDb.CityId;
            this.EventUpdateFirm?.Invoke(this, new UpdateFirmEventArgs() { FirmToUpdate = firm });
        }
    }
}