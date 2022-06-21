using CarConfiguratorAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarConfiguratorAPI.Data
{


    public class CarConfigDbContext : DbContext
    {
        public DbSet<EngineModel> Engines { get; set; }
        public DbSet<OptionalModel> Optionals { get; set; }
        public DbSet<PaintModel> Paints { get; set; }
        public DbSet<WheelModel> Wheels { get; set; }
        public DbSet<ResultModel> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public CarConfigDbContext(DbContextOptions<CarConfigDbContext> options) : base(options)
        {
            
        }
    }
}
