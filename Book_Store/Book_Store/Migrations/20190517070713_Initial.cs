using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Popular = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookItems");
        }
    }
}
