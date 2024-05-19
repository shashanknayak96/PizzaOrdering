using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrdering.Migrations
{
    /// <inheritdoc />
    public partial class addguidlimitid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LimitId",
                table: "DailyPizzaLimits",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PizzaId",
                value: new Guid("91de7e62-93f6-44ee-974f-60a05dfe292b"));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PizzaId",
                value: new Guid("6fe8215a-b80d-41dd-99f1-5f28710fdafe"));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PizzaId",
                value: new Guid("21610e0d-ac12-4e6a-8798-4c4aed4a68b8"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitId",
                table: "DailyPizzaLimits");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PizzaId",
                value: new Guid("4a51ff6b-5f0c-4d03-a54d-2bfb55ae368b"));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PizzaId",
                value: new Guid("4b4f7006-7960-4020-bcac-2b829730e494"));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PizzaId",
                value: new Guid("d22f83af-431a-482d-b22f-8a9f5ab45879"));
        }
    }
}
