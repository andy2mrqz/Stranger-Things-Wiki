using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrangerThings.Models
{
    public class CharacterQuestion
    {
        public Character Character { get; set; }
        public List<Question> Questions { get; set; }
    }
}