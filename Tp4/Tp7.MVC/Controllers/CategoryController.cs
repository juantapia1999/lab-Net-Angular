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
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<CategoryView> categories = new List<CategoryView>();
            try
            {
                CategoriesLogic categoriesLogic = new CategoriesLogic();
                categories = categoriesLogic.GetAll().Select(
                   c => new CategoryView
                   {
                       CategoryID = c.CategoryID,
                       CategoryName = c.CategoryName,
                       Description = c.Description
                   }).ToList();
                return View(categories);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(categories);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryFormModel form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    int nuevoId = categoriesLogic.FindLastIndex() + 1;
                    categoriesLogic.Add(new Categories
                    {
                        CategoryID = nuevoId,
                        CategoryName = form.CategoryName,
                        Description = form.Description
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
                CategoriesLogic categoriesLogic = new CategoriesLogic();
                var find = categoriesLogic.FindOne(id);
                if (find != null)
                {
                    CategoryFormModel form = new CategoryFormModel
                    {
                        CategoryID = find.CategoryID,
                        CategoryName = find.CategoryName,
                        Description = find.Description
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
        public ActionResult Edit(CategoryFormModel form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoriesLogic categoriesLogic = new CategoriesLogic();
                    var find = categoriesLogic.FindOne((int)form.CategoryID);
                    if (find != null)
                    {
                        categoriesLogic.Update(new Categories
                        {
                            CategoryID = (int)form.CategoryID,
                            CategoryName = form.CategoryName,
                            Description = form.Description
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
                CategoriesLogic categoriesLogic = new CategoriesLogic();
                if (categoriesLogic.Exist(id))
                {
                    categoriesLogic.Delete(id);
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