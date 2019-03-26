using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCodeFisrtTPT.Repositories.Interfaces
{
    public interface ICommunRepository<T> : IRepository<T>
        where T : class, new()
    {
        T GetByNom(string nom);
    }
}
