﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Cocktail_Magician.Models
{
    public class CreateReviewViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        [MaxLength(500, ErrorMessage = "Max length is 500 characters!")]
        public string Comment { get; set; }
        public double Rate { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now.Date;
    }
}
