using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;
using WpfApp.Model.Dto.Interfaces;
using WpfApp.Model.Poco;
using WpfApp.Model.Poco.Interfaces;

namespace WpfApp.Tools
{
    public static class CollectionExtensions
    {
        public static Collection<TPoco> ToPocoCollection<TDto, TPoco>(this ICollection<TDto> dtos)
            where TPoco : IPoco<TDto>, new()
            where TDto : class
        {
            Collection<TPoco> pocos = new Collection<TPoco>();
            TPoco poco;
            foreach (var dto in dtos)
            {
                poco = new TPoco();
                poco.SetDto(dto);
                pocos.Add(poco);
            }
            return pocos;

        }
    }
}
