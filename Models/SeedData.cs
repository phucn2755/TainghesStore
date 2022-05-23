using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TainghesStore.Data;
using System;
using System.Linq;
namespace TainghesStore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TainghesStoreContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<TainghesStoreContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.Tainghe.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.Tainghe.AddRange(
                new Tainghe
                {
                    Title = "Atomic Habits",
                    Genre = "Self-Help",
                    Price = 11.98M,
                    Rating = "R"
                },
                new Tainghe
                {
                    Title = "Dark Roads",
                    Genre = "Novel",
                    Price = 18.59M,
                    Rating = "R"
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}
