using Lab.Data;
using Lab.Entities;
using Lab.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    public class CategoryLogic : BaseLogic, IABMLogic<Categories>
    {
        public void Add(Categories newCategories)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Update(Categories newCategories)
        {
            throw new NotImplementedException();
        }
    }
}
