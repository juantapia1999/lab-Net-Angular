using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp5.Entities
{
    public class CustomersAndOrders
    {
        public string CustomerID { get; set; }  
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }



        public int OrderID { get; set; }     
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }    
        public string ShipName { get; set; }      
  
        public string ShipRegion { get; set; }         
        public string ShipCountry { get; set; }
    }
}
