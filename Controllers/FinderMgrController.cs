using Services.Interfaces;
using ViewModels;

namespace Controllers
{
    public class FinderMgrController : BaseController, IFinderMgrController
    {
        private IFinderMgrService _finderMgrService;

        public FinderMgrController(IFinderMgrService fms)
        {
            _finderMgrService = fms;
        }
    }
}
