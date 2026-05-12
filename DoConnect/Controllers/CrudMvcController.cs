using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DoConnect.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
       
        HttpClient client = new HttpClient();
        //Display CRUD Operation buttons to perform on Questions...........................

        public ActionResult Index()
        {
            List<Question> list = new List<Question>();
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.GetAsync("CRUDAPI");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Question>>();
                display.Wait();
                list = display.Result;

            }
            return View(list);

        }

        // Create on Questions....................................................
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Question e)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.PostAsJsonAsync<Question>("CRUDAPI", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
               
            }
            return View("Create");
        }


        //Details of Questions.....................................................
        public ActionResult Details(int id)
        {
            Question e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.GetAsync("CRUDAPI?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Question>();
                display.Wait();
                e = display.Result;
            }



            return View(e);
        }

        //Editing the Questions Data.................................................
        public ActionResult Edit(int id)
        {
            Question e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.GetAsync("CRUDAPI?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Question>();
                display.Wait();
                e = display.Result;

            }
            return View(e);

        }
        [HttpPost]
        public ActionResult Edit(Question e)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.PutAsJsonAsync<Question>("CRUDAPI", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }


        //Deleting of Questions Data.................................................
        public ActionResult Delete(int id)
        {
            Question e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.GetAsync("CRUDAPI?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Question>();
                display.Wait();
                e = display.Result;

            }

            return View(e);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CrudApi");
            var response = client.DeleteAsync("CRUDAPI/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
                

            }
            return View("Edit");
        }
    }
}