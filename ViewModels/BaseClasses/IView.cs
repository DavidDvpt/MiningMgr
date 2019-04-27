namespace ViewModels
{
    public interface IView
    {
        // fermeture du viewModel
        void ViewModelClosingHandler(bool? dialogResult);
        // Activation du viewModel
        void ViewModelActivatingHandler();
        
        object DataContext { get; set; }
    }
}
