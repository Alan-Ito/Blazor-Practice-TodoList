using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TodoList.Areas.Identity.IdentityHostingStartup))]
namespace TodoList.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TodoListIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TodoListIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TodoListIdentityDbContext>();
            });
        }
    }
}