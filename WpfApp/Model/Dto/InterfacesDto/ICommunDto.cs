using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model.Dto.Interfaces
{
    public interface ICommunDto
    {
        string Nom { get; set; }
        bool IsActive { get; set; }
    }
}
