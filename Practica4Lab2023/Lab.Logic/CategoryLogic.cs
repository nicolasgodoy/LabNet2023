using Lab.Entities;
using Lab.Logic.Interfaces;
using System.Collections.Generic;
using System.Linq;



namespace Lab.Logic
{
    public class CategoryLogic : BaseLogic, IABMLogic<Categories>
    {
        // ===== Comentario no llegue a ingresar los datos de esta entidad por Teclado y validaciones pero queria que quede implementada almenos  ===== //
        public void Add(Categories newCategories)
        {
            context.Categories.Add(newCategories);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            int idCategory = int.Parse(id);
            var categoryDelete = context.Categories.First(n => n.CategoryID == idCategory);
            context.Categories.Remove(categoryDelete);
            context.SaveChanges();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Update(Categories category)
        {
            var categoryUpdate = context.Categories.Find(category.CategoryID);
            categoryUpdate.CategoryID = category.CategoryID;
            categoryUpdate.CategoryName = category.CategoryName;
            categoryUpdate.Description = category.Description;
            categoryUpdate.Picture = category.Picture;
            context.SaveChanges();
        }
    }
}
