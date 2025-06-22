using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;

    public CartController(AppDbContext context)
    {
        _context = context;
    }

    public class CartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    [HttpGet("{userId}")]
public async Task<IActionResult> GetCart(int userId)
{
    var cart = await _context.Carts
        .Include(c => c.Items)
            .ThenInclude(i => i.Product)
                .ThenInclude(p => p.Images) // 👈 обязательно
        .FirstOrDefaultAsync(c => c.UserId == userId);

    if (cart == null)
        return Ok(new Cart { UserId = userId, Items = new List<CartItem>() });

    return Ok(cart);
}


   [HttpPost("add")]
public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
{
    if (request == null || request.UserId <= 0 || request.ProductId <= 0)
        return BadRequest("Некорректный запрос");

    var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == request.ProductId);
    if (product == null)
        return BadRequest("Товар не найден");

    if (product.Quantity < request.Quantity)
        return BadRequest("Недостаточно товара на складе");

    var cart = await _context.Carts
        .Include(c => c.Items)
        .FirstOrDefaultAsync(c => c.UserId == request.UserId);

    if (cart == null)
    {
        cart = new Cart { UserId = request.UserId };
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();
    }

    var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
    if (existingItem != null)
        existingItem.Quantity += request.Quantity;
    else
        cart.Items.Add(new CartItem
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        });

    await _context.SaveChangesAsync();
    return Ok(new { success = true });
}


    // Обновить количество товара
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateQuantity(int id, [FromBody] QuantityUpdateRequest model)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null) return NotFound();

        item.Quantity = model.Quantity;
        await _context.SaveChangesAsync();

        return Ok();
    }

    // Удалить товар из корзины
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveItem(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item == null) return NotFound();

        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
        return Ok(new { removed = true });
    }

    // Очистить корзину
    [HttpDelete("clear/{userId}")]
    public async Task<IActionResult> ClearCart(int userId)
    {
        var items = _context.CartItems.Where(c => c.Cart.UserId == userId);
        _context.CartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
        return Ok(new { cleared = true });
    }

    public class QuantityUpdateRequest
    {
        public int Quantity { get; set; }
    }
}
