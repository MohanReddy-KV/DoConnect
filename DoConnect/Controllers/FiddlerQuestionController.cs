using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoConnect.Controllers
{
    public class FiddlerQuestionController : ApiController
    {

        DOCONNECT2DBEntities2 k = new DOCONNECT2DBEntities2();
        public List<Question> GetAllEmployees()
        {
            return k.Questions.ToList();
        }
        [HttpPost]
        public string AddEmployee(Question em)
        {
            k.Questions.Add(em);
            k.SaveChanges();
            return "Question Added Successfully";
        }
        [HttpPut]
        public IHttpActionResult Empupdate(Question e)
        {
            var emp = k.Questions.Where(model => model.Id == e.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Id = e.Id;
               emp.Question1 = e.Question1;
                emp.Category = e.Category;
                emp.UserName = e.UserName;

                k.SaveChanges();



            }
            else
            {
                return NotFound();
            }
            // List<path> list = mini.paths.ToList();
            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {



            var emp = k.Questions.Where(model => model.Id == id).FirstOrDefault();
            k.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            k.SaveChanges();
            return Ok();
        }
    }
}
