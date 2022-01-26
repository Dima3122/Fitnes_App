using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Controller
{
    class FitnesContecst : DbContext
    {
        public FitnesContecst() : base("DBConnection") { }
        public DbSet<Activity> activities { get; set; }
        public DbSet<Exercise> exercises { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<Eating> eatings { get; set; }
    }
}
