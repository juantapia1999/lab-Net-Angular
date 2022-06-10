using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp4.Entities;

namespace Tp4.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        public int FindLastIndex()
        {
            return context.Categories.OrderByDescending(c => c.CategoryID).First().CategoryID;
        }

        public bool Exist(int id)
        {
            return context.Categories.Find(id) != null;
        }
        public void Add(Categories obj)
        {
            context.Categories.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryDelete = context.Categories.Find(id);
            context.Categories.Remove(categoryDelete);
            context.SaveChanges();

        }

        public Categories FindOne(int id)
        {
            return context.Categories.Find(id);
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Update(Categories obj)
        {
            var categoryUpdate = context.Categories.Find(obj.CategoryID);
            categoryUpdate.CategoryName = obj.CategoryName != "" ? obj.CategoryName : categoryUpdate.CategoryName;
            categoryUpdate.Description = obj.Description != "-" ? obj.Description : categoryUpdate.Description;
            context.SaveChanges();
        }
    }
}
