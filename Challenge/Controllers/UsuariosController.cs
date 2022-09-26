using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Models;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        //public IActionResult GetUsuarios (int id )
        //{
        //    using (challengeContext db = new challengeContext())
        //    {
        //        User usu = new User();
        //        usu = db.Users.Where(b => b.Id == id).FirstOrDefault();
        //        return Ok(usu);
        //    }
        //}
        // GET: Users

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            using (challengeContext db = new challengeContext())
            {
                User usu = new User();
                usu =  db.Users.Where(b => b.Id == id).FirstOrDefault();
     
          

            if (usu == null)
            {
                return NotFound();
            }

            return usu;
            }
        }
    }
}
