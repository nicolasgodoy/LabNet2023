using System.Collections.Generic;

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
