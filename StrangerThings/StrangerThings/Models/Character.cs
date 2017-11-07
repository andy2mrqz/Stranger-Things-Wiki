using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StrangerThings.Models
{
    //This model is based off Characters table in the StrangerThings database
    [Table("Characters")]
    public class Character
    {
        //Declare the primary key
        [Key]
        public int CharacterID { get; set; }

        //Declare the other attributes
        public string CharacterFirstName { get; set; }
        public string CharacterLastName { get; set; }
        public string CharacterDescription { get; set; }
        public string Hometown { get; set; }
        public int YearOfBirth { get; set; }
        public string PhotoLocation { get; set; }
        public string Actor { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Quote { get; set; }

        //Collection of Questions (foreign key relationship)
        public ICollection<Question> Questions { get; set; }
    }
}