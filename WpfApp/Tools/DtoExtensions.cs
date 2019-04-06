using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto.Interfaces;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Tools
{
    public static class DtoExtensions
    {
        public static TPoco ToPoco<TDto, TPoco>(this TDto dto)
            where TPoco : IPoco<TDto>, new()
            where TDto : class
        {
            TPoco poco = new TPoco();
            poco.SetDto(dto);
            return poco;
        }
    }
}
