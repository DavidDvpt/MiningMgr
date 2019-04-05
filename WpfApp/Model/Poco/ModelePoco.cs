using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;
using WpfApp.Tools;

namespace WpfApp.Model.Poco
{
    public class ModelePoco : CommunPoco<ModeleDto>
    {
        public bool IsStackable { get; set; } = false;

        public int CategorieId { get; set; }

        public virtual CategorieDto Categorie { get; set; }

        //public virtual Collection<InWorldPoco> InWorldsPoco
        //    => _Dto.InWorldsDto.ToPocoCollection<InWorldDto, InWorldPoco>();
    }
}
