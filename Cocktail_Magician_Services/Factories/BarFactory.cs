﻿using Cocktail_Magician_DB.Models;
using Cocktail_Magician_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktail_Magician_Services.Factories
{
    public class BarFactory : IBarFactory
    {
        public Bar CreateNewBar(string name, string address, string information, string picture, string mapDirection)
        {
            if (name.Length < 3 || name.Length > 35)
                throw new Exception("Name should be between 3 and 35 symbols!");
            if (address.Length < 5)
                throw new Exception("Address should be at least 5 symbols!");
            if (information.Length < 5)
                throw new Exception("Information should be atleast 5 symbols!");

            return new Bar(name, address, information, picture, mapDirection);
        }

        public BarReview CreateNewBarReview(double grade, string comment, string userId, string barId, DateTime createdOn)
        {
            if (comment.Length > 500)
                throw new Exception("Comment should be not more than 500 characters!");
            if(grade < 0 || grade > 5)
                throw new Exception("Grade should be between 0 and 5!");
            return new BarReview(grade, comment, userId, barId, createdOn);
        }
    }
}
