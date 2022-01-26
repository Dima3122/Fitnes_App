using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Controller
{
    public interface IDateSaver
    {
        T Load<T>(string fileName);
        void Save(string fileName, object item);
    }
}
