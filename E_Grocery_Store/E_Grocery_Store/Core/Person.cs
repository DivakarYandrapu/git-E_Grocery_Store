using E_Grocery_Store.DBContext;
using E_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Core
{
    public class Person : IPerson
    {
        private readonly GroceryDbContext _g;
        public Person(GroceryDbContext g)
        {
            _g = g;
        }
        public Task<Response> Login(Login login)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Registration(Register register)
        {
            try
            {
                var res = _g.Register.Add(register);
                await _g.SaveChangesAsync();
                if (res != null)
                {
                    Response response = new Response();
                    response.Message = "Registration Successfull";
                    return response;
                }
                else
                {
                    throw new Exception("Registration Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
