using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public abstract class UnstackableManagerViewModel<T> : ManagerViewModel<T>
        where T : Unstackable, new()
    {
        #region Champs

        protected string _nomUnstackable;

        #endregion

        #region Constructeurs et initialisations

        public UnstackableManagerViewModel()
        {
        }

        protected override void Init()
        {
            Modeles = repos.Modeles.GetAll().ToList();
        }

        #endregion

        #region Enabled Champ Formulaire

        public bool ModeleEnabled { get; set; } = false;

        #endregion

        #region Gestion control Modele

        protected Modele ModeleLoad(string modele)
        {
            return repos.Modeles.GetByNom(_nomUnstackable);
        }

        public ICollection<Modele> Modeles { get; set; }

        #endregion

        #region CanExecute

        public override void CreateExecute(object param)
        {
            ItemForm = new T { Modele = ModeleLoad(_nomUnstackable) };
            NomFormEnabled = true;
        }

        #endregion
    }
}
