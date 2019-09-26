using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodFunday.Models
{
    public class ChangeColorModel
    {
        public class UserChange
        {
            [Required]
            public string Username { get; set; }
            [Required]
            public string Color { get; set; }
        }
    }
}