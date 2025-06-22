using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers;

[Route("api/admin/orders")]
[ApiController]
public class AdminOrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminOrdersController(AppDbContext context)
    {
        _context = context;
    }

    // Получить все заказы
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Items)
                .ThenInclude(i => i.Product)
            .ToListAsync();

        var result = orders.Select(o => new
        {
            o.OrderId,
            o.CreatedAt,
            User = new { o.User.UserId, o.User.Username, o.User.Email },
            Items = o.Items.Select(i => new
            {
                i.ProductId,
                i.Product.Model,
                i.Quantity,
                i.Price
            }),
            Total = o.Items.Sum(i => i.Price * i.Quantity)
        });

        return Ok(result);
    }

    // Удалить заказ
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null)
            return NotFound();

        _context.OrderItems.RemoveRange(order.Items);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
