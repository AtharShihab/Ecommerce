using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Core.Entities;
using Ordering.Infrastructure.Identity;

namespace Ordering.Infrastructure.Data
{
    public class OrderingContext : IdentityDbContext<ApplicationUser>
    {
        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetailAudit> OrderDetailAudits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderMaster>().InsertUsingStoredProcedure(
                "Order_Master_Insert", 
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasParameter(o => o.CustomerId);
                    storedProcedureBuilder.HasParameter(o => o.OrderNo);
                    storedProcedureBuilder.HasParameter(o => o.CreatedDate);
                    storedProcedureBuilder.HasParameter(o => o.ModifiedDate);
                    storedProcedureBuilder.HasParameter(o => o.Note);
                    storedProcedureBuilder.HasResultColumn(o => o.Id);
                }).UpdateUsingStoredProcedure(
                "Order_Master_Update", 
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(o => o.Id);
                    //storedProcedureBuilder.HasOriginalValueParameter(o => o.CustomerId);
                    //storedProcedureBuilder.HasOriginalValueParameter(o => o.OrderNo);
                    //storedProcedureBuilder.HasOriginalValueParameter(o => o.CreatedDate);
                    //storedProcedureBuilder.HasOriginalValueParameter(o => o.ModifiedDate);
                    //storedProcedureBuilder.HasOriginalValueParameter(o => o.Note);
                    storedProcedureBuilder.HasOriginalValueParameter(o => o.CreatedDate);
                    storedProcedureBuilder.HasParameter(o => o.CustomerId);
                    storedProcedureBuilder.HasParameter(o => o.OrderNo);
                    storedProcedureBuilder.HasParameter(o => o.ModifiedDate);
                    storedProcedureBuilder.HasParameter(o => o.Note);
                    storedProcedureBuilder.HasRowsAffectedResultColumn();
                }).DeleteUsingStoredProcedure(
                "Order_Master_Delete", 
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(o => o.Id);
                    storedProcedureBuilder.HasRowsAffectedResultColumn();
                });

            builder.Entity<OrderDetail>().InsertUsingStoredProcedure(
                "Order_Detail_Insert", 
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasParameter(o => o.ItemName);
                    storedProcedureBuilder.HasParameter(o => o.Price);
                    storedProcedureBuilder.HasParameter(o => o.MasterId);
                    storedProcedureBuilder.HasParameter(o => o.Quantity);
                    storedProcedureBuilder.HasParameter(o => o.CreatedDate);
                    storedProcedureBuilder.HasParameter(o => o.ModifiedDate);
                    storedProcedureBuilder.HasResultColumn(o => o.Id);
                }).UpdateUsingStoredProcedure(
                "Order_Detail_Update", 
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(od => od.Id);
                    storedProcedureBuilder.HasOriginalValueParameter(od => od.MasterId);
                    storedProcedureBuilder.HasOriginalValueParameter(od => od.CreatedDate);
                    storedProcedureBuilder.HasParameter(x => x.ItemName);
                    storedProcedureBuilder.HasParameter(x => x.Price);
                    storedProcedureBuilder.HasParameter(x => x.Quantity);
                    storedProcedureBuilder.HasParameter(x => x.ModifiedDate);
                    storedProcedureBuilder.HasRowsAffectedResultColumn();
                }).DeleteUsingStoredProcedure(
                "Order_Detail_Delete", 
                storedProcedureBuilder =>
                {
                    storedProcedureBuilder.HasOriginalValueParameter(x => x.Id);
                    storedProcedureBuilder.HasRowsAffectedResultColumn();
                });

        }
    }
}
