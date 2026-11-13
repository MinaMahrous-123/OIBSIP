using BLL.GenericRepo;
using DAL.DataBaseContext;
using DAL.Extend;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Pizza_Delivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            #region    ConnectionString To DataBase

            var ConnectionSetring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<BDBContext>(Options => Options.UseSqlServer(ConnectionSetring));



            #endregion


            //General Repo

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            #region   Belong to microsoft identity
            //Service Identity for userManagement

            //builder.Services.AddScoped<IUserManagementService, UserManagementService>();
            ////Services User

            //builder.Services.AddScoped<IUserService, UserService>();
            ////Services Role

            //builder.Services.AddScoped<IRoleService, RoleService>();
            #endregion

            //#region  Services Project
            //builder.Services.AddScoped<IHotelService, HotelService>();
            //builder.Services.AddScoped<IRoomServices, RoomServices>();
            //builder.Services.AddScoped<IBookingServices, BookingServices>();



            //#endregion






            #region Microsoft Identity Service


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                                options =>
                                {
                                    options.LoginPath = new PathString("/Account/Login");
                                    options.AccessDeniedPath = new PathString("/Account/Login");
                                });


            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRoll>()
                .AddEntityFrameworkStores<BDBContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);



            // Password Configuration
            builder.Services.AddIdentity<ApplicationUser, ApplicationRoll>(options =>
            {

                // options.User.RequireUniqueEmail = true;

                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<BDBContext>();


#endregion












            //#region Auto Mapper Service

            //builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            //#endregion






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
