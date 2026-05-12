using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DoConnect.Controllers
{
    public class QuestionAPIController : Controller
    {
        // GET: QuestionAPI
        HttpClient client = new HttpClient();
        [HttpGet]
        public ActionResult Index()
        {
           
                List<Question> que_list = new List<Question>();
                client.BaseAddress = new Uri("http://localhost:50669/api/Question");
                var response = client.GetAsync("Question");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<Question>>();
                    display.Wait();
                    que_list = display.Result;
                }
                return View(que_list);
            
            //{
            //    IEnumerable<Question> questions = null;

            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri("http://localhost:64189/api/");
            //        //HTTP GET
            //        var responseTask = client.GetAsync("student");
            //        responseTask.Wait();
            //        return View();
            //    }
        }

        // GET: QuestionAPI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionAPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionAPI/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionAPI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionAPI/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionAPI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionAPI/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
