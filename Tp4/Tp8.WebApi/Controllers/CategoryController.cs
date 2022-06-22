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
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            try
            {
                IEnumerable<CategoryModel> list = categoriesLogic.GetAll().Select(
                c => new CategoryModel
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description
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
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            try
            {
                var find = categoriesLogic.FindOne(id);
                if (find != null)
                {
                    CategoryModel category = new CategoryModel
                    {
                        CategoryID = find.CategoryID,
                        Description = find.Description,
                        CategoryName = find.CategoryName
                    };
                    return Ok(category);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, new { message = "No se encontro la categoria" });
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] CategoryModel data)
        {
            try
            {
                CategoriesLogic categoriesLogic = new CategoriesLogic();
                data.CategoryID = categoriesLogic.FindLastIndex() + 1;
                if (ModelState.IsValid)
                {
                    categoriesLogic.Add(new Categories
                    {
                        CategoryName = data.CategoryName,
                        Description = data.Description,
                        CategoryID = data.CategoryID
                    });
                    return Content(HttpStatusCode.Created, new { message = "Categoria creada" });
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
        public IHttpActionResult Put(int id, [FromBody] CategoryModel data)
        {
            try
            {
                CategoriesLogic categoriesLogic = new CategoriesLogic();
                data.CategoryID = id;
                if (ModelState.IsValid)
                {
                    var find = categoriesLogic.FindOne(data.CategoryID);
                    if (find != null)
                    {
                        categoriesLogic.Update(new Categories
                        {
                            CategoryID = data.CategoryID,
                            CategoryName = data.CategoryName,
                            Description = data.Description
                        });
                        return Content(HttpStatusCode.OK, new { message = "Categoria actualizada" });
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, new { message = "No se encontro la categoria" });
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
                CategoriesLogic categoriesLogic = new CategoriesLogic();
                if (categoriesLogic.Exist(id))
                {
                    categoriesLogic.Delete(id);
                    return Content(HttpStatusCode.OK, new { message = "Categoria eliminada" });
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, new { message = "Categoria no encontrada" });
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}