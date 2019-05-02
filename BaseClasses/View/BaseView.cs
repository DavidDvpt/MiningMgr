using System;
using System.Windows;
using System.Windows.Controls;

namespace BaseClasses
{
    /// <summary>
    /// Délégué qui autorise le traitement de l'event WindowClosed 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnWindowClose(Object sender, EventArgs e);

    /// <summary>
    /// c'est la classe de base de toutes les vues
    /// elle ne peut pas être abstraite car ca va causer des pb qd "design time"
    /// va essayer d'instancier cette classe
    /// cette viex n'a pas de XAML car on ne peux pas heriter d'une classe XAML
    /// </summary>
    public partial class BaseView : UserControl, IDisposable, IView
    {
        private ViewWindow viewWindow; // si affiché dans une fenêtre, la voila
        private OnWindowClose onWindowClosed = null;

        #region Fermeture

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

        /// <summary>
        /// Traitement de l'event Window Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ViewsWindow_Closed(object sender, EventArgs e)
        {
            if (onWindowClosed != null)
            {
                onWindowClosed(sender, e);
            }
            ((BaseViewModel)DataContext).CloseViewModel(false);
        }

        #endregion

        #region Implementation de IView

        /// <summary>
        /// Dire à la vue de se fermer. Traitement du cas où nous sommes dans une fenêtre et que la fenêtre doit être fermée.
        /// </summary>
        /// <param name="dialogResult"></param>
        public void ViewModelClosingHandler(bool? dialogResult)
        {
            if (viewWindow == null)
            {
                System.Windows.Controls.Panel panel = this.Parent as System.Windows.Controls.Panel;
                if (panel != null)
                {
                    panel.Children.Remove(this);
                }
            }
            else
            {
                viewWindow.Closed -= ViewsWindow_Closed;

                if (viewWindow.IsDialogWindow)
                {
                    // si la fenetre est un dialog et non active, elle doit etre dans le processus de fermeture
                    if (viewWindow.IsActive)
                    {
                        viewWindow.DialogResult = dialogResult;
                    }

                    viewWindow.DialogResult = dialogResult;
                }
                else
                {
                    viewWindow.Close();
                }

                viewWindow = null;
            }

            // Traitez la méthode ViewClosed pour la gérer si cela a été déclenché par l'utilisateur qui ferme une fenêtre plutôt que par
            //la fermeture étant initiée par un ViewModel
            ViewClosed();
        }

        /// <summary>
        /// Active la fenetre
        /// </summary>
        public void ViewModelActivatingHandler()
        {
            if (viewWindow != null)
            {
                viewWindow.Activate();
            }
        }

        #endregion

        #region Constructeurs

        public BaseView()
        {
        }

        #endregion

        #region Window

        /// <summary>
        /// La fenêtre sur laquelle la vue est affichée (si elle est affichée sur une fenêtre)
        /// La fenêtre sera créée par View on demand (si nécessaire) ou peut être
        /// fourni par l'application.
        /// </summary>
        private ViewWindow ViewWindow
        {
            get
            {
                if (viewWindow == null)
                {
                    viewWindow = new ViewWindow();
                    viewWindow.Closed += ViewsWindow_Closed;
                }

                return viewWindow;
            }
        }

        #endregion

        #region Methodes D'affichage

        /// <summary>
        /// Afficher ce contrôle dans une fenêtre, de la taille voulue, avec ce titre
        /// </summary>
        /// <param name="modal"></param>
        /// <param name="windowTitle"></param>
        public void ShowInWindow(bool modal, string windowTitle)
        {
            ShowInWindow(modal, windowTitle, 800, 450, Dock.Top, null);
            //ShowInWindow(modal, windowTitle, 0, 0, Dock.Top, null);
        }

        /// <summary>
        /// Afficher ce contrôle dans une fenêtre existante, par défaut, ancré en haut.
        /// </summary>
        /// <param name="modal"></param>
        /// <param name="window"></param>
        public void ShowInWindow(bool modal, ViewWindow window)
        {
            ShowInWindow(modal, window, window.Title, window.Width, window.Height, Dock.Top, null);
        }

        /// <summary>
        /// Flexibilité maximale de la version Définition de la fenêtre de Show In Window
        /// </summary>
        /// <param name="modal"></param>
        /// <param name="window">fenetre dans laquelle la vue dout etre affichée</param>
        /// <param name="windowTitle">titre de la fenetre</param>
        /// <param name="windowWidth">largeur de la fenetre</param>
        /// <param name="windowHeight">hauteur de la fenetre</param>
        /// <param name="dock">comment la vue doit être dockee</param>
        /// <param name="onWindowClose">traitement de l'event quand la fenetre est fermee</param>
        public void ShowInWindow(bool modal, ViewWindow window, string windowTitle, double windowWidth, double windowHeight, Dock dock, OnWindowClose onWindowClose)
        {
            this.onWindowClosed = onWindowClose;

            viewWindow = window;
            viewWindow.Title = windowTitle;
            DockPanel.SetDock(this, dock);

            // Le viewWindow doit avoir un dockPanel appelé WindowDockPanel. Si vous voulez changer ceci pour utiliser un autre conteneur sur la fenêtre, alors
            // le code ci - dessous devrait être le seul endroit où il doit être changé.
            viewWindow.WindowDockPanel.Children.Add(this);

            if (windowWidth == 0 && windowHeight == 0)
            {
                viewWindow.SizeToContent = SizeToContent.WidthAndHeight;
            }
            else
            {
                viewWindow.SizeToContent = SizeToContent.Manual;
                viewWindow.Width = windowWidth;
                viewWindow.Height = windowHeight;
            }

            if (modal)
            {
                viewWindow.ShowDialog();
            }
            else
            {
                viewWindow.Show();
            }
        }

        /// <summary>
        /// montre la vue dans la nouvelle fenetre
        /// </summary>
        /// <param name="modal"></param>
        /// <param name="windowTitle">titre de la fenetre</param>
        /// <param name="windowWidth">largeur de la fenetre</param>
        /// <param name="windowHeight">hauteur de la fenetre</param>
        /// <param name="dock">comment la vue doit être dockee</param>
        /// <param name="onWindowClose">traitement de l'event quand la fenetre est fermee</param>
        public void ShowInWindow(bool modal, string windowTitle, double windowWidth, double windowHeight, Dock dock, OnWindowClose onWindowClose)
        {
            ShowInWindow(modal, ViewWindow, windowTitle, windowWidth, windowHeight, dock, onWindowClose);
        }

        #endregion

        #region Membres disposables

        public void Dispose()
        {
            // supprime tous les event de la fenetre pour eviter les pb fuite memoire
            if (viewWindow != null)
            {
                viewWindow.Closed -= this.ViewsWindow_Closed;
            }
        }

        #endregion
    }
}
