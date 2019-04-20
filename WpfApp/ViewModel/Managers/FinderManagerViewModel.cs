using System.Collections.Generic;
using System.Linq;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FinderManagerViewModel : ManagerViewModel<Finder>
    {
        public FinderManagerViewModel()
        {
        }

        protected override void ColumnInit()
        {
            NomVisibility = true;
            CodeVisibility = true;
            IsActiveVisibility = true;
            IsLimitedVisibility = true;
            ValueVisibility = true;
            DecayVisibility = true;
            UsePerMinVisibility = true;
            DepthVisibility = true;
            RangeVisibility = true;
            BasePecSearchVisibility = true;
            ModeleNomVisibility = true;
        }

        protected override void Init()
        {
            Modeles = repos.Modeles.GetAll().ToList();
        }

        public bool ModeleEnabled { get; set; } = false;
        private Modele ModeleLoad()
        {
            return repos.Modeles.GetByNom("Finder");
        }

        public ICollection<Modele> Modeles { get; set; }

        public override void CreateExecute(object param)
        {
            ItemForm = new Finder();
            ItemForm.Modele = ModeleLoad();
            NomFormEnabled = true;
        }

    }
}
