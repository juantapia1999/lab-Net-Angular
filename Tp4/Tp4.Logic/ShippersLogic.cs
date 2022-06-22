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
            try
            {
                return context.Shippers.OrderByDescending(s => s.ShipperID).First().ShipperID;
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
                return context.Shippers.Find(id) != null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Add(Shippers obj)
        {
            try
            {
                context.Shippers.Add(obj);
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
                var shipperDelete = context.Shippers.Find(id);
                context.Shippers.Remove(shipperDelete);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Shippers FindOne(int id)
        {
            try
            {
                return context.Shippers.Find(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Shippers> GetAll()
        {
            try
            {
                return context.Shippers.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Shippers obj)
        {
            try
            {
                var shipperUpdate = context.Shippers.Find(obj.ShipperID);
                shipperUpdate.Phone = obj.Phone != "-" ? obj.Phone : shipperUpdate.Phone;
                shipperUpdate.CompanyName = obj.CompanyName != "" ? obj.CompanyName : shipperUpdate.CompanyName;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
