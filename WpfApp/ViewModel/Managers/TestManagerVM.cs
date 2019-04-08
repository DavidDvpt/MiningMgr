using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Poco;

namespace WpfApp.ViewModel
{
    public class TestManagerVM : BaseViewModel
    {
        protected override void Init()
        {
            //throw new NotImplementedException();
        }

        public ModelePoco Modele
            => repos.ModelesPoco.GetByNom("Finder");

        public CategoriePoco SelectedCatgorie
            => Modele.CategoriePoco;

        public ICollection<CategoriePoco> Categories
            => repos.CategoriesPoco.GetAll().ToList();
    }
}
