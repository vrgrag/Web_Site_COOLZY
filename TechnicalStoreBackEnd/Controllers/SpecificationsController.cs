using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpecificationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var specs = await _context.ProductSpecifications
                .Where(s => s.ProductId == productId)
                .ToListAsync();

            return Ok(specs);
        }
    }
}
