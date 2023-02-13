using Microsoft.EntityFrameworkCore;
using MoveEntryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_6_dredd3.Models
{
    public class DataBaseContext : DbContext
    {
        //Constructor
        public DataBaseContext (DbContextOptions<DataBaseContext> options) : base (options)
        {
            // blank
        }

        public DbSet<MovieEntry> responses { get; set; }
    }
}
