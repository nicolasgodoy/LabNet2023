using Lab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic.Interfaces
{
    interface IABMLogic<T>
    {

        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
