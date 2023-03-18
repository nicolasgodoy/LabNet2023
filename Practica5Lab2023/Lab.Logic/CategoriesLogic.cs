using Lab.Data;
using Lab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    public class CategoriesLogic : BaseLogic
    {
        // No pude hacerlo andar por error de tipo de dato con el DISTINCT
        public List<Categories> GetCategoriesWidthProducts()
        {
            var result = from c in context.Categories
                         join p in context.Products on c.CategoryID equals p.CategoryID
                         select c;

            return result.Distinct().ToList();

        }
    }
}
