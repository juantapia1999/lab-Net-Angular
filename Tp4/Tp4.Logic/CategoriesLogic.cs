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
            try
            {
                return context.Categories.OrderByDescending(c => c.CategoryID).First().CategoryID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Exist(int id)
        {
            try
            {
                return context.Categories.Find(id) != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Add(Categories obj)
        {
            try
            {
                context.Categories.Add(obj);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var categoryDelete = context.Categories.Find(id);
                context.Categories.Remove(categoryDelete);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Categories FindOne(int id)
        {
            try
            {
                return context.Categories.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Categories> GetAll()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Categories obj)
        {
            try
            {
                var categoryUpdate = context.Categories.Find(obj.CategoryID);
                categoryUpdate.CategoryName = obj.CategoryName != "" ? obj.CategoryName : categoryUpdate.CategoryName;
                categoryUpdate.Description = obj.Description != "-" ? obj.Description : categoryUpdate.Description;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
