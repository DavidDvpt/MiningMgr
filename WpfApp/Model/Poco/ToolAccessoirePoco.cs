using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class ToolAccessoirePoco : BasePoco<ToolAccessoireDto>
    {
        public int ToolId
        {
            get => _Dto.ToolId;
            set
            {
                if (value != _Dto.ToolId)
                {
                    _Dto.ToolId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ModeleDto Tool
        {
            get => _Dto.Tool;
            set
            {
                if (value != _Dto.Tool)
                {
                    _Dto.Tool = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int AccessoireId
        {
            get => _Dto.AccessoireId;
            set
            {
                if (value != _Dto.AccessoireId)
                {
                    _Dto.AccessoireId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ModeleDto Accessoire
        {
            get => _Dto.Accessoire;
            set
            {
                if (value != _Dto.Accessoire)
                {
                    _Dto.Accessoire = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
