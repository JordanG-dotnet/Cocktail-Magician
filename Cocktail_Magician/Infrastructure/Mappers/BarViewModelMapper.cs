﻿using Cocktail_Magician.Areas.BarMagician.Models;
using Cocktail_Magician_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cocktail_Magician.Infrastructure.Mappers
{
    public static class BarViewModelMapper
    {
        public static BarViewModel MapBarViewModel(this Bar bar)
        {
            var barViewModel = new BarViewModel();
            barViewModel.BarId = bar.BarId;
            barViewModel.Address = bar.Address;
            barViewModel.Cocktails = new List<CocktailViewModel>();
            foreach (var cocktail in bar.Cocktails)
            {
                var cocktailViewModel = new CocktailViewModel 
                {
                    CocktailId = cocktail.Id,
                    Name = cocktail.Name
                };
                barViewModel.Cocktails.Add(cocktailViewModel);
            }
            barViewModel.Information = bar.Information;
            barViewModel.Map = bar.MapDirections;
            barViewModel.Name = bar.Name;
            barViewModel.Picture = bar.Picture;
            barViewModel.Rating = bar.Rating;
            return barViewModel;
        }
    }
}