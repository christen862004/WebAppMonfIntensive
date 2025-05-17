namespace WebAppMonfIntensive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. //Day8
            builder.Services.AddControllersWithViews(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline. middleware DDay3
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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

/*
 console.app "create obj + readd - write"
 windo form "satart new Form1()"
 wpf          window1
 mvc    Create web app ==>run
 */
