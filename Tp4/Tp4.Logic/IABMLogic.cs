using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp4.Logic
{
    interface IABMLogic<T>
    {
        List<T> GetAll();
        T FindOne(int id);
        void Add(T obj);
        void Delete(int id);
        void Update(T obj);

    }
}
