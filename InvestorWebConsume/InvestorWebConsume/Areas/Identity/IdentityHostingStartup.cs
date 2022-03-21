using System;
using InvestorWebConsume.Areas.Identity.Data;
using InvestorWebConsume.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(InvestorWebConsume.Areas.Identity.IdentityHostingStartup))]
namespace InvestorWebConsume.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<InvestorWebConsumeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("InvestorWebConsumeContextConnection")));

                services.AddDefaultIdentity<InvestorWebConsumeUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<InvestorWebConsumeContext>();
            });
        }
    }
}