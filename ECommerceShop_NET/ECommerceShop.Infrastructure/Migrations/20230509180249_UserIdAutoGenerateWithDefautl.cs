using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserIdAutoGenerateWithDefautl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "newsequentialid()");
        }
    }
}
