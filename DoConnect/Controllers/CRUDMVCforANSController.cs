using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DoConnect.Controllers
{
    public class CRUDMVCforANSController : Controller
    {
        // GET: CRUDMVCforANS

        HttpClient client = new HttpClient();
        //Display CRUD Operation buttons to perform on Answer...........................

        public ActionResult Index()
        {
            List<Answer> list = new List<Answer>();
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.GetAsync("CRUDAPIforANS");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Answer>>();
                display.Wait();
                list = display.Result;

            }
            return View(list);

        }

        // Create on Answers....................................................
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Answer e)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.PostAsJsonAsync<Answer>("CRUDAPIforANS", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Create");

            }
            return View();
        }

        //Details of Answer.....................................................
        public ActionResult Details(int id)
        {
            Answer e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.GetAsync("CRUDAPIforANS?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Answer>();
                display.Wait();
                e = display.Result;
            }



            return View(e);
        }

        //Editing the Answer Data.................................................
        public ActionResult Edit(int id)
        {
            Answer e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.GetAsync("CRUDAPIforANS?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Answer>();
                display.Wait();
                e = display.Result;

            }
            return View(e);

        }
        [HttpPost]
        public ActionResult Edit(Answer e)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.PutAsJsonAsync<Answer>("CRUDAPIforANS", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }


        //Deleting of Answer Data.................................................
        public ActionResult Delete(int id)
        {
            Answer e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.GetAsync("CRUDAPIforANS?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Answer>();
                display.Wait();
                e = display.Result;

            }

            return View(e);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforANS");
            var response = client.DeleteAsync("CRUDAPIforANS/" + id.ToString());
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