using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Tp8.WebApi.Models;

namespace Tp8.WebApi.Controllers
{
    public class DigimonController : Controller
    {
        // GET: Digimon
        public ActionResult Index()
        {
            List<DigimonModelView> digimonModelViews = new List<DigimonModelView>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://digimon-api.vercel.app/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var responseTask = client.GetAsync("api/digimon");
                    responseTask.Wait();
                    var response = responseTask.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJsonString = response.Content.ReadAsStringAsync();
                        resultJsonString.Wait();
                        var deserialized = JsonConvert.DeserializeObject<IEnumerable<DigimonModelView>>(resultJsonString.Result);
                        foreach (var item in deserialized)
                        {
                            digimonModelViews.Add(new DigimonModelView { Img = item.Img, Name = item.Name, Level = item.Level });
                        }
                    }
                }
                return View(digimonModelViews);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(digimonModelViews);
            }
        }
    }
}