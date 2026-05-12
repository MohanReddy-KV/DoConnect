using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoConnect.Controllers
{
    public class FiddlerAnswerController : ApiController
    {


        DOCONNECT2DBEntities2 k = new DOCONNECT2DBEntities2();
        public List<Answer> GetAllEmployees()
        {
            return k.Answers.ToList();
        }
        [HttpPost]
        public string AddEmployee(Answer em)
        {
            k.Answers.Add(em);
            k.SaveChanges();
            return "Answer Added Successfully";
        }
        [HttpPut]
        public IHttpActionResult Empupdate(Answer e)
        {
            var emp = k.Answers.Where(model => model.Id == e.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Id = e.Id;
               emp.Answer1 = e.Answer1;
                emp.QuestionId = e.QuestionId;
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
