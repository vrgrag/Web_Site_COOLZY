using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using SixLabors.Fonts;
using System.IO;

namespace TechnicalStoreBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public OrdersController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ToListAsync();

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null || order.Items == null || !order.Items.Any())
                return BadRequest("Неверные данные заказа");

            foreach (var item in order.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                    return BadRequest($"Товар с ID {item.ProductId} не найден");

                if (product.Quantity < item.Quantity)
                    return BadRequest($"Недостаточно товара: {product.Name}");

                product.Quantity -= item.Quantity;
                item.Price = product.NewPrice;
            }

            order.CreatedAt = DateTime.UtcNow;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Заказ успешно создан", orderId = order.OrderId });
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] Order updated)
        {
            var order = await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null) return NotFound("Заказ не найден");

            order.FullName = updated.FullName;
            order.Address = updated.Address;
            order.Phone = updated.Phone;
            order.PaymentMethod = updated.PaymentMethod;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(int userId)
        {
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p.Images)
                .ToListAsync();

            return Ok(orders);
        }

  [HttpGet("contract/{orderId}")]
public async Task<IActionResult> DownloadContract(int orderId)
{
    var order = await _context.Orders
        .Include(o => o.User)
        .Include(o => o.Items)
            .ThenInclude(i => i.Product)
        .FirstOrDefaultAsync(o => o.OrderId == orderId);

    if (order == null)
        return NotFound("Заказ не найден");

    var folderPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "contracts");
    if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

    var fileName = $"Order_{orderId}_Contract.pdf";
    var filePath = Path.Combine(folderPath, fileName);

    var document = new PdfDocument();
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);

    // Загружаем шрифт
    var fontPath = Path.Combine(Directory.GetCurrentDirectory(), "Fonts", "Roboto-Regular.ttf");
    var collection = new FontCollection();
    var sixFont = collection.Add(fontPath);
    
    var roboto = new XFont(sixFont.Name, 14, XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode));

    double y = 40;

    gfx.DrawString("ГАРАНТИЙНЫЙ ТАЛОН / ДОГОВОР", new XFont(sixFont.Name, 18, XFontStyle.Bold), XBrushes.Black, new XPoint(200, y));
    y += 40;

    gfx.DrawString($"Номер заказа: {order.OrderId}", roboto, XBrushes.Black, new XPoint(40, y)); y += 25;
    gfx.DrawString($"Имя клиента: {order.FullName}", roboto, XBrushes.Black, new XPoint(40, y)); y += 25;
    gfx.DrawString($"Телефон: {order.Phone}", roboto, XBrushes.Black, new XPoint(40, y)); y += 25;
    gfx.DrawString($"Адрес доставки: {order.Address}", roboto, XBrushes.Black, new XPoint(40, y)); y += 25;
    gfx.DrawString($"Оплата: {order.PaymentMethod}", roboto, XBrushes.Black, new XPoint(40, y)); y += 25;
    gfx.DrawString($"Дата: {order.CreatedAt:dd.MM.yyyy}", roboto, XBrushes.Black, new XPoint(40, y)); y += 30;

    gfx.DrawString("Состав заказа:", roboto, XBrushes.Black, new XPoint(40, y)); y += 25;

    foreach (var item in order.Items)
    {
        gfx.DrawString($"{item.Product?.Model ?? "—"} - {item.Quantity} × {item.Price} BYN", roboto, XBrushes.Black, new XPoint(60, y));
        y += 20;
    }

    y += 10;
    decimal total = order.Items.Sum(i => i.Price * i.Quantity);
    gfx.DrawString($"Итого: {total} BYN", new XFont(sixFont.Name, 14, XFontStyle.Bold), XBrushes.Black, new XPoint(40, y));

    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        document.Save(stream);
    }

    var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
    return File(fileBytes, "application/pdf", fileName);
}


    }
}
