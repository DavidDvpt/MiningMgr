using System.Collections.Generic;
using System.Linq;

namespace Services.Interfaces
{
    public interface ICommunService<T> : IBaseService<T>
        where T : class, new()
    {

        T GetByNom(string nom);
    }
}
