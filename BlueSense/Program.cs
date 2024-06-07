using BlueSense.Models;
using BlueSense.Persistence.Interface;
using BlueSense.Persistence.Repositorios;
using BlueSense.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlueSense
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Inicio - Adiciona os servicos para que seja injetado posteriormente em outras classes

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<FIAPDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP"));
            });

            builder.Services.AddScoped<IRepositorio<Notificacao>, Repositorio<Notificacao>>();
            // FIM - Adiciona os servicos para que seja injetado posteriormente em outras classes


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
