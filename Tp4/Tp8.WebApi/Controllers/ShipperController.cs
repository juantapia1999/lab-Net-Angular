using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tp4.Entities;
using Tp4.Logic;
using Tp8.WebApi.Models;

namespace Tp8.WebApi.Controllers
{
    public class ShipperController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            ShippersLogic shippersLogic = new ShippersLogic();
            try
            {
                IEnumerable<ShipperModel> list = shippersLogic.GetAll().Select(
                s => new ShipperModel
                {
                    ShipperID = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone
                }).AsEnumerable();
                return Ok(list);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            ShippersLogic shippersLogic = new ShippersLogic();
            try
            {
                var find = shippersLogic.FindOne(id);
                if (find != null)
                {
                    ShipperModel shipper = new ShipperModel
                    {
                        CompanyName = find.CompanyName,
                        Phone = find.Phone,
                        ShipperID = find.ShipperID
                    };
                    return Ok(shipper);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, new { message = "No se encontro el expedidor" });
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] ShipperModel data)
        {
            try
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                data.ShipperID = shippersLogic.FindLastIndex() + 1;
                if (ModelState.IsValid)
                {
                    shippersLogic.Add(new Shippers
                    {
                        CompanyName = data.CompanyName,
                        Phone = data.Phone,
                        ShipperID = data.ShipperID
                    });
                    return Content(HttpStatusCode.Created, new { message = "Expedidor creado" });
                }
                else
                {
                    var errors = ModelState.SelectMany(x => x.Value.Errors).Select(y => y.ErrorMessage).ToList();
                    return Content(HttpStatusCode.BadRequest, new { message = "Hay errores en los datos", errors });
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] ShipperModel data)
        {
            try
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                data.ShipperID = id;
                if (ModelState.IsValid)
                {
                    var find = shippersLogic.FindOne(data.ShipperID);
                    if (find != null)
                    {
                        shippersLogic.Update(new Shippers
                        {
                            ShipperID = data.ShipperID,
                            CompanyName = data.CompanyName,
                            Phone = data.Phone
                        });
                        return Content(HttpStatusCode.OK, new { message = "Expedidor actualizado" });
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, new { message = "No se encontro el expedidor" });
                    }
                }
                else
                {
                    var errors = ModelState.SelectMany(x => x.Value.Errors).Select(y => y.ErrorMessage).ToList();
                    return Content(HttpStatusCode.BadRequest, new { message = "Hay errores en los datos", errors });
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                if (shippersLogic.Exist(id))
                {
                    shippersLogic.Delete(id);
                    return Content(HttpStatusCode.OK, new { message = "Expedidor eliminado" });
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, new { message = "Expedidor no encontrado" });
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}