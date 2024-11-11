using Entity.Models.CarModels;
using Entity.Models.LoginModels;
using EntityContext.DataSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.EntityContext
{
    public class DbEntityContext : DbContext
    {
        public DbEntityContext(DbContextOptions<DbEntityContext> options) : base(options) { }

        public DbSet<Car> cars { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<CarCompany> carCompanies { get; set; }
        public DbSet<CarCondition> carConditions { get; set; }
        public DbSet<CarModel> carModels { get; set; }
        public DbSet<CarType> cartypes { get; set; }

        public class MainContextFactory : IDesignTimeDbContextFactory<DbEntityContext>
        {
            public DbEntityContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DbEntityContext>();
                optionsBuilder.UseNpgsql(Settings.ConnectionString ?? "Host=localhost;Database=Car;Username=postgres;Password=mirjahon2004;");

                return new DbEntityContext(optionsBuilder.Options);
            }
        }
    }
}
