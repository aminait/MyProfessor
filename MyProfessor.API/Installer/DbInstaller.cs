using FluentValidation.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfessor.DataAccess;
using MyProfessor.Models;
using MyProfessor.Services.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProfessor.API.Installer
{
    public class DbInstaller:IInstaller
    {
        public void InstallServices(IServiceCollection services,IConfiguration Configuration)
        {
            var ConnectionString = Configuration["connectionString:DiscConnection"];

            services.AddDbContext<DiscDbContext>(
                item => item.UseSqlServer(ConnectionString))
                .AddDefaultIdentity<SystemUsers>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                }).AddRoles<IdentityRole>() 
                .AddEntityFrameworkStores<DiscDbContext>();

            services.AddScoped<IArticleService,ArticleService>();
        }
    }
}
