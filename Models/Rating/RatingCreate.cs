using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.Rating
{
    public class RatingCreate
    {
        [Required]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        
        [Required]
        [Range(1, 5)]
        public double Score { get; set; }
    }
}