using ABLE_API.Data;
using Microsoft.EntityFrameworkCore;

namespace ABLE_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddDbContext<AbleContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
            });

            var app = builder.Build();

            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://dorume.site"));
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
