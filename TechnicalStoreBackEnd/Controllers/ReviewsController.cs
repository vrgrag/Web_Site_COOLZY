using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReviewsController(AppDbContext context)
    {
        _context = context;
    }

    // Получить отзывы по продукту
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetByProduct(int productId)
    {
        var reviews = await _context.Reviews
            .Where(r => r.ProductId == productId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        return Ok(reviews);
    }

    // Добавить отзыв
    [HttpPost("add")]
    public async Task<IActionResult> AddReview([FromBody] Review review)
    {
        if (review.UserId == 0 || string.IsNullOrWhiteSpace(review.UserName))
            return Unauthorized("Пользователь не авторизован.");

        if (review.Rating < 1 || review.Rating > 5)
            return BadRequest("Оценка должна быть от 1 до 5.");

        if (string.IsNullOrWhiteSpace(review.Comment))
            return BadRequest("Комментарий обязателен.");

        review.CreatedAt = DateTime.UtcNow;
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return Ok(review);
    }
}
