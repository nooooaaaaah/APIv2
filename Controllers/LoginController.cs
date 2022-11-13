using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIv2.models;

namespace APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SpielmanDBContext _context;
        public LoginController(SpielmanDBContext context)
        {
            _context = context;
        }
        // Post: api/Login
        [HttpPost]
        public async Task<ActionResult<User>> PostLogin(Login login)
        {
            var user = UserNamePasswordExists(login.UserName, login.Password);
            return user;
        }

        //methods 
        private User UserNamePasswordExists(string username, string password)
        {
            User user = null;
            if (UserNameExists(username) && UserPasswordExists(password))
            {
                user = _context.Users.SingleOrDefault(user => user.UserName == username);
            }
            return user;

        }
        private bool UserPasswordExists(string password)
        {
            return _context.Users.Any(e =>
            e.UserPassword == password);
        }
                private bool UserNameExists(string username)
        {
            return _context.Users.Any(e =>
            e.UserName == username);
        }


    }

}
