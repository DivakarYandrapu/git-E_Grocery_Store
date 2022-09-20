using E_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Core.Ratings
{
     public interface IRating
    {
        Task<Response> Ratings(RatingModel ratingModel);
    }
}
