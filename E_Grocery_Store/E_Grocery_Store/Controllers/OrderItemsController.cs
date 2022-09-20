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
    public class OrderItemsController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public OrderItemsController(GroceryDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/OrderItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<OrderItems>> GetOrderItems(int id)
        //{
        //    var orderItems = await _context.OrderItems.FindAsync(id);

        //    if (orderItems == null)
        //    {
        //        return NotFound();
        //    }

        //    return orderItems;
        //}

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrderItems(int id, OrderItems orderItems)
        //{
        //    if (id != orderItems.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(orderItems).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderItemsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/OrderItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderItems>> PostOrderItems(OrderItems orderItems)
        {
            _context.OrderItems.Add(orderItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItems", new { id = orderItems.OrderId }, orderItems);
        }

        // DELETE: api/OrderItems/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<OrderItems>> DeleteOrderItems(int id)
        //{
        //    var orderItems = await _context.OrderItems.FindAsync(id);
        //    if (orderItems == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.OrderItems.Remove(orderItems);
        //    await _context.SaveChangesAsync();

        //    return orderItems;
        //}

        //private bool OrderItemsExists(int id)
        //{
        //    return _context.OrderItems.Any(e => e.OrderId == id);
        //}
    }
}
