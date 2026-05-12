using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Net.WebRequestMethods;

namespace DoConnect.Controllers
{
    public class CRUDAPIforANSController : ApiController
    {
         //API for User CRUD...........................................................................

        DOCONNECT2DBEntities2 ans = new DOCONNECT2DBEntities2();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Answer> list = ans.Answers.ToList();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetEmployeebyid(int id)
        {
            var emp = ans.Answers.Where(model => model.Id == id).FirstOrDefault();
            return Ok(emp);
        }
        [HttpPost]
        public IHttpActionResult Empinsert(Answer e)
        {
            ans.Answers.Add(e);
            ans.SaveChanges();
            // List<path> list = mini.paths.ToList();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Empupdate(Answer e)
        {
            var emp = ans.Answers.Where(model => model.Id == e.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Id = e.Id;
                emp.Answer1 = e.Answer1;
                emp.QuestionId = e.QuestionId;
                emp.UserName = e.UserName;
                ans.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            
            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {



            var emp = ans.Answers.Where(model => model.Id == id).FirstOrDefault();
            ans.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            ans.SaveChanges();
            return Ok();
        }
    }
}
