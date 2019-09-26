using FoodFunday.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodFunday.Controllers
{
    public class LoginController : ApiController
    {
        private FoodFundayEntities db = new FoodFundayEntities();
        
        [HttpPost]
        public IHttpActionResult CheckLogin(UserLoginModel.UserLogin user)
        {
            User userFromRepo = db.Users.FirstOrDefault(x => x.username.ToUpper() == user.Username.ToUpper() && x.password == user.Password);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            return Ok(userFromRepo);
        }

        [HttpPost]
        public IHttpActionResult CheckAdminLogin(UserLoginModel.UserLogin user)
        {
            User userFromRepo = db.Users.FirstOrDefault(x => x.username.ToUpper() == user.Username.ToUpper() && x.password == user.Password);
            if (userFromRepo == null)
                return NotFound();

            if(userFromRepo.type == 2)
                return Ok(userFromRepo);

            return NotFound();
        }

    }
}
