using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Mission_6_dredd3.Models;

namespace MoveEntryModel.Models
{
    public class MovieEntry
    {
        // Variables that are used in the get and set
        [Required]
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public short Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }

        // create foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}