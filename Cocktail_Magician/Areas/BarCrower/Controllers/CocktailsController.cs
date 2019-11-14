﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cocktail_Magician_DB;
using Cocktail_Magician_DB.Models;
using Cocktail_Magician_Services.Contracts;
using Cocktail_Magician.Areas.BarMagician.Models;
using Cocktail_Magician.Areas.BarCrower.Models;
using System.Security.Claims;
using Cocktail_Magician.Infrastructure.Mappers;
using Cocktail_Magician_Services.DTO;
using Cocktail_Magician.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cocktail_Magician.Areas.BarCrower.Controllers
{
    [Area("BarCrower")]
    public class CocktailsController : Controller
    {
        private readonly CMContext _context;
        private readonly ICocktailManager _cocktailManager;

        public CocktailsController(ICocktailManager cocktailManager, CMContext context)
        {
            _context = context;
            _cocktailManager = cocktailManager;
        }

        // GET: BarCrower/Cocktails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktail = await _cocktailManager.GetCocktail(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            var cocktailViewModel = new CocktailViewModel(cocktail);
            return View(cocktailViewModel);
        }
        [Authorize(Roles = "Member")]
        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Review(CreateReviewViewModel reviewVeiwModel)
        {
            var user = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            reviewVeiwModel.UserId = user;
            var cocktailReview = reviewVeiwModel.ToCocktailDTO();

            if (ModelState.IsValid)
            {
                await _cocktailManager.CreateCocktailReviewAsync(cocktailReview);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}
