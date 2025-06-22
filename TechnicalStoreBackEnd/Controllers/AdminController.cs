using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers;

[Route("api/admin")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    // Получить всех пользователей


    // Удалить пользователя по id
   

    // Сделать пользователя админом
    [HttpPost("set-admin/{id}")]
    public async Task<IActionResult> SetAdmin(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound("Пользователь не найден");

        if (!user.IsAdmin)
        {
            user.IsAdmin = true;

            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.UserId == user.UserId);
            if (existingAdmin == null)
            {
                _context.Admins.Add(new Admin
                {
                    UserId = user.UserId,
                    User = user
                });
            }

            await _context.SaveChangesAsync();
        }

        return Ok(new
        {
            user.UserId,
            user.Username,
            user.Email,
            user.IsAdmin
        });
    }

    // Получить список всех админов
    [HttpGet("admins")]
    public async Task<IActionResult> GetAllAdmins()
    {
        var admins = await _context.Admins
            .Include(a => a.User)
            .Select(a => new
            {
                a.AdminId,
                a.UserId,
                a.User.Username,
                a.User.Email
            })
            .ToListAsync();

        return Ok(admins);
    }
}
