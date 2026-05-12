using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoConnect.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        DOCONNECT2DBEntities2 db = new DOCONNECT2DBEntities2();



        //searching of question based on string........................................

        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            var users = db.Questions.ToList();
            switch (SortBy)
            {
                case "Id":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    users = users.OrderBy(x => x.Id).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    users = users.OrderByDescending(x => x.Id).ToList();
                                    break;
                                }
                            default:
                                {
                                    users = users.OrderBy(x => x.Id).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "Question1":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    users = users.OrderBy(x => x.Question1).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    users = users.OrderByDescending(x => x.Question1).ToList();
                                    break;
                                }
                            default:
                                {
                                    users = users.OrderBy(x => x.Question1).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                case "Category":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    users = users.OrderBy(x => x.Category).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    users = users.OrderByDescending(x => x.Category).ToList();
                                    break;
                                }
                            default:
                                {
                                    users = users.OrderBy(x => x.Category).ToList();
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        users = users.OrderBy(x => x.Category).ToList();
                        break;
                    }
                case "UserName":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    users = users.OrderBy(x => x.Question1).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    users = users.OrderByDescending(x => x.UserName).ToList();
                                    break;
                                }
                            default:
                                {
                                    users = users.OrderBy(x => x.UserName).ToList();
                                    break;
                                }
                        }
                        break;
                    }
            }

            return View(users);
        }
        [HttpPost]
        public ActionResult Index(string searchTxt)
        {
            var users = db.Questions.ToList();
            if (searchTxt != null)
            {
                users = db.Questions.Where(x => x.Question1.Contains(searchTxt) || x.Category.Contains(searchTxt) || x.UserName.Contains(searchTxt)).ToList();
            }
            return View(users);

            //    public ActionResult Index()
            //{

            //    return View();
            //}
        }
    }
}