using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarketApp.Data
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BrokerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StockId = table.Column<Guid>(nullable: false),
                    BrokerId = table.Column<Guid>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Commission = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_People_ClientId",
                        column: x => x.ClientId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("34430d35-a8b0-4bdf-90fd-ca5add46a10b"), "Broker1" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("e58a89f9-7b29-4e71-a0ca-9ccb9b561cde"), "MeetMe", 35 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("d75d3245-d431-4b9d-a146-77112399e117"), "InterNAP", 94 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("5405a6bf-a0d2-4e3e-a598-cfc48a2cbcaf"), "Genesis", 13 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("76b1f1ea-9c47-43b1-bd17-4f75b3e2eb6b"), "FlashZero", 58 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("002327cf-dbf8-4003-93e4-43a03f5fceb5"), "Epazz", 51 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("6a35264f-cce2-43c6-b722-ea398719035d"), "Envestnet", 84 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("1b44c460-5bdc-4adc-8cf2-2bbe86848a49"), "ENDEXX", 28 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("04e15309-386c-4f90-948b-7db325607fb9"), "Eastern", 27 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("a3877689-e1a3-4329-bfb9-4e6e92030286"), "EarthLink", 31 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("5ab899ec-18cb-494d-959c-6347efaa20cf"), "CrowdGather", 84 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("f9a6ce28-652d-4ba3-9ff8-c4a8c6c34941"), "Crexendo", 93 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("c0b6379c-9031-446d-84cb-cc4a2b8f1d28"), "Cogent", 59 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("3619c62f-3ddd-4c56-b29e-913f2b9d96df"), "Netease", 34 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("aabbf10f-2139-469c-8091-0cec1af969e2"), "Cnova", 2 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("c02a4db7-4e35-4f78-b623-7940a4498caa"), "ADR", 64 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("130be51f-0157-47f4-b718-fdff1e9c0a2e"), "ChinaCache", 84 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("687854d8-0669-4f67-82e9-d7d75e5249a6"), "China Finance", 44 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("ee5c7a6a-47d5-4683-a41a-8aa2db0611fd"), "Carbonite", 47 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("451e67ca-f0d7-4d36-87e6-a14da5ae9ea9"), "Brainybrawn", 2 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("eaa52192-3594-44e4-90d3-92f2c2dc5fbe"), "Boingo", 31 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("16dfa69d-fbb6-43ae-b4cc-9cbbbf5e010f"), "Blucora", 84 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("c6eea4d4-108a-4e69-a24c-e30f9a3db27f"), "Blinkx", 93 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("c4e8a875-df78-41c7-a438-abedaa36466c"), "Baidu", 20 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("58d5e484-0710-4f60-bbbe-dbff4096a91a"), "Akamai", 89 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("b297fc93-986e-41d5-bbd9-4f90b084e937"), "Agritek", 46 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("6426c117-0583-476b-a327-3863ef223e3a"), "Vianet", 16 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("91172153-8ae8-47d7-91a4-046e36222feb"), "ChitrChatr", 92 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { new Guid("8c52e4c7-46b1-48a5-b7ac-a3a3e0d0ba59"), "Qihoo", 67 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "BrokerId", "Name" },
                values: new object[] { new Guid("868e4d70-2648-43db-a584-2ba90e8ee407"), new Guid("34430d35-a8b0-4bdf-90fd-ca5add46a10b"), "Client1" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "BrokerId", "Name" },
                values: new object[] { new Guid("19b8ca93-e1fc-477a-bf7b-2e40a6bc7f80"), new Guid("34430d35-a8b0-4bdf-90fd-ca5add46a10b"), "Client2" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BrokerId",
                table: "Orders",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StockId",
                table: "Orders",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_People_BrokerId",
                table: "People",
                column: "BrokerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Brokers");
        }
    }
}
