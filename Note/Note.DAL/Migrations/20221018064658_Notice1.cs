using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Note.DAL.Migrations
{
    public partial class Notice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notices",
                columns: table => new
                {
                    NoticeNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticeContents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticeWriteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notices", x => x.NoticeNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notices");
        }
    }
}
