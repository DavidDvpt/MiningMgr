using WpfApp.Commands;

namespace WpfApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new NavCommand<string>(OnNav);
        }
        public NavCommand<string> NavCommand { get; private set; }

        private SetupViewModel setupViewModel = new SetupViewModel();

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                SetProperty(ref _CurrentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "setup":
                default:
                    CurrentViewModel = setupViewModel;
                    break;
            }
        }
    }
}
