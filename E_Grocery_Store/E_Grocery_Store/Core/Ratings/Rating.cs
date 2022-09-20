using E_Grocery_Store.DBContext;
using E_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Core.Ratings
{
    public class Rating : IRating
    {
        private readonly GroceryDbContext _g;
        public Rating(GroceryDbContext g)
        {
            _g = g;
        }
        public async Task<Response> Ratings(RatingModel ratingModel)
        {
            try
            {
                var res = _g.Ratings.Add(ratingModel);
                await _g.SaveChangesAsync();
                if (res != null)
                {
                    Response response = new Response();
                    response.Message = "Thank You";
                    return response;
                }
                else
                {
                    throw new Exception("Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
