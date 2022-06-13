using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Entities;

namespace Tp5.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> GetAllFilteredByUnitPrice()
        {
            return context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
        }

        public List<Products> GetAllWithoutStock()
        {
            var listFiltered = from p in context.Products where p.UnitsInStock == 0 select p;
            return listFiltered.ToList();
        }

        public Products GetFirstById(int id)
        {
            return context.Products.Where(p => p.ProductID == id).First();
        }
    }
}
