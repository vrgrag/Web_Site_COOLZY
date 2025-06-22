using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Text;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Controllers;

[Route("api/admin/reports")]
[ApiController]
public class AdminReportsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminReportsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("orders")]
    public IActionResult ExportOrdersToExcel()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Orders");

        sheet.Cells[1, 1].Value = "Order ID";
        sheet.Cells[1, 2].Value = "User";
        sheet.Cells[1, 3].Value = "Email";
        sheet.Cells[1, 4].Value = "Date";
        sheet.Cells[1, 5].Value = "Total";

        var orders = _context.Orders
            .Select(o => new {
                o.OrderId,
                o.User.Username,
                o.User.Email,
                o.CreatedAt,
                Total = o.Items.Sum(i => i.Quantity * i.Price)
            }).ToList();

        for (int i = 0; i < orders.Count; i++)
        {
            var o = orders[i];
            sheet.Cells[i + 2, 1].Value = o.OrderId;
            sheet.Cells[i + 2, 2].Value = o.Username;
            sheet.Cells[i + 2, 3].Value = o.Email;
            sheet.Cells[i + 2, 4].Value = o.CreatedAt.ToString("g");
            sheet.Cells[i + 2, 5].Value = o.Total;
        }

        var bytes = package.GetAsByteArray();
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Orders.xlsx");
    }

    [HttpGet("users")]
    public IActionResult ExportUsersToExcel()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Users");

        sheet.Cells[1, 1].Value = "User ID";
        sheet.Cells[1, 2].Value = "Username";
        sheet.Cells[1, 3].Value = "Email";

        var users = _context.Users.ToList();

        for (int i = 0; i < users.Count; i++)
        {
            var u = users[i];
            sheet.Cells[i + 2, 1].Value = u.UserId;
            sheet.Cells[i + 2, 2].Value = u.Username;
            sheet.Cells[i + 2, 3].Value = u.Email;
        }

        var bytes = package.GetAsByteArray();
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Users.xlsx");
    }
}
