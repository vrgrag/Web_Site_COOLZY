using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 Фильтрация по категории + параметрам
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(
     string category,
     [FromQuery] string? brand,
     [FromQuery] string? ram,
     [FromQuery] string? storage,
     [FromQuery] int? minPrice,
     [FromQuery] int? maxPrice)
        {
            try
            {
                var query = _context.Products
                    .Include(p => p.Images)
                    .Include(p => p.Category)
                    .Where(p => p.Category != null && p.Category.Name == category); // ← исправлено

                if (!string.IsNullOrWhiteSpace(brand))
                    query = query.Where(p => p.Brand == brand);

                if (!string.IsNullOrWhiteSpace(ram))
                    query = query.Where(p => p.Ram == ram);

                if (!string.IsNullOrWhiteSpace(storage))
                    query = query.Where(p => p.Storage == storage);

                if (minPrice.HasValue)
                    query = query.Where(p => p.NewPrice >= minPrice.Value);

                if (maxPrice.HasValue)
                    query = query.Where(p => p.NewPrice <= maxPrice.Value);

                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


            [HttpGet("popular")]
public IActionResult GetRandomPopular()
{
    var randomProducts = _context.Products
        .Include(p => p.Images)
        .ToList() // сначала загружаем в память
        .OrderBy(p => Guid.NewGuid()) // потом рандомим
        .Take(6)
        .Select(p => new
        {
            productId = p.ProductId,
            model = p.Model,
            newPrice = p.NewPrice,
            availability = p.Availability,
            image = p.Images.FirstOrDefault()?.ImageUrl ?? "/img/default.jpg"
        })
        .ToList();

    return Ok(randomProducts);
}
[HttpGet]
public async Task<IActionResult> GetAllProducts()
{
    var products = await _context.Products
        .Include(p => p.Images)
        .Select(p => new
        {
            p.ProductId,
            p.Model,
            p.Brand,
            p.NewPrice,
            p.Availability,
            p.Quantity,
            Images = p.Images.Select(i => new { i.ImageUrl }).ToList()
        })
        .ToListAsync(); // 👈 это обязательно

    return Ok(products);
}




        // 📦 Получение одного товара по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound(new { error = "Товар не найден" });

            return Ok(product);
        }
    }
}
