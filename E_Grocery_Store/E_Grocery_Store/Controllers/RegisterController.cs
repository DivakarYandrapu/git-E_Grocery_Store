using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Grocery_Store.DBContext;
using E_Grocery_Store.Models;
using E_Grocery_Store.Core;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace E_Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly GroceryDbContext _context;
        private readonly IPerson person;

        public RegisterController(GroceryDbContext context, IPerson person)
        {
            _context = context;
            this.person = person;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult<Response>> Registration([FromBody] Register register)
        {
            try
            {
                var response = await person.Registration(register);
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var user = await _context.Register.Where(i => i.MailId == login.MailId
                                        && i.Password == login.Password).Include(i => i.Role).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("Invalid Credentials");
                }

                var claims = new List<Claim>
                {
                    new Claim(type: ClaimTypes.Email, value: user?.MailId),
                    new Claim(type: ClaimTypes.Role, value: user?.Role?.RoleName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity));

                return Ok("Login Successful");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
