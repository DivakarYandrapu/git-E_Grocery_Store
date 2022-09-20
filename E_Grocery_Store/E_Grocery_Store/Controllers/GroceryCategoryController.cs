using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Grocery_Store.DBContext;
using E_Grocery_Store.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryCategoryController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly GroceryDbContext _context;

        public GroceryCategoryController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryCategory
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryCategory>>> GetGroceryCategory()
        {
            return await _context.GroceryCategory.ToListAsync();
        }

        // GET: api/GroceryCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryCategory>> GetGroceryCategory(int id)
        {
            var groceryCategory = await _context.GroceryCategory.FindAsync(id);

            if (groceryCategory == null)
            {
                return NotFound();
            }

            return groceryCategory;
        }

        // PUT: api/GroceryCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryCategory(int id, GroceryCategory groceryCategory)
        {
            if (id != groceryCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(groceryCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroceryCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroceryCategory>> PostGroceryCategory(GroceryCategory groceryCategory)
        {
            _context.GroceryCategory.Add(groceryCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryCategory", new { id = groceryCategory.Id }, groceryCategory);
        }

        // DELETE: api/GroceryCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryCategory>> DeleteGroceryCategory(int id)
        {
            var groceryCategory = await _context.GroceryCategory.FindAsync(id);
            if (groceryCategory == null)
            {
                return NotFound();
            }

            _context.GroceryCategory.Remove(groceryCategory);
            await _context.SaveChangesAsync();

            return groceryCategory;
        }

        private bool GroceryCategoryExists(int id)
        {
            return _context.GroceryCategory.Any(e => e.Id == id);
        }
    }
}
