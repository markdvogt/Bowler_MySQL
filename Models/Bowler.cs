using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler_MySQL.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }

        //Build a foreign key relationship

        //[ForeignKey ("Team")] //You can use this if it's not recognizing the foreign key
        public int TeamID { get; set; }
        public Team Team { get; set; } // This pair of things together (the primary key in the other table paired with an instance of that type) creates a foreign key relationship in the table

    }
}
