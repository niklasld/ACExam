using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalCrossing.Models.ViewModels
{
    public class CatVm
    {
        public int CatId { get; set; }


        [Required(ErrorMessage = "All cats must have a name")]
        public string Name { get; set; }


        // Later, create 1-to-many relationship to Species table
        //public string Species { get; set; 

        /*[Display(Name = "Birth date")]
        [DataType(DataType.Date)] 
        [Required]*/
        public DateTime BirthDate { get; set; }

        public string ProfilePicture { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Description { get; set; }

        // ratings... Comments, Reviews

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

 

        public CatVm()
        {
        }
    }
}
