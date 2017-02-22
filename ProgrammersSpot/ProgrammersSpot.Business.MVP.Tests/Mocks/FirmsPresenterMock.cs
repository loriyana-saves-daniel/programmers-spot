using ProgrammersSpot.Business.MVP.Presenters;
using ProgrammersSpot.Business.MVP.Views;
using ProgrammersSpot.Business.Services.Contracts;

namespace ProgrammersSpot.Business.MVP.Tests.Mocks
{
    public class FirmsPresenterMock : FirmsPresenter
    {
        public FirmsPresenterMock(IFirmsView view, IFirmService firmService) : base(view, firmService)
        {
        }

        public IFirmService FirmService
        {
            get
            {
                return this.firmService;
            }
        }
    }
}
