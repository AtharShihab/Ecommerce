using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTablesStoreProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE [dbo].[Order_Master_Insert]  \r\n    @CustomerId [bigint],  \r\n    @OrderNo [nvarchar](max),  \r\n    @Note [nvarchar](max), \r\n @CreatedDate [datetime2], \r\n @ModifiedDate [datetime2]  \r\nAS  \r\nBEGIN  \r\n    INSERT [dbo].[OrderMasters]([CustomerId], [OrderNo], [Note], [CreatedDate], [ModifiedDate]) \r\n OUTPUT INSERTED.[Id]  \r\n    VALUES (@CustomerId, @OrderNo, @Note, @CreatedDate, @ModifiedDate)  \r\n END ");
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE [dbo].[Order_Master_Update]  \r\n  @Id [bigint],  \r\n @CreatedDate_Original [datetime2], \r\n  @CustomerId [bigint],  \r\n    @OrderNo [nvarchar](max),  \r\n    @Note [nvarchar](max), \r\n @ModifiedDate [datetime2] \r\nAS  \r\nBEGIN  \r\n    UPDATE [dbo].[OrderMasters]  SET [CustomerId] = @CustomerId, \r\n  [OrderNo] = @OrderNo, \r\n  [Note] = @Note, \r\n  [ModifiedDate] = @ModifiedDate \r\n  WHERE [Id] = @Id AND [CreatedDate] = @CreatedDate_Original \r\n SELECT @@ROWCOUNT  \r\nEND ");
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE [dbo].[Order_Master_Delete]  \r\n    @Id [bigint]  \r\nAS  \r\nBEGIN  \r\n    DELETE FROM [dbo].[OrderMasters] \r\n OUTPUT 1  \r\n  WHERE [Id] = @Id   \r\nEND ");

            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE [dbo].[Order_Detail_Insert]  \r\n    @MasterId [bigint],  \r\n    @ItemName [nvarchar](max),  \r\n    @Quantity [decimal](18,2),  \r\n    @Price [decimal](18,2), \r\n @CreatedDate [datetime2], \r\n @ModifiedDate [datetime2]  \r\nAS  \r\nBEGIN  \r\n    INSERT [dbo].[OrderDetails]([MasterId], [ItemName], [Quantity], [Price], [CreatedDate], [ModifiedDate]) \r\n OUTPUT INSERTED.[Id]  \r\n    VALUES (@MasterId, @ItemName, @Quantity, @Price, @CreatedDate, @ModifiedDate)  \r\nEND ");
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE [dbo].[Order_Detail_Update]  \r\n  @Id [bigint], \r\n  @CreatedDate_Original[datetime2],  \r\n  @MasterId_Original [bigint],  \r\n  @ItemName [nvarchar](max),  \r\n    @Quantity [decimal](18,2),  \r\n    @Price [decimal](18,2), \r\n @ModifiedDate [datetime2] \r\nAS  \r\nBEGIN  \r\n    UPDATE [dbo].[OrderDetails]  SET [ItemName] = @ItemName, \r\n  [Quantity] = @Quantity, \r\n  [Price] = @Price, \r\n  [ModifiedDate] = @ModifiedDate \r\n  WHERE [Id] = @Id AND [CreatedDate] = @CreatedDate_Original AND [MasterId] = @MasterId_Original \r\n SELECT @@ROWCOUNT  \r\nEND ");
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE [dbo].[Order_Detail_Delete]  \r\n    @Id [bigint]  \r\nAS  \r\nBEGIN  \r\n    DELETE FROM [dbo].[OrderDetails] \r\n OUTPUT 1  \r\n  WHERE [Id] = @Id   \r\nEND ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
