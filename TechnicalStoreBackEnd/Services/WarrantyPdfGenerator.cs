using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Services
{
    public static class WarrantyPdfGenerator
    {
        public static Task<string> GenerateAsync(Order order, List<OrderItem> items, List<Product> products, string wwwRootPath)
        {
            var fileName = $"warranty_order_{order.OrderId}.pdf";
            var outputDir = Path.Combine(wwwRootPath, "pdf");
            var outputPath = Path.Combine(outputDir, fileName);

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Гарантийный талон — Заказ #{order.OrderId}").FontSize(20).Bold();
                        col.Item().Text($"ФИО: {order.FullName}");
                        col.Item().Text($"Телефон: {order.Phone}");
                        col.Item().Text($"Адрес: {order.Address}");
                        col.Item().Text($"Метод оплаты: {order.PaymentMethod}");
                        col.Item().Text($"Дата: {order.CreatedAt:dd.MM.yyyy}");

                        col.Item().PaddingVertical(10).Text("Состав заказа:").Bold();
                        foreach (var item in items)
                        {
                            var product = products.FirstOrDefault(p => p.ProductId == item.ProductId);
                            col.Item().Text($"• {product?.Brand} {product?.Model} × {item.Quantity} — {item.Price * item.Quantity} BYN");
                        }

                        col.Item().PaddingTop(10).Text($"Итого: {order.TotalAmount} BYN").Bold();
                    });
                    page.Footer().AlignCenter().Text("Спасибо за покупку!");
                });
            });

            // Внимание: GeneratePdf — синхронный
            document.GeneratePdf(outputPath);

            return Task.FromResult(outputPath);
        }
    }
}
