
using System.ComponentModel.DataAnnotations;

namespace NZwalks.Api.Models.DTO
{
    public class UpdateRequestWalkDto
    {
       [Required]
        [StringLength(10,MinimumLength =2)]
        public string Name { get; set; }
         [Required]
         [MaxLength(100)]
       public string Description { get; set; }
        [Required]
        [Range(1,30)]
        public double LengthInKm { get; set; }
         
        public string? WalkImageUrl { get; set; }
         [Required]
        public Guid RegionId { get; set; }
         [Required]

        public Guid DifficultyId { get; set; }
    }
}