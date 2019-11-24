﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cocktail_Magician_DB.Migrations
{
    public partial class Added_Date_CocktailReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CocktailReviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CocktailReviews");
        }
    }
}
