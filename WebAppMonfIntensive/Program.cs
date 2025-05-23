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

            app.UseRouting();

            app.UseAuthorization();//not active 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
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
