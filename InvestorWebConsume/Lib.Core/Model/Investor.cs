using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lib.Core.Model
{
    public class Investor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Contact { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name="Total_Investment")]
        public decimal TotalInvestment { get; set; }
        public string Gender { get; set; }
    }
}
