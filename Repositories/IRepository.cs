using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgiKutuphanesiWebApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> books);

        T GetById(int id);

        int Count(Func<T, bool> books);
    }
}
