using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockDataGeneration.Model;

namespace MockDataGeneration
{
    public class AppDbContext : DbContext
    {
        FakeDataProvider fakeProvider;
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            fakeProvider = new FakeDataProvider();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Category>()
        //    .HasData(fakeProvider.Categories);
        //    modelBuilder
        //        .Entity<Product>()
        //        .HasKey();
        //}
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }
}
