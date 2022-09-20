using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Grocery_Store.DBContext;
using E_Grocery_Store.Models;

namespace E_Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryItemsController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public GroceryItemsController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryItems>>> GetGroceryItems()
        {
            //return await _context.GroceryItems.ToListAsync();
            var groceryitems = (from g in _context.GroceryItems
                                join c in _context.GroceryCategory
                                on g.CategoryId equals c.Id

                                select new GroceryItems
                                {
                                    Id = g.Id,
                                    ItemName = g.ItemName,
                                    Price = g.Price,
                                    CategoryId = g.CategoryId,
                                    Category = c.Category
                                }).ToListAsync();
            return await groceryitems;
        }

        // GET: api/GroceryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItems>> GetGroceryItems(int id)
        {
            var groceryItems = await _context.GroceryItems.FindAsync(id);

            if (groceryItems == null)
            {
                return NotFound();
            }

            return groceryItems;
        }

        // PUT: api/GroceryItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryItems(int id, GroceryItems groceryItems)
        {
            if (id != groceryItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(groceryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryItemsExists(id))
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

        // POST: api/GroceryItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroceryItems>> PostGroceryItems(GroceryItems groceryItems)
        {
            _context.GroceryItems.Add(groceryItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryItems", new { id = groceryItems.Id }, groceryItems);
        }

        // DELETE: api/GroceryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryItems>> DeleteGroceryItems(int id)
        {
            var groceryItems = await _context.GroceryItems.FindAsync(id);
            if (groceryItems == null)
            {
                return NotFound();
            }

            _context.GroceryItems.Remove(groceryItems);
            await _context.SaveChangesAsync();

            return groceryItems;
        }

        private bool GroceryItemsExists(int id)
        {
            return _context.GroceryItems.Any(e => e.Id == id);
        }
    }
}
