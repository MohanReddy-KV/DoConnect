using DoConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace DoConnect.Controllers
{
    public class CRUDAPIforUSERController : ApiController
    {
        //API for User CRUD......................................................................

        DOCONNECT2DBEntities2 user = new DOCONNECT2DBEntities2();
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<USERTABLE> list = user.USERTABLEs.ToList();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetEmployeebyid(int id)
        {
            var emp = user.USERTABLEs.Where(model => model.Id == id).FirstOrDefault();
            return Ok(emp);
        }
        [HttpPost]
        public IHttpActionResult Empinsert(USERTABLE e)
        {
            user.USERTABLEs.Add(e);
            user.SaveChanges();
            // List<path> list = mini.paths.ToList();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Empupdate(USERTABLE e)
        {
            var emp = user.USERTABLEs.Where(model => model.Id == e.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Id = e.Id;
                emp.Username = e.Username;
                emp.Password = e.Password;
                emp.Email = e.Email;
                user.SaveChanges();

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



            var emp = user.USERTABLEs.Where(model => model.Id == id).FirstOrDefault();
            user.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            user.SaveChanges();
            return Ok();
        }
    }  
}
