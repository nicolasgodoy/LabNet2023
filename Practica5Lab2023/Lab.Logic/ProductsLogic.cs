using Lab.Data;
using Lab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Logic
{
    public class ProductsLogic : BaseLogic
    {
        // 2. METHOD SINTAX
        public List<Products> GetProductSinStock()
        {
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();

        }

        // 3. METHOD SINTAX
        public List<Products> GetProductStock()
        {
            return context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();

        }

        // 5. QUERY SINTAX
        public Products GetProductsOrNull()
        {
            var result = from p in context.Products
                         where p.ProductID == 789
                         select p;
            return result.FirstOrDefault();

        }

        // 9. METHOD SINTAX
        public List<Products> GetProductsOrderByName()
        {
           
           return context.Products.OrderBy(p=>p.ProductName).ToList();

        }
    }
}
