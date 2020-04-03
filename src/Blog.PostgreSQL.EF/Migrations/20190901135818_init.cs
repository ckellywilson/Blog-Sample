using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Blog.PostgreSQL.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_entry",
                columns: table => new
                {
                    blog_entry_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    blog_entry_name = table.Column<string>(type: "varchar(256)", nullable: false),
                    blog_entry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("blog_entry_pk", x => x.blog_entry_id);
                });

            migrationBuilder.CreateTable(
                name: "blog_post",
                columns: table => new
                {
                    blog_post_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    blog_post_comment = table.Column<string>(type: "text", nullable: false),
                    blog_post_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    blog_entry_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("blog_post_pkey", x => x.blog_post_id);
                    table.ForeignKey(
                        name: "blog_post_blog_entry_blog_entry_id_fkey",
                        column: x => x.blog_entry_id,
                        principalTable: "blog_entry",
                        principalColumn: "blog_entry_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "blog_entry_blog_name_uc",
                table: "blog_entry",
                column: "blog_entry_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_blog_entry_id",
                table: "blog_post",
                column: "blog_entry_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_post");

            migrationBuilder.DropTable(
                name: "blog_entry");
        }
    }
}
