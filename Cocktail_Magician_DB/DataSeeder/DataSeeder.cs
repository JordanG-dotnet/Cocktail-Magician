﻿using Cocktail_Magician_DB.DataSeeder.IOSeed;
using Cocktail_Magician_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cocktail_Magician_DB.DataSeeder
{
    public class DataSeeder
    {
        public static void SeedBars(CMContext context)
        {
            const string booksJsonAddress = @"../Cocktail_Magician_DB/DataSeeder/JsonFiles/Bars.json";

            if (context.Bars.Any())
                return;

            var listBars = ReadFileDatabase.ReadJsonsSeeds<Bar>(booksJsonAddress);

            foreach (var bar in listBars)
            {
                context.Bars.Add(new Bar
                {
                    Name = bar.Name,
                    Address = bar.Address,
                    Rating = bar.Rating,
                    Information = bar.Information,
                    Picture = bar.Picture,
                    MapDirections = bar.MapDirections
                });

                context.SaveChanges();
            }
        }

        public static void SeedIngredients(CMContext context)
        {
            const string booksJsonAddress = @"../Cocktail_Magician_DB/DataSeeder/JsonFiles/Ingredients.json";

            if (context.Ingredients.Any())
                return;

            var listIngredients = ReadFileDatabase.ReadJsonsSeeds<Bar>(booksJsonAddress);

            foreach (var ingredient in listIngredients)
            {
                context.Ingredients.Add(new Ingredient()
                {
                    Name = ingredient.Name
                });

                context.SaveChanges();
            }
        }
    }
}
