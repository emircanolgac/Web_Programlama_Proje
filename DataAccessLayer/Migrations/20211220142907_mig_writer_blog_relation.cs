using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_writer_blog_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Articles",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_WriterID",
                table: "Articles",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Writers_WriterID",
                table: "Articles",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Writers_WriterID",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_WriterID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Articles");
        }
    }
}
