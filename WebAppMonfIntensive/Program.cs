using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebAppMonfIntensive.Filtters;
using WebAppMonfIntensive.Models;
using WebAppMonfIntensive.Repository;

namespace WebAppMonfIntensive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container (IOC Container | Serviers Provider). //Day8
            //1) Built in services and already register 122

            //2) Built in services Need To Register 313
            //builder.Services.AddControllersWithViews(option => {
            //    option.Filters.Add(new HandelErrorAttribute());//Global Application Filtter
            //});
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                }).AddEntityFrameworkStores<ITIContext>();
           
            builder.Services.AddDbContext<ITIContext>(optionBuilder => {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            //3) Custom Service and Need To Register  315
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ITestREpository, TestRepository>();

            var app = builder.Build();
            #region Cusomt Mibleware
            //inline Middleware
            //app.Use(async(httpContext, next) => {
            //    //if(context.req)
            //    await httpContext.Response.WriteAsync("1) Middleware 1\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("1-1) Middleware 1-1\n");

            //});
            //app.Use(async (httpContext, next) => {
            //    //if(context.req)
            //    await httpContext.Response.WriteAsync("2) Middleware 2\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("2-2) Middleware 2-2\n");

            //});

            //app.Run(async(httpContext) => { 
            //    await httpContext.Response.WriteAsync("3) Middleware 3 Terminate\n");
            //});



            #endregion
            // Configure the HTTP request pipeline. middleware DDay3
            #region built in PipleLine
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //req ==> wwwroot /imags/m.png

            app.UseRouting(); //Security /Employee/Index
           
            app.UseSession();
            
            app.UseAuthorization();//not active 
            #region Custom Route
            //Staff "'DEcalre  Exceute"/r1/10
            //app.MapControllerRoute("Route1", "r1/{age:int:range(20,60)}/{name?}", new
            //{
            //    controller="Route",action="Method1"
            //});
            //r1/MEthod1
            //r1/MEthod2
            //r1
            //app.MapControllerRoute("Route1", "{controller=Route}/{action=Method1}/{id?}");

            //app.MapControllerRoute("Route2", "r2", new
            //{
            //    controller = "Route",
            //    action = "Method2"
            //});

            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}

/*
 console.app "create obj + readd - write"
 windo form "satart new Form1()"
 wpf          window1
 mvc    Create web app ==>run
 */
