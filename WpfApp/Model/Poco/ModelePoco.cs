using System.Collections.ObjectModel;
using WpfApp.Model.Dto;
using WpfApp.Tools;

namespace WpfApp.Model.Poco
{
    public class ModelePoco : CommunPoco<ModeleDto>
    {
        public bool IsStackable
        {
            get => _Dto.IsStackable;
            set
            {
                _Dto.IsStackable = value;
                NotifyPropertyChanged();
            }
        }

        public int CategorieId
        {
            get => _Dto.CategorieId;
            set
            {
                _Dto.CategorieId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual CategoriePoco CategoriePoco
        {
            get => _Dto.CategorieDto.ToPoco<CategorieDto, CategoriePoco>();
            set
            {
                _Dto.CategorieDto = value.GetDto();
                NotifyPropertyChanged();
            }
        }

        //public virtual Collection<InWorldPoco<InWorldDto>> InWorldsPoco
        //    => _Dto.InWorldsDto.ToPocoCollection<InWorldDto, InWorldPoco<InWorldDto>>();
    }
}
