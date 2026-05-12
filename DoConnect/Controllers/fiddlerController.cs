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
    public class fiddlerController : ApiController
    {



        DOCONNECT2DBEntities2 k = new DOCONNECT2DBEntities2();
        public List<USERTABLE> GetAllEmployees()
        {
            return k.USERTABLEs.ToList();
        }
        [HttpPost]
        public string AddEmployee(USERTABLE em)
        {
            k.USERTABLEs.Add(em);
            k.SaveChanges();
            return "User Added Successfully";
        }
        [HttpPut]
        public IHttpActionResult Empupdate(USERTABLE e)
        {
            var emp = k.USERTABLEs.Where(model => model.Id == e.Id).FirstOrDefault();
            if (emp != null)
            {
                emp.Id = e.Id;
                emp.Username = e.Username;
                emp.Password = e.Password;
                emp.Email = e.Email;    
                
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



            var emp = k.USERTABLEs.Where(model => model.Id == id).FirstOrDefault();
            k.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            k.SaveChanges();
            return Ok();
        }



    }
}
