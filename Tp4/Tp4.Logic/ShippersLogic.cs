using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp4.Entities;

namespace Tp4.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {
        public int FindLastIndex()
        {
            return context.Shippers.OrderByDescending(s => s.ShipperID).First().ShipperID;
        }

        public bool Exist(int id)
        {
            return context.Shippers.Find(id) != null;
        }
        public void Add(Shippers obj)
        {
            context.Shippers.Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shipperDelete = context.Shippers.Find(id);
            context.Shippers.Remove(shipperDelete);
            context.SaveChanges();
        }

        public Shippers FindOne(int id)
        {
            return context.Shippers.Find(id);
        }

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public void Update(Shippers obj)
        {
            var shipperUpdate = context.Shippers.Find(obj.ShipperID);
            shipperUpdate.Phone = obj.Phone != "-" ? obj.Phone : shipperUpdate.Phone;
            shipperUpdate.CompanyName = obj.CompanyName != "" ? obj.CompanyName : shipperUpdate.CompanyName;
            context.SaveChanges();
        }
    }
}
