using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KafkaDataProducer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TradingName = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    Postcode = table.Column<string>(maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    MerchantId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    CardNumber = table.Column<string>(maxLength: 26, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2018, 3, 11, 14, 14, 59, 863, DateTimeKind.Utc), "Joe", "Blogs" },
                    { 9L, new DateTime(2018, 3, 16, 14, 14, 59, 864, DateTimeKind.Utc), "Nat", "Jones" },
                    { 8L, new DateTime(2018, 3, 16, 9, 14, 59, 864, DateTimeKind.Utc), "Zee", "Smith" },
                    { 7L, new DateTime(2018, 3, 16, 5, 14, 59, 864, DateTimeKind.Utc), "Alex", "Jones" },
                    { 6L, new DateTime(2018, 3, 16, 4, 14, 59, 864, DateTimeKind.Utc), "Jack", "Taylor" },
                    { 10L, new DateTime(2018, 3, 16, 14, 14, 59, 864, DateTimeKind.Utc), "Will", "Smith" },
                    { 4L, new DateTime(2018, 3, 15, 14, 14, 59, 864, DateTimeKind.Utc), "Steve", "Evans" },
                    { 3L, new DateTime(2018, 3, 14, 14, 14, 59, 864, DateTimeKind.Utc), "Adolf", "Walker" },
                    { 2L, new DateTime(2018, 3, 13, 14, 14, 59, 864, DateTimeKind.Utc), "Dave", "Smith" },
                    { 5L, new DateTime(2018, 3, 16, 4, 14, 59, 864, DateTimeKind.Utc), "Lee", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "AddressLine1", "City", "CreatedDate", "Postcode", "TradingName" },
                values: new object[,]
                {
                    { 9L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "Other Taxi" },
                    { 1L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 869, DateTimeKind.Utc), "W1 4UT", "Chicken Shop" },
                    { 2L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "SE10 0QW", "Phone Shop" },
                    { 3L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "My Taxis" },
                    { 4L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "MouseTrap" },
                    { 5L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "MagsRUs" },
                    { 6L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "House of Jack" },
                    { 7L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "Russion Poisions" },
                    { 8L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "Coffee Shop" },
                    { 10L, null, "London", new DateTime(2018, 3, 16, 14, 14, 59, 870, DateTimeKind.Utc), "W1 4UT", "Another Taxi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}
