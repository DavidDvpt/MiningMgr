using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class EnhancerManagerViewModel : ManagerViewModel<Enhancer>
    {
        #region Constructeurs et initialisation

        public EnhancerManagerViewModel()
        {

        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            ValueVisibility = true;
            ModeleNomVisibility = true;
            IsActiveVisibility = true;
            SlotVisibility = true;
            BonusValue1Visibility = true;
            BonusValue2Visibility = true;
        }

        protected override void Init()
        {
            Modeles = repos.Modeles.GetAll().Where(x=>x.Nom.Contains("Enhancer")).ToList();
        }

        #endregion

        public ICollection<Modele> Modeles { get; set; }

    }
}
