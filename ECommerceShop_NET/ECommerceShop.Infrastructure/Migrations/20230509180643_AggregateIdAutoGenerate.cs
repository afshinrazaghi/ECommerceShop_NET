using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AggregateIdAutoGenerate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cart",
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
                table: "Product",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "newsequentialid()");
        }
    }
}
