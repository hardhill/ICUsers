using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ICUsers.Models;
using Newtonsoft.Json;

namespace ICUsers.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        // GET api/users SELECT
        [HttpGet]
        public string Get()
        {
            List<Users> users = new List<Users>();
            UsersContext context = HttpContext.RequestServices.GetService(typeof(ICUsers.Models.UsersContext)) as UsersContext;
            users = context.GetAllUsers();
            
            string result = JsonConvert.SerializeObject(users,Formatting.None);
            return result;
        }

        // GET api/Users/1 SELECT
        [HttpGet("{id_tabel}")]
        public string Get(string id_tabel)
        {
            List<Users> users = new List<Users>();
            
            UsersContext context = HttpContext.RequestServices.GetService(typeof(ICUsers.Models.UsersContext)) as UsersContext;
            users = context.GetUser(id_tabel);
            string result = JsonConvert.SerializeObject(users, Formatting.None);
            return result;
        }

        // POST api/values INSERT or FIND by VALUE
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 UPDATE 
        [HttpPut("{id_tabel}")]
        public void Put(string id_tabel, [FromBody]string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}