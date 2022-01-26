using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity(string name, double caloriesperminute)
        {
            Name = name;
            CaloriesPerMinute = caloriesperminute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
