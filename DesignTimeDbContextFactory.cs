using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Budgeteer_REST.Identity;

namespace Budgeteer_REST
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppUserDbContext>
    { 
        
        public IConfiguration Configuration { get; set; }
        public DesignTimeDbContextFactory(IConfiguration config) {
            Configuration = config;
        }
        
        public AppUserDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppUserDbContext>();
            builder.UseNpgsql(Configuration["AppUserDB:Key"]);
            return new AppUserDbContext(builder.Options);
        }
    }
}