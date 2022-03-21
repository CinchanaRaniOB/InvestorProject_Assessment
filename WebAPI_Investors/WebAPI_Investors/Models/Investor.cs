using System;
using System.Collections.Generic;

namespace WebAPI_Investors.Models
{
    public partial class Investor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Contact { get; set; }
        public string ProfilePictureUrl { get; set; }
        public decimal? TotalInvestment { get; set; }
        public string Gender { get; set; }
    }
}
