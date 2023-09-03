using Domain.Addresses;
using Domain.Base;
using Domain.Categories;
using Domain.Items;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks; 

namespace Infrastructure.Database
{
    public class EcomOrderDDDContext:DbContext
    {  
        public EcomOrderDDDContext(DbContextOptions<EcomOrderDDDContext> options)
        : base(options)
            {
            } 
        public virtual DbSet<Addr> Addrs { get; set; } 
        public virtual DbSet<CtgrNme> CtgrNmes { get; set; } 
        public virtual DbSet<Item> Items { get; set; } 
        public virtual DbSet<Order> Orders { get; set; }  
        public virtual DbSet<OrderItem> OrderItems { get; set; } 
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Order>()
               .HasMany(o => o.OrderItems)
               .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.OrderId);


            builder.Entity<OrderItem>()
    .HasOne(oi => oi.Item)
    .WithMany()
    .HasForeignKey(oi => oi.ItemId);


            builder.Entity<Item>()
    .Property(i => i.Price)
    .HasColumnType("decimal(18, 2)");

            //builder.Entity<Addr>()
            //     .HasOne(a => a.) // Assuming 'Events' is the navigation property in 'Addr'
            //     .WithOne()
            //     .HasForeignKey<Addr>(a => a.Id);


            //builder.Entity<Addr>()
            //     .HasOne(a => a.Events) // Assuming 'Events' is the navigation property in 'Addr'
            //     .WithOne()
            //     .HasForeignKey<Addr>(a => a.Id);

            //builder.Entity< BaseDomainEvent> ().HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}


//dotnet ef migrations add InitialMigration --project C:\Users\Administrator.DESKTOP-5JALK0G\source\repos\Ecom-DDD\Infrastructure\Infrastructure.csproj --startup-project C:\Users\Administrator.DESKTOP-5JALK0G\source\repos\Ecom-DDD\WebApplication2\WebApplication2.csproj
//
//
//