using Microsoft.EntityFrameworkCore;
using Mango.Services.CouponAPI.Data;

namespace Mango.Services.CouponAPI

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(option => {
                // builder.Configuration.GetConnectionString("DefaultConnectionString")
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            AddMigrations(app);
        }

        static void AddMigrations(WebApplication app) {
            using (var scope = app.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (_db.Database.GetPendingMigrations().Count() > 0) { 
                    _db.Database.Migrate(); 
                }
            }
        }
    }
}