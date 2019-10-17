using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using TKWEB.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TKWEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //從下面一行開始
            //Password Strength Setting  
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings  
                options.Password.RequireDigit = true;    //密碼要有數字
                options.Password.RequiredLength = 4;     //密碼至少要4個字元長
                options.Password.RequireNonAlphanumeric = false;  //不需要符號字元
                options.Password.RequireUppercase = false;         //要有大寫英文字母
                options.Password.RequireLowercase = false;        //不一定要有小寫英文字母
                options.Password.RequiredUniqueChars = 4;         //至少要有個字元不一樣

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);  //5分鐘沒有動靜就自動鎖住定網站，預設5分鐘
                options.Lockout.MaxFailedAccessAttempts = 10;                       //三次密碼誤就鎖定網站, 預設5次
                options.Lockout.AllowedForNewUsers = true;                         //新增的使用者也會被鎖定，就是犯規沒有新人優待

                // User settings  
                options.User.RequireUniqueEmail = true;             //郵箱不能重覆使用
            });

            //Seting the Account Login page  
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings  
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login  
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout  
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied  
                options.SlidingExpiration = true;
            });
            //複製到這邊
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
