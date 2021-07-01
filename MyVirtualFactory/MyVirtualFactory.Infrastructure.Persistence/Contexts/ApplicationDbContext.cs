using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<SubProductTree> SubProducTrees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkCenter> WorkCenters { get; set; }
        public DbSet<WorkCenterOperation> WorkCenterOperations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            base.OnModelCreating(builder);

            //builder.Entity<Notification>()
            //     .HasOne(s => s.FinancialAccount)
            //     .WithMany(g => g.Notifications)
            //     .HasForeignKey(s => s.NotificationFinancialAccountId);


            //builder.Entity<Product>()
            //        .HasMany(t => t.SubProductTrees)
            //        .WithOne(g => g.SubProduct)
            //        .HasForeignKey(g => g.SubProductId);
            //builder.Entity<Product>()
            //    .HasMany(t => t.ProductsTrees)
            //    .WithOne(g => g.Product)
            //    .HasForeignKey(g => g.ProductId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<SubProductTree>()
            //        .HasRequired(m => m.)
            //        .WithMany(t => t.HomeMatches)
            //        .HasForeignKey(m => m.HomeTeamId)
            //        .WillCascadeOnDelete(false);

            //builder.Entity<SubProductTree>()
            //            .HasRequired(m => m.GuestTeam)
            //            .WithMany(t => t.AwayMatches)
            //            .HasForeignKey(m => m.GuestTeamId)
            //            .WillCascadeOnDelete(false);
            //builder.Entity<SubProductTree>()
            //    .HasOne(r => r.SubProduct)
            //      .WithMany(g => g.SubProductTrees)
            // .HasForeignKey(s => s.SubProductId);
            //builder.Entity<SubProductTree>()
            //    .HasOne(r => r.SubProduct)
            //    .WithMany();


            //builder.Entity<Order>()
            //            .HasOne<Customer>(e => e.Customer)
            //            .WithMany(d => d.Orders)
            //            .HasForeignKey(e => e.CustomerId);

            builder.Entity<Order>()
                 .HasOne(s => s.Customer)
                 .WithMany(g => g.Orders)
                 .HasForeignKey(s => s.CustomerId);


        }
    }
}
