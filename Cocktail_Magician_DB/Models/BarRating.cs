﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktail_Magician_DB.Models
{
    public class BarRating
    {
        public int Grade { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string BarId { get; set; }
        public Bar Bar { get; set; }
    }
}