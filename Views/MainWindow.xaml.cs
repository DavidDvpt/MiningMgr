using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Implementation de IView

        public void ViewModelActivatingHandler()
        {
            this.Activate();
        }

        /// <summary>
        /// Dire à la vue de se fermer. Traitement du cas où nous sommes dans une fenêtre et que la fenêtre doit être fermée.
        /// </summary>
        /// <param name="dialogResult"></param>
        public void ViewModelClosingHandler(bool? dialogResult)
        {
            // Traitez la méthode ViewClosed pour la gérer si cela a été déclenché par l'utilisateur qui ferme une fenêtre plutôt que par
            //la fermeture étant initiée par un ViewModel
            ViewClosed();
        }

        #endregion

        /// <summary>
        /// La fenetre se ferme, on efface les references
        /// </summary>
        public void ViewClosed()
        {
            // Afin de gérer le cas où l'utilisateur ferme la fenêtre (plutôt que de contrôler nous même la fermeture via un ViewModel)
            // nous devons vérifier que le DataContext n'est pas nul (ce qui voudrait dire que ViewClosed a déjà été fait)
            if (DataContext != null)
            {
                ((BaseViewModel)DataContext).ViewModelClosing -= ViewModelClosingHandler;
                ((BaseViewModel)DataContext).ViewModelActivating -= ViewModelActivatingHandler;
                this.DataContext = null; // Assurez - vous que nous n'avons plus aucune référence VM
            }
        }
    }
}
