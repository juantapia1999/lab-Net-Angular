using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Entities;

namespace Tp5.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public Customers GetById(string id)
        {
            return context.Customers.Find(id.ToUpper());
        }

        public List<Customers> GetAllFilteredByRegion()
        {
            return context.Customers.Where(c => c.Region.Equals("WA")).ToList();
        }

        public List<string> GetAllName(bool uppercase)
        {
            var allName = uppercase ? (from c in context.Customers select c.ContactName.ToUpper()) : (from c in context.Customers select c.ContactName.ToLower());
            return allName.ToList();
        }

        public List<CustomersAndOrders> GetAllJoinWithOrdersByRegionAndDate()
        {
            var listFiltered = (from c in context.Customers
                                join o in context.Orders on c.CustomerID equals o.CustomerID
                                where c.Region.Equals("WA") && o.OrderDate > new DateTime(1997, 1, 1)
                                select new CustomersAndOrders
                                {
                                    CustomerID = c.CustomerID,
                                    CompanyName = c.CompanyName,
                                    ContactName = c.ContactName,
                                    Address = c.Address,
                                    City = c.City,
                                    Region = c.Region,
                                    Country = c.Country,
                                    OrderID = o.OrderID,
                                    OrderDate = o.OrderDate,
                                    RequiredDate = o.RequiredDate,
                                    ShippedDate = o.ShippedDate,
                                    ShipCountry = o.ShipCountry,
                                    ShipName = o.ShipName,
                                    ShipRegion = o.ShipRegion
                                }
                                );
            return listFiltered.ToList();
        }

        public List<CountCustomerOrder> GetAllCountAndJoinWithOrdersByRegionAndDate()
        {
            var listFiltered = (
                from c in context.Customers
                join o in context.Orders on c.CustomerID equals o.CustomerID                
                where c.Region.Equals("WA") && o.OrderDate > new DateTime(1997, 1, 1)     
                group c by c into g             
                select new CountCustomerOrder
                {
                    Customers1 = g.Key,
                    Orders1= g.Key.Orders.Where(a=>a.OrderDate> new DateTime(1997, 1, 1)),
                    CountOrder=g.Count()
                }
                );
            return listFiltered.ToList();
        }
    }
    public class CountCustomerOrder
    {

        public virtual Customers Customers1 { get; set; }
        public virtual IEnumerable<Orders> Orders1 { get; set; }
        public int CountOrder { get; set; }
    }
}
