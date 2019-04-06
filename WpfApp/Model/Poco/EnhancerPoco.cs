using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    public class EnhancerPoco : InWorldPoco<EnhancerDto>
    {
        public byte Slot
        {
            get => _Dto.Slot;
            set
            {
                if (value != _Dto.Slot)
                {
                    _Dto.Slot = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal BonusValue1
        {
            get => _Dto.BonusValue1;
            set
            {
                if (value != _Dto.BonusValue1)
                {
                    _Dto.BonusValue1 = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal BonusValue2
        {
            get => _Dto.BonusValue2;
            set
            {
                if (value != _Dto.BonusValue2)
                {
                    _Dto.BonusValue2 = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
