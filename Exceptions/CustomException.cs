using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Exceptions
{
    public class CustomException:Exception
    {
        public CustomException():base()
        {
            Console.WriteLine("default mesaj");
        }
        public CustomException(string message):base(message)
        {
            
        }
    }
}
