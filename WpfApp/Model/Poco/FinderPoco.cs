using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model.Dto;

namespace WpfApp.Model.Poco
{
    class FinderPoco : IPoco<FinderDto>
    {
        public FinderDto Dto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
