using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;
using WpfApp.Model.Dto.Interfaces;

namespace WpfApp.Model.Poco
{
    public abstract class CommunPoco<TDto> : BasePoco<TDto>
        where TDto : ICommunDto
    {
        public string Nom
        {
            get => _Dto.Nom;
            set
            {
                if (value != _Dto.Nom)
                {
                    _Dto.Nom = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get => _Dto.IsActive;
            set
            {
                if (value != _Dto.IsActive)
                {
                    _Dto.IsActive = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
