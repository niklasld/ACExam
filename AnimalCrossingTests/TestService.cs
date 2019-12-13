using System;
using System.Collections.Generic;
using AnimalCrossing.Models;

namespace AnimalCrossingTests
{
    public class TestService
    {

        public static List<Species> GetTestSpecies()
        {
            var species = new List<Species>();
            species.Add(new Species()
            {
                SpeciesId = 1,
                Name = "African Golden Cat",
                Description = "The African golden cat is a wild cat endemic to the rainforests of West and Central Africa",
            });
            species.Add(new Species()
            {
                SpeciesId = 2,
                Name = "Wildcat Cat",
                Description = "The wildcat is a species complex comprising two small wild cat species, the European wildcat and the African wildcat",
            });

            return species;
        }




        public static List<CatDate> GetCatDates()
        {
            var species = new Species {SpeciesId = 1, Description = "The black cats originated in the halloween", Name = "Black cat" };
            var species2 = new Species { SpeciesId= 2, Description = "Ginger Cats likes GingerBread", Name = "Ginger Cat"};

            var cat1 = new Cat {Name = "Black Cat", Gender = Gender.Female, BirthDate = DateTime.Now, ProfilePicture = "https://assets3.thrillist.com/v1/image/2847067/size/tmg-article_tall.jpg"
            , CatId = 1, Description = "Black Cats likes Halloween", Species = species, SpeciesId  = 1};
            var cat2 = new Cat {Name = "Ginger Cat", Gender = Gender.Male, BirthDate = DateTime.Now, ProfilePicture = "https://cmkt-image-prd.freetls.fastly.net/0.1.0/ps/4142278/1820/1213/m1/fpnw/wm1/srsupadpwabt3qb65uy33d7enwr2c8cy1jyankqowku3spdrw7cf9x9wefdcejup-.jpg?1521200854&s=617da81288b584e780f1244e837be67f"
            , CatId = 2, Description = "Ginger cats likes lasagna", Species = species2, SpeciesId = 2};


            var CatDate = new List<CatDate>();
            CatDate.Add(new CatDate()
            {
                CatDateId = 1,
                HostId = 1,
                HostCat = cat1,
                GuestId = 2,
                GuestCat = cat2,
                DateTime = DateTime.Now,
                Location = "Randers"
            }) ;
            return CatDate; 
        }

        public static List<Cat> CatTestList()
        {
            var catList = new List<Cat>();
            catList.Add(new Cat()
            {
                CatId = 1,
                Name = "Test1",
                Gender = 0,
                SpeciesId = 1
            } as Cat);

            catList.Add(new Cat()
            {
                CatId = 2,
                Name = "Test2",
                Gender = 0,
                SpeciesId = 0
            } as Cat);
            catList.Add(new Cat()
            {
                CatId = 3,
                Name = "Test3",
                Gender = 0,
                SpeciesId = 0
            } as Cat);


            return catList;
        }

        public static List<Cat> Delete(int catId)
        {
            var catList = CatTestList();
            catList.ForEach(element => { 
                if(element.CatId == catId)
                {
                    catList.Remove(element);
                }
            });

            return catList;
        }

        public TestService()
    {
    }
    }
}
