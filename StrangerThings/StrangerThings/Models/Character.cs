using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("First Name")]
        public string CharacterFirstName { get; set; }
        [DisplayName("Last Name")]
        public string CharacterLastName { get; set; }
        [DisplayName("Description")]
        public string CharacterDescription { get; set; }
        public string Hometown { get; set; }
        [DisplayName("Year of Birth")]
        public int YearOfBirth { get; set; }
        [DisplayName("Photo Location")]
        public string PhotoLocation { get; set; }
        public string Actor { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Quote { get; set; }

        //Collection of Questions (foreign key relationship)
        public ICollection<Question> Questions { get; set; }
    }
}