using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StrangerThings.Models
{
    //This model is based off the Questions Table in the database
    [Table("Questions")]
    public class Question
    {
        //Primary Key
        public int QuestionID { get; set; }
        public int UserID { get; set; }

        //Foreign Key to Character Table
        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }

        //Other Attributes
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
    }
}