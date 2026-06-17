using System.ComponentModel.DataAnnotations;

namespace NZwalks.Api.Models.DTO
{
    public class AddRequestRegionDto
    {
        [Required(ErrorMessage ="Name should not be empty")]
        [MinLength(3,ErrorMessage ="Name length should be minimum 3")]
          public string Name { get; set; }
          
          [Required(ErrorMessage ="Code should not be empty")]
          [MaxLength(100,ErrorMessage ="Code has not be above 100")]
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}