using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Получение всех избранных товаров пользователя
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var favorites = await _context.FavoriteItems
                .Where(f => f.UserId == userId)
                .Include(f => f.Product)
                    .ThenInclude(p => p.Images)
                .ToListAsync();

            return Ok(favorites.Select(f => new
            {
                f.ProductId,
                Product = new
                {
                    f.Product.ProductId,
                    f.Product.Name,
                    f.Product.Model,
                    f.Product.NewPrice,
                    ImageUrl = f.Product.Images.FirstOrDefault()?.ImageUrl
                }
            }));
        }

        // 🔹 Добавление в избранное
        [HttpPost]
        public async Task<IActionResult> AddToFavorite([FromBody] FavoriteRequest request)
        {
            Console.WriteLine($"[Favorite] Add: userId={request.UserId}, productId={request.ProductId}");

            if (request.UserId <= 0 || request.ProductId <= 0)
                return BadRequest("Некорректные данные");

            var userExists = await _context.Users.AnyAsync(u => u.UserId == request.UserId);
            var productExists = await _context.Products.AnyAsync(p => p.ProductId == request.ProductId);

            if (!userExists || !productExists)
                return BadRequest("Пользователь или товар не найден");

            var alreadyExists = await _context.FavoriteItems
                .AnyAsync(f => f.UserId == request.UserId && f.ProductId == request.ProductId);

            if (alreadyExists)
                return BadRequest("Товар уже в избранном");

            _context.FavoriteItems.Add(new FavoriteItem
            {
                UserId = request.UserId,
                ProductId = request.ProductId
            });

            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Добавлено в избранное" });
        }

        // 🔹 Удаление из избранного
        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> RemoveFromFavorite(int userId, int productId)
        {
            Console.WriteLine($"[Favorite] Remove: userId={userId}, productId={productId}");

            var favorite = await _context.FavoriteItems
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);

            if (favorite == null)
                return NotFound("Не найдено в избранном");

            _context.FavoriteItems.Remove(favorite);
            await _context.SaveChangesAsync();

            return Ok(new { removed = true, message = "Удалено из избранного" });
        }
    }

    public class FavoriteRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
