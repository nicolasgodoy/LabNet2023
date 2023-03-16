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
        void Add(T newCustomer);
        void Update(T newCustomer);
        void Delete(string id);
    }
}
