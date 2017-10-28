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
        // GET api/users
        [HttpGet]
        public string Get()
        {
            List<Users> users = new List<Users>();
            UsersContext context = HttpContext.RequestServices.GetService(typeof(ICUsers.Models.UsersContext)) as UsersContext;
            users = context.GetAllUsers();
            
            string result = JsonConvert.SerializeObject(users,Formatting.None);
            return result;
        }

       

        
    }
}