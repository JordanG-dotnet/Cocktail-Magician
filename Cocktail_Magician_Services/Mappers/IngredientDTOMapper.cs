﻿using Cocktail_Magician_DB.Models;
using Cocktail_Magician_Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Cocktail_Magician_Services.Mappers
{
    public static class IngredientDTOMapper 
    {
        public static IngredientDTO ToDTO(this Ingredient ingredient)
        {
            var ingredientDTO = new IngredientDTO
            {
                 Id = ingredient.IngredientId,
                 Name = ingredient.Name
            };
            return ingredientDTO;
        }

        public static Ingredient ToEntity(this IngredientDTO ingredientDTO)
        {
            var ingredient = new Ingredient
            {
                IngredientId = ingredientDTO.Id,
                Name = ingredientDTO.Name
            };
            return ingredient;
        }

        public static ICollection<IngredientDTO> ToDTO(this ICollection<Ingredient> ingredients)
        {
            var newCollection = ingredients.Select(c =>c.ToDTO()).ToList();
            return newCollection;
        }
    }
}
