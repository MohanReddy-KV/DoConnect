using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoConnect.Controllers
{
    public class CrudApiController : ApiController
    {

        //API for QuestionS CRUD
        

        DOCONNECT2DBEntities2 mini = new DOCONNECT2DBEntities2();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Question> list = mini.Questions.ToList();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetEmployeebyid(int id)
        {
            var emp = mini.Questions.Where(model => model.Id == id).FirstOrDefault();
            return Ok(emp);
        }
        [HttpPost]
        public IHttpActionResult Empinsert(Question e)
        {
            mini.Questions.Add(e);
            mini.SaveChanges();
            // List<path> list = mini.paths.ToList();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Empupdate(Question e)
        {
            var emp = mini.Questions.Where(model => model.Id == e.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Id = e.Id;
                emp.Question1 = e.Question1;
                emp.Category = e.Category;
                emp.UserName = e.UserName;
                mini.SaveChanges();



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



            var emp = mini.Questions.Where(model => model.Id == id).FirstOrDefault();
            mini.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            mini.SaveChanges();
            return Ok();
        }

    }
}
