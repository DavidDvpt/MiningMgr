using System.Collections.ObjectModel;
using WpfApp.Model.Dto;
using WpfApp.Tools;

namespace WpfApp.Model.Poco
{
    public class CategoriePoco : CommunPoco<CategorieDto>
    {
        public Collection<ModelePoco> ModelesPoco => _Dto.ModelesDto.ToPocoCollection<ModeleDto, ModelePoco>();
    }

}
