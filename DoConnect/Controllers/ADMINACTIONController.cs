using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoConnect.Controllers
{
    public class ADMINACTIONController : Controller
    {
        // GET: ADMINACTION

        DOCONNECT2DBEntities2 k = new DOCONNECT2DBEntities2();

        //User Login Code.........................................
        public ActionResult adminlogin()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult adminlogin(ADMINTABLE l)
        {
            if (k.ADMINTABLEs.Any(x => x.Username == l.Username) && (k.ADMINTABLEs.Any(x => x.Password == l.Password)))
            {

                k.ADMINTABLEs.Add(l);
                Session["Username"] = l.Username.ToString();
                Session["Password"] = l.Password.ToString();

                return RedirectToAction("adminwelcome");

            }
            else 
            {
                ViewBag.Notification = "Invalid UserName or Password";
            }
            return View();
        }

        //Displaying buttons for CRUD operations on user, answers, questions.......................
        
        public ActionResult adminwelcome()
        { 
        
            return View();
        }

        public ActionResult movetouser()
        {
            return RedirectToAction("Index", "USERACTION");
        }

        //User Logout code...................................................
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("adminlogin", "ADMINACTION");
        }
    }
}