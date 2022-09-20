using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Grocery_Store.DBContext;
using E_Grocery_Store.Models;
using E_Grocery_Store.Core.Ratings;

namespace E_Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly GroceryDbContext _context;
        private readonly IRating rating;

        public RatingController(GroceryDbContext context,IRating rating)
        {
            _context = context;
            this.rating = rating;
        }
        [HttpPost]
        [Route("Rating")]

        public async Task<ActionResult<Response>> Ratings([FromBody] RatingModel ratingModel)
        {
            try
            {
                log.Info("Rating Created Successfully");
                var response = await rating.Ratings(ratingModel);
                return response;
            }
            catch(Exception ex)
            {
                Response response = new Response();
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetRatingModel()
        {
            log.Info("Rating Details are Getting");
            return await _context.Ratings.ToListAsync();
        }

    }
}
