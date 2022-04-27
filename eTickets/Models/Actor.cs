using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key] public int Id { get; set; }
        
        [Display(Name = "Profile picture")]
        [Required(ErrorMessage = "Profile picture is required!")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Fullname is required!")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 30 length!")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required!")]
        public string Bio { get; set; }
        
        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}