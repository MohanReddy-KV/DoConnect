using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DoConnect.Controllers
{
    public class USERACTIONController : Controller
    {
        // GET: USERACTION

        DOCONNECT2DBEntities2 omr = new DOCONNECT2DBEntities2();

        //User Login Code.........................................
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Index(USERTABLE l)
        {
            if (omr.USERTABLEs.Any(x => x.Username == l.Username) && (omr.USERTABLEs.Any(x => x.Password == l.Password)))
            {
                omr.USERTABLEs.Add(l);
                Session["Username"] = l.Username.ToString();
                Session["Password"] = l.Password.ToString();

                return RedirectToAction("Detail");
            }
            else
            {
                ViewBag.Notification = "Invalid Username or Password";
            }

            return View();
        }

        //Asking a Question Code.........................................
        public ActionResult Detail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Detail(Question l)
        {


            omr.Questions.Add(l);
            omr.SaveChanges();
            Session["Text"] = l.Question1.ToString();
            Session["Id"] = l.Id.ToString();
            Session["Category"] = l.Category.ToString();
            Session["UserId"] = l.UserName;


            return View();
        }

        //Displaying the questions Code..................................
        public ActionResult answer()
        {
            return View();
        }
        
        public ActionResult Answerdaquestion()
        {
            List<Question> l = omr.Questions.ToList();
            return View(l);
            
        }
        public ActionResult Move()
        {
            return RedirectToAction("adminlogin", "ADMINACTION");
        }


        //User Signup Code.........................................
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(USERTABLE l)
        {
            if (omr.USERTABLEs.Any(x => x.Username == l.Username) && omr.USERTABLEs.Any(x => x.Password == l.Password))
            {
                ViewBag.Notification = "account already exist";
                Console.WriteLine("already exist");

            }
            else if (l.Password != l.Password)
            {
                ViewBag.Notification = "password is not match";
            }
            else
            {
                omr.USERTABLEs.Add(l);
                omr.SaveChanges();
                

            }
            return View();
        }


        //User Logout Code.........................................
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "USERACTION");
        }
      
    }
}