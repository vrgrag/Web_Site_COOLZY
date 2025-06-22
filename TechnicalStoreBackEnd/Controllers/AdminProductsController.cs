using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;
using OfficeOpenXml;

namespace TechnicalStoreBackEnd.Controllers;

[Route("api/admin/products")]
[ApiController]
public class AdminProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public AdminProductsController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    // ✅ Получить все товары
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.Products
            .Include(p => p.Images)
            .ToListAsync();

        return Ok(products);
    }

    // ✅ Добавить товар
    [HttpPost("add")]
    public async Task<IActionResult> Add(
        [FromForm] string model,
        [FromForm] string brand,
        [FromForm] decimal newPrice,
        [FromForm] string availability,
        [FromForm] IFormFile image)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model) || image == null)
                return BadRequest("Модель и изображение обязательны");

            var product = new Product
            {
                Model = model,
                Brand = brand,
                NewPrice = newPrice,
                OldPrice = newPrice,
                Availability = availability,
                Name = model,
                Description = "Описание отсутствует",
                CategoryId = 1 // убедись, что такая категория есть в БД!
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var path = Path.Combine(_env.WebRootPath, "images", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            _context.ProductImages.Add(new ProductImage
            {
                ProductId = product.ProductId,
                ImageUrl = $"/images/{fileName}"
            });

            await _context.SaveChangesAsync();
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка сервера: {ex.Message}");
        }
    }

    // ✅ Обновить товар
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromForm] string model,
        [FromForm] string brand,
        [FromForm] decimal newPrice,
        [FromForm] string availability,
        [FromForm] IFormFile? image)
    {
        var product = await _context.Products
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
            return NotFound();

        product.Model = model;
        product.Brand = brand;
        product.NewPrice = newPrice;
        product.OldPrice = newPrice;
        product.Availability = availability;
        product.Name = model;
        product.Description = "Описание обновлено";
        product.CategoryId = 1;

        if (image != null)
        {
            var oldImage = await _context.ProductImages
                .FirstOrDefaultAsync(i => i.ProductId == product.ProductId);

            if (oldImage != null)
            {
                var oldPath = Path.Combine(_env.WebRootPath, oldImage.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(oldPath))
                    System.IO.File.Delete(oldPath);

                _context.ProductImages.Remove(oldImage);
            }

            var fileName = $"{Guid.NewGuid()}_{image.FileName}";
            var path = Path.Combine(_env.WebRootPath, "images", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            _context.ProductImages.Add(new ProductImage
            {
                ProductId = product.ProductId,
                ImageUrl = $"/images/{fileName}"
            });
        }

        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpPut("{id}/quantity")]
public async Task<IActionResult> UpdateQuantity(int id, [FromBody] UpdateQuantityDto dto)
{
    var product = await _context.Products.FindAsync(id);
    if (product == null)
        return NotFound();

    product.Quantity = dto.Quantity;
    await _context.SaveChangesAsync();

    return Ok();
}

public class UpdateQuantityDto
{
    public int Quantity { get; set; }
}


    // ✅ Удалить товар
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
            return NotFound();

        foreach (var image in product.Images)
        {
            var path = Path.Combine(_env.WebRootPath, image.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }

        _context.ProductImages.RemoveRange(product.Images);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ✅ Экспорт в Excel
    [HttpGet("export")]
    public async Task<IActionResult> ExportToExcel()
    {
        var products = await _context.Products.Include(p => p.Images).ToListAsync();

        // ✅ Устанавливаем лицензию — для EPPlus 8+
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Товары");

        sheet.Cells[1, 1].Value = "ID";
        sheet.Cells[1, 2].Value = "Модель";
        sheet.Cells[1, 3].Value = "Бренд";
        sheet.Cells[1, 4].Value = "Цена";
        sheet.Cells[1, 5].Value = "Наличие";
        sheet.Cells[1, 6].Value = "Фото";

        for (int i = 0; i < products.Count; i++)
        {
            var p = products[i];
            sheet.Cells[i + 2, 1].Value = p.ProductId;
            sheet.Cells[i + 2, 2].Value = p.Model;
            sheet.Cells[i + 2, 3].Value = p.Brand;
            sheet.Cells[i + 2, 4].Value = p.NewPrice;
            sheet.Cells[i + 2, 5].Value = p.Availability;
            sheet.Cells[i + 2, 6].Value = p.Images.FirstOrDefault()?.ImageUrl ?? "";
        }

        var stream = new MemoryStream(package.GetAsByteArray());
        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "products.xlsx");
    }
}
