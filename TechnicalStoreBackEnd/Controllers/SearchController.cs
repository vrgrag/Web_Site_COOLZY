using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TechnicalStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> Search(string query)
        {
            query = query.ToLower();

            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p =>
                    p.Brand.ToLower().Contains(query) ||
                    p.Model.ToLower().Contains(query) ||
                    (p.Category != null && p.Category.Name.ToLower().Contains(query)))
                .ToListAsync();

            var productResults = products
                .Where(p => p.ProductId != 0 && !string.IsNullOrWhiteSpace(p.Brand))
                .Select(p => new
                {
                    id = p.ProductId,
                    name = p.Brand + " " + p.Model,
                    type = "product"
                })
                .Cast<object>()
                .ToList();

            var categories = await _context.Categories
                .Where(c => c.Name.ToLower().Contains(query))
                .Select(c => new
                {
                    id = (int?)null,
                    name = c.Name,
                    type = "category"
                })
                .Cast<object>()
                .ToListAsync();

            var brandResults = products
                .Select(p => p.Brand)
                .Distinct()
                .Where(b => b.ToLower().Contains(query))
                .Select(b => new
                {
                    id = (int?)null,
                    name = b,
                    type = "brand"
                })
                .Cast<object>()
                .ToList();

            var results = new List<object>();
            results.AddRange(productResults);
            results.AddRange(categories);
            results.AddRange(brandResults);

            return Ok(results);
        }
    }
}
