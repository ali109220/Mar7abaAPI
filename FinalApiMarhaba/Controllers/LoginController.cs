using FinalApiMarhaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FinalApiMarhaba.Controllers
{
    
    public class LoginController :  ApiController
    {
        private Marhaba db = new Marhaba();
        // GET: Login
        public IHttpActionResult CheckUser(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = Check(login);
            if (user.Id!=0)
            {
                var AccessToken = getToken(login);
                user.Password = AccessToken;
                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
            user.Id= -1;
            return CreatedAtRoute("DefaultApi", new { id = -1 }, user);
        }

        private User Check(LoginModel login)
        {
            var user = new User();
            bool succes = false;
            var users = db.Users;
            foreach(var _user in users)
            {
                if (_user.Email == login.Email && _user.Password == login.Password)
                {
                    succes = true;
                    user = _user;
                    break;
                }
            }
            if (!succes)
            {
                return user;
            }
            return user;
        }

        private string getToken(LoginModel login)
        {
            Random r = new Random();
            return new string(Enumerable.Repeat(login.Password,login.Password.Length*3).Select(s=>s[r.Next(s.Length)]).ToArray());
        }
    }
}