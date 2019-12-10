using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalCrossing.Models
{
    public class CatDate
    {
        public int CatDateId { get; set; }

        public int HostId { get; set; } // CatId
        [ForeignKey("HostId")]
        public Cat HostCat { get; set; }
        
        public int GuestId { get; set; } //CatId
        [ForeignKey("GuestId")]
        public Cat GuestCat { get; set; }

        public string Location { get; set; }
        public DateTime DateTime { get; set; }


        public CatDate()
        {
        }
    }
}
