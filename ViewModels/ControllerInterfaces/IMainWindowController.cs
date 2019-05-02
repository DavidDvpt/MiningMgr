namespace ViewModels
{
    public interface IMainWindowController
    {
        void Start();

        MenuViewModel ShowViewMenu();

        StatusViewModel ShowViewStatus();

        FinderMgrViewModel ShowFinderMgrViewModel();
    }
}
