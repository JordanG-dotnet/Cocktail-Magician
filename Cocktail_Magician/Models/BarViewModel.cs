﻿using Cocktail_Magician_DB.Models;
using System.ComponentModel.DataAnnotations;

namespace Cocktail_Magician.Models
{
    public class BarViewModel
    {
        public BarViewModel()
        {

        }
        public BarViewModel(Bar bar)
        {
            BarId = bar.BarId;
            Name = bar.Name;
            Address = bar.Address;
            Rating = bar.Rating;
            Information = bar.Information;
            Picture = bar.Picture;
            Map = bar.MapDirections;
        }
        public string BarId { get; set; }
        [Required(ErrorMessage = "A name is required!")]
        [MinLength(3, ErrorMessage = "Name should be between 3 and 35 symbols!"),
            MaxLength(35, ErrorMessage = "Name should be between 3 and 35 symbols!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "An address is required!")]
        [MinLength(5, ErrorMessage = "Address should at least 5 symbols!")]
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double Rating { get; set; }
        [MinLength(5, ErrorMessage = "Information should be atleast 5 symbols!")]
        public string Information { get; set; }
        public string Picture { get; set; }
        public string Map { get; set; }
    }
}
