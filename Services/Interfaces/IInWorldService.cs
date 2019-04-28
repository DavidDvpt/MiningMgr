using Model;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IInWorldService<T> : ICommunService<T>
        where T : class, new()
    {

    }
}
