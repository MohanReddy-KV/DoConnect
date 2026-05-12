using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DoConnect.Controllers
{
    public class CRUDMVCforUSERController : Controller
    {
        // GET: CRUDMVCforUSER


        HttpClient client = new HttpClient();
        //Display CRUD Operation buttons to perform on user...........................
        public ActionResult Index()
        {
            List<USERTABLE> list = new List<USERTABLE>();
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.GetAsync("CRUDAPIforUSER");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<USERTABLE>>();
                display.Wait();
                list = display.Result;

            }
            return View(list);

        }

        // Create on User....................................................
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(USERTABLE e)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.PostAsJsonAsync<USERTABLE>("CRUDAPIforUSER", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Create");
        }

        //Details of User.....................................................
        public ActionResult Details(int id)
        {
            USERTABLE e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.GetAsync("CRUDAPIforUSER?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<USERTABLE>();
                display.Wait();
                e = display.Result;
            }



            return View(e);
        }

        //Editing the User Data.................................................
        public ActionResult Edit(int id)
        {
            USERTABLE e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.GetAsync("CRUDAPIforUSER?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<USERTABLE>();
                display.Wait();
                e = display.Result;

            }
            return View(e);

        }
        [HttpPost]
        public ActionResult Edit(USERTABLE e)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.PutAsJsonAsync<USERTABLE>("CRUDAPIforUSER", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        //Deleting of User Data.................................................
        public ActionResult Delete(int id)
        {
            USERTABLE e = null;
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.GetAsync("CRUDAPIforUSER?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<USERTABLE>();
                display.Wait();
                e = display.Result;

            }

            return View(e);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            client.BaseAddress = new Uri("http://localhost:50669/api/CRUDAPIforUSER");
            var response = client.DeleteAsync("CRUDAPIforUSER/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");


            }
            return View("Edit");
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}