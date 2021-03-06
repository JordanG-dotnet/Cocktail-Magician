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
        public DataSeeder()
        {

        }
        public static void SeedBars(CMContext context)
        {
            const string barsJsonAddress = @"../Cocktail_Magician_DB/DataSeeder/JsonFiles/Bars.json";

            if (context.Bars.Any())
                return;

            var listBars = ReadFileDatabase.ReadJsonsSeeds<Bar>(barsJsonAddress);

            foreach (var bar in listBars)
            {
                var barToAdd = new Bar()
                {
                    Name = bar.Name,
                    Address = bar.Address,
                    Rating = bar.Rating,
                    Information = bar.Information,
                    Picture = bar.Picture,
                    MapDirections = bar.MapDirections,
                    BarCocktails = new List<BarCocktail>()
                };

                foreach (var item in bar.BarCocktails)
                {
                    var cocktail = context.Cocktails.SingleOrDefault(c => c.Name == item.Cocktail.Name);
                    if (cocktail != null)
                    {
                        barToAdd.BarCocktails.Add(new BarCocktail
                        {
                            Bar = barToAdd,
                            Cocktail = cocktail
                        });
                    }
                }

                context.Bars.Add(barToAdd);
                context.SaveChanges();
            }
        }

        public static void SeedCocktails(CMContext context)
        {
            const string cocktailsJsonAddress = @"../Cocktail_Magician_DB/DataSeeder/JsonFiles/Cocktails.json";

            if (context.Cocktails.Any())
                return;

            var listCocktails = ReadFileDatabase.ReadJsonsSeeds<Cocktail>(cocktailsJsonAddress);

            foreach (var cocktail in listCocktails)
            {
                var cocktailToAdd = new Cocktail
                {
                    Name = cocktail.Name,
                    Rating = cocktail.Rating,
                    Picture = cocktail.Picture,
                    CocktailIngredient = new List<CocktailIngredient>()
                };
                foreach (var item in cocktail.CocktailIngredient)
                {
                    var ingredient = context.Ingredients.SingleOrDefault(i => i.Name == item.Ingredient.Name);
                    if (ingredient != null)
                    {
                        cocktailToAdd.CocktailIngredient.Add(new CocktailIngredient
                        {
                            Cocktail = cocktailToAdd,
                            Ingredient = ingredient
                        });
                    }
                }
                var cocktailInfo = new List<string>();
                foreach (var item in cocktail.CocktailIngredient)
                {
                    cocktailInfo.Add(item.Ingredient.Name);
                }
                var cocktailRecipe = String.Join(',', cocktailInfo);
                cocktailToAdd.Information = cocktailRecipe;

                context.Cocktails.Add(cocktailToAdd);
                context.SaveChanges();
            }
        }

        public static void SeedIngredients(CMContext context)
        {
            const string ingredientsJsonAddress = @"../Cocktail_Magician_DB/DataSeeder/JsonFiles/Ingredients.json";

            if (context.Ingredients.Any())
                return;

            var listIngredients = ReadFileDatabase.ReadJsonsSeeds<Ingredient>(ingredientsJsonAddress);

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
