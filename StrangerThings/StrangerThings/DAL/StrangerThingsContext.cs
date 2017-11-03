using StrangerThings.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrangerThings.DAL
{
    public class StrangerThingsContext : DbContext
    {
        public StrangerThingsContext() : base("StrangerThingsContext")
        {

        }

        //Create the DbSets for the different models
        public DbSet<Character> Characters { get; set; }
    }
}