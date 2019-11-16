﻿namespace Cocktail_Magician_DB.Models
{
    public class BarRating
    {
        public double Grade { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string BarId { get; set; }
        public Bar Bar { get; set; }
    }
}
