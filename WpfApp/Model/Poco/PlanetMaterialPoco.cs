using WpfApp.Model.Dto;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Model.Poco
{
    public class PlanetMaterialPoco : BasePoco<PlanetMaterialDto>
    {
        public int PlanetId
        {
            get => _Dto.PlanetId;
            set
            {
                if (value != _Dto.PlanetId)
                {
                    _Dto.PlanetId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public PlanetDto Planet
        {
            get => _Dto.Planet;
            set
            {
                if (value != _Dto.Planet)
                {
                    _Dto.Planet = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int MaterialId
        {
            get => _Dto.MaterialId;
            set
            {
                if (value != _Dto.MaterialId)
                {
                    _Dto.MaterialId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public MaterialDto Material
        {
            get => _Dto.Material;
            set
            {
                if (value != _Dto.Material)
                {
                    _Dto.Material = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
