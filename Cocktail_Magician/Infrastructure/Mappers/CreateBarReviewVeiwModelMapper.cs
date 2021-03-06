﻿using Cocktail_Magician.Models;
using Cocktail_Magician_Services.DTO;

namespace Cocktail_Magician.Infrastructure.Mappers
{
    public static class CreateBarReviewVeiwModelMapper
    {
        public static BarReviewDTO ToBarDTO(this CreateReviewViewModel createReviewViewModel)
        {
            var barCommentDTO = new BarReviewDTO
            {
                BarId = createReviewViewModel.Id,
                UserId = createReviewViewModel.UserId,
                Comment = createReviewViewModel.Comment,
                Grade = createReviewViewModel.Rate,
                DateCreated = createReviewViewModel.DateCreated
            };
            return barCommentDTO;
        }

        //public static ICollection<BarCommentDTO> ToDTO(this ICollection<CreateReviewViewModel> createReviewViewModels)
        //{
        //    var newCollection = createReviewViewModels.Select(c => c.ToDTO()).ToList();
        //    return newCollection;
        //}
    }
}
