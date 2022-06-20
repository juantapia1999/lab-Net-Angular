using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp4.Entities;
using Tp4.Logic;
using Tp7.MVC.Models.FormViewModel;
using Tp7.MVC.Models.TableViewModel;

namespace Tp7.MVC.Controllers
{
    public class ShipperController : Controller
    {
        [HttpGet]
        public ActionResult Index(string message)
        {
            ViewBag.ErrorMessage = message;
            List<ShipperView> shippers = new List<ShipperView>();
            try
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                shippers = shippersLogic.GetAll().Select(
                    s => new ShipperView
                    {
                        ShipperID = s.ShipperID,
                        CompanyName = s.CompanyName,
                        Phone = s.Phone
                    }).ToList();
                return View(shippers);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage += " - " + e.Message;
                return View(shippers);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ShipperFormModel form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ShippersLogic shippersLogic = new ShippersLogic();
                    int nuevoId = shippersLogic.FindLastIndex() + 1;
                    shippersLogic.Add(new Shippers
                    {
                        CompanyName = form.CompanyName,
                        Phone = form.Phone,
                        ShipperID = nuevoId
                    });
                    return RedirectToAction("Index");
                }
                catch (InvalidOperationException i)
                {
                    ViewBag.ErrorMessage = i.Message;
                    return View(form);
                }
                catch (ArgumentNullException a)
                {
                    ViewBag.ErrorMessage = a.Message;
                    return View(form);
                }
                catch (DbEntityValidationException db)
                {
                    ViewBag.ErrorMessage = GetErrorMessageDataBase(db);
                    return View(form);
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    return View(form);
                }
            }
            else
            {
                return View(form);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                var find = shippersLogic.FindOne(id);
                if (find != null)
                {
                    ShipperFormModel form = new ShipperFormModel
                    {
                        ShipperID = find.ShipperID,
                        CompanyName = find.CompanyName,
                        Phone = find.Phone
                    };
                    return View(form);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ShipperFormModel form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ShippersLogic shippersLogic = new ShippersLogic();
                    var find = shippersLogic.FindOne((int)form.ShipperID);
                    if (find != null)
                    {
                        shippersLogic.Update(new Shippers
                        {
                            ShipperID = (int)form.ShipperID,
                            CompanyName = form.CompanyName,
                            Phone = form.Phone
                        });
                        ViewBag.Message = "Se ha editado con exito";
                        return View(form);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (DbEntityValidationException db)
                {
                    ViewBag.ErrorMessage = GetErrorMessageDataBase(db);
                    return View(form);
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    return View(form);
                }
            }
            else
            {
                return View(form);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ShippersLogic shippersLogic = new ShippersLogic();
                if (shippersLogic.Exist(id))
                {
                    shippersLogic.Delete(id);
                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet]
        public ActionResult CreateOrEdit(int? id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                ViewBag.Action = "Agregar Expedidor";
                return View();
            }
            else
            {
                try
                {
                    ShippersLogic shippersLogic = new ShippersLogic();
                    var find = shippersLogic.FindOne((int)id);
                    if (find != null)
                    {
                        ShipperFormModel form = new ShipperFormModel
                        {
                            ShipperID = find.ShipperID,
                            CompanyName = find.CompanyName,
                            Phone = find.Phone
                        };
                        ViewBag.Action = "Editar Expedidor";
                        return View(form);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    return RedirectToAction("Index", new { message = e.Message });
                }
            }
        }


        [HttpPost]
        public ActionResult CreateOrEdit(ShipperFormModel form)
        {
            if (form.ShipperID != null)
            {
                ViewBag.Action = "Editar Expedidor";
                if (ModelState.IsValid)
                {
                    try
                    {
                        ShippersLogic shippersLogic = new ShippersLogic();
                        var find = shippersLogic.FindOne((int)form.ShipperID);
                        if (find != null)
                        {
                            shippersLogic.Update(new Shippers
                            {
                                ShipperID = (int)form.ShipperID,
                                CompanyName = form.CompanyName,
                                Phone = form.Phone
                            });
                            ViewBag.Message = "Se ha editado con exito";
                            return View(form);
                        }
                        else
                        {
                            return RedirectToAction("Index", new { message= "No se encontro el expedidor"});
                        }
                    }
                    catch (DbEntityValidationException db)
                    {
                        ViewBag.ErrorMessage = GetErrorMessageDataBase(db);
                        return View(form);
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErrorMessage = e.Message;
                        return View(form);
                    }
                }
                else
                {
                    return View(form);
                }
            }
            else
            {
                ViewBag.Action = "Agregar Expedidor";
                if (ModelState.IsValid)
                {
                    try
                    {
                        ShippersLogic shippersLogic = new ShippersLogic();
                        int nuevoId = shippersLogic.FindLastIndex() + 1;
                        shippersLogic.Add(new Shippers
                        {
                            CompanyName = form.CompanyName,
                            Phone = form.Phone,
                            ShipperID = nuevoId
                        });
                        return RedirectToAction("Index");
                    }
                    catch (InvalidOperationException i)
                    {
                        ViewBag.ErrorMessage = i.Message;
                        return View(form);
                    }
                    catch (ArgumentNullException a)
                    {
                        ViewBag.ErrorMessage = a.Message;
                        return View(form);
                    }
                    catch (DbEntityValidationException db)
                    {
                        ViewBag.ErrorMessage = GetErrorMessageDataBase(db);
                        return View(form);
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErrorMessage = e.Message;
                        return View(form);
                    }
                }
                else
                {
                    return View(form);
                }
            }
        }

        private string GetErrorMessageDataBase(DbEntityValidationException db)
        {
            string message = "";
            foreach (var errors in db.EntityValidationErrors)
            {
                foreach (var validationError in errors.ValidationErrors)
                {
                    message = validationError.ErrorMessage + " - ";
                }
            }
            return message;
        }
    }
}