using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelsApp.Data
{
    public class HotelReview
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? HotelName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Location { get; set; }
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
        public float Rating { get; set; }
        
        [Url]
        [StringLength(500)]
        public string? ImageUrl { get; set; } 
        
        [StringLength(100)]
        public string? UserName { get; set; }
        }
}