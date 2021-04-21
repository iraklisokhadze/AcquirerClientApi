using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AcquirerClientApi.Migrations
{
    public partial class IpayCallback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PaymentRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentCallbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<string>(type: "text", nullable: true),
                    PaymentHash = table.Column<string>(type: "text", nullable: true),
                    IpayPaymentId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    StatusDescription = table.Column<string>(type: "text", nullable: true),
                    ShopOrderId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    CardType = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Pan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCallbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefundCallbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<string>(type: "text", nullable: true),
                    PaymentHash = table.Column<string>(type: "text", nullable: true),
                    IpayPaymentId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    StatusDescription = table.Column<string>(type: "text", nullable: true),
                    ShopOrderId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    CardType = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Pan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundCallbacks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_StatusId",
                table: "PaymentRequests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCallbacks_IpayPaymentId",
                table: "PaymentCallbacks",
                column: "IpayPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCallbacks_OrderId",
                table: "PaymentCallbacks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCallbacks_ShopOrderId",
                table: "PaymentCallbacks",
                column: "ShopOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundCallbacks_IpayPaymentId",
                table: "RefundCallbacks",
                column: "IpayPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundCallbacks_OrderId",
                table: "RefundCallbacks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundCallbacks_ShopOrderId",
                table: "RefundCallbacks",
                column: "ShopOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_PaymentStatus_StatusId",
                table: "PaymentRequests",
                column: "StatusId",
                principalTable: "PaymentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_PaymentStatus_StatusId",
                table: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "PaymentCallbacks");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "RefundCallbacks");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRequests_StatusId",
                table: "PaymentRequests");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PaymentRequests");
        }
    }
}
