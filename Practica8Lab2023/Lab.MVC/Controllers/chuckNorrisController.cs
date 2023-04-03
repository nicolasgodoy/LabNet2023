using Lab.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class ChuckNorrisController : Controller
    {
        // GET: Chuck Norris

        public ActionResult Index()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = httpClient.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
                ChuckNorris chuckNorris = JsonConvert.DeserializeObject<ChuckNorris>(json);

                ChuckNorrisViewModel chuckNorrisViewModel = new ChuckNorrisViewModel();

                chuckNorrisViewModel.Id = chuckNorris.id;
                chuckNorrisViewModel.Created_At = chuckNorris.created_at.ToString("dd/MM/yyyy");
                chuckNorrisViewModel.Value = chuckNorris.value;

                return View(chuckNorrisViewModel);
            }
            catch (Exception ex)
            {
                return View(new List<ChuckNorrisViewModel>());
            }
            
        }
    }
}