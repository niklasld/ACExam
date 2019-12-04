using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalCrossing.Models
{
    public class Cat
    {

       // List<Cat> cats = new List<Cat>();


        public int CatId { get; set; }

        
        [Required(ErrorMessage = "All cats must have a name")]
        public string Name { get; set; }


        // Later, create 1-to-many relationship to Species table
        //public string Species { get; set; }

        [Required(ErrorMessage = "These are the only options for genders you can select for your cat")]
        public Gender Gender { get; set; }

        /*[Display(Name = "Birth date")]
        [DataType(DataType.Date)] 
        [Required]*/
        public DateTime BirthDate { get; set; }

        public string ProfilePicture { get; set; }

        [StringLength( 100, MinimumLength = 0)]
        public string Description { get; set; }

        // ratings... Comments, Reviews

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        public Cat()
        {
        }
    }

public enum Gender {Male, Female, other};

}
