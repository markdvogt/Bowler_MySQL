using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler_MySQL.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string CaptainID { get; set; }
    }
}
