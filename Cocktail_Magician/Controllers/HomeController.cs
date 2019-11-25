﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cocktail_Magician.Models;
using Cocktail_Magician_Services.Contracts;
using Cocktail_Magician.Areas.BarMagician.Models;
using Cocktail_Magician.Infrastructure.Mappers;

namespace Cocktail_Magician.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBarManager _barManager;
        private readonly ICocktailManager _cocktailManager;

        public HomeController(ICocktailManager cocktailManager, IBarManager barManager)
        {
            _cocktailManager = cocktailManager;
            _barManager = barManager;
        }

        [ResponseCache(Duration = 10)]
        public async Task<IActionResult> Index()
        {
            var topBars = await _barManager.GetTopRatedBars();

            var topCocktails = await _cocktailManager.GetTopRatedCocktails();

            var topRatedHomePage = new TopRatedHomePageViewModel();
            topRatedHomePage.TopBars = topBars.ToVM();
            topRatedHomePage.TopCocktails = topCocktails.ToVM();

            return View(topRatedHomePage);
        }

        [ResponseCache(Duration = 10)]
        public async Task<IActionResult> BarCatalog()
        {
            var listOfBars = await _barManager.GetAllBarsAsync();
            var listOfBarsViewModel = new List<BarViewModel>();
            foreach (var bar in listOfBars)
            {
                var mapToView = bar.ToVM();
                listOfBarsViewModel.Add(mapToView);
            }
            return View(listOfBarsViewModel);
        }

        [ResponseCache(Duration = 10)]
        public async Task<IActionResult> CocktailCatalog()
        {
            var listOfCocktails = await _cocktailManager.GetAllCocktailsAsync();
            return View(listOfCocktails.ToCatalogVM());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 10)]
        public async Task<IActionResult> AboutUs()
        {
            var totalbars = await _barManager.GetAllBarsAsync();
            var totalCocktails = await _cocktailManager.GetAllCocktailsAsync();
            var aboutUs = new AboutUsViewModel()
            {
                TotalBars = totalbars.Count(),
                TotalCocktails = totalCocktails.Count()
            };
            return View(aboutUs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }
    }
}
