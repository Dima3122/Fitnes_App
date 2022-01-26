using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Controller
{
    public class DataBaseSaver : IDateSaver
    {
        public T Load<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Save(string fileName, object item)
        {
            using (var db = new FitnesContecst())
            {
                var type = item.GetType();
                if (type == typeof(User))
                {
                    db.users.Add(item as User);
                }
                else if (type == typeof(Activity))
                {
                    db.activities.Add(item as Activity);
                }
                else if (type == typeof(Eating))
                {
                    db.eatings.Add(item as Eating);
                }
                else if (type == typeof(Exercise))
                {
                    db.exercises.Add(item as Exercise);
                }
                else if (type == typeof(Food))
                {
                    db.foods.Add(item as Food);
                }
                else if (type == typeof(Gender))
                {
                    db.genders.Add(item as Gender);
                }
                db.SaveChanges();
            }
        }
    }
}
