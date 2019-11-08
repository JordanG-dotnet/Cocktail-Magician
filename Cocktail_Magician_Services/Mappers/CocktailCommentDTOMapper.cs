﻿using Cocktail_Magician_DB.Models;
using Cocktail_Magician_Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cocktail_Magician_Services.Mappers
{
    public static class CocktailCommentDTOMapper
    {
        public static CocktailCommentDTO ToDTO(this CocktailComment cocktailComment)
        {
            var cocktailCommentDTO = new CocktailCommentDTO
            {
                UserId = cocktailComment.UserId,
                CocktailId = cocktailComment.CocktailId,
                Comment = cocktailComment.Comment
            };
            return cocktailCommentDTO;
        }

        public static ICollection<CocktailCommentDTO> ToDTO(this ICollection<CocktailComment> cocktailComments)
        {
            var newCollection = cocktailComments.Select(c => c.ToDTO()).ToList();
            return newCollection;
        }

    }
}
