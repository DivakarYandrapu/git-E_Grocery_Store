using E_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Core
{
   public interface IPerson
    {
        Task<Response> Registration(Register register);
        Task<Response> Login(Login login);
    }
}
