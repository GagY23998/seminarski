using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.HelperUser
{
    public class DateSent
    {
        public class Ago<T1,T2>
        {
            public T1 intValue;
            public T2 stringValue;
        }
            Ago<int, string> gagi = new Ago<int, string>();
        public Ago<int,string> Calculate(DateTime date)
        {
            TimeSpan temp = DateTime.Now.Subtract(date);
            if (temp.Days != 0) {
                gagi.intValue = temp.Days;
                gagi.stringValue = "days";
                return gagi;
            }
            if(temp.Hours != 0) {
                gagi.intValue = temp.Hours;
                gagi.stringValue = "hours";
                return gagi;
            }
            if (temp.Minutes !=0) {
                gagi.intValue = temp.Minutes;
                gagi.stringValue = "minutes";
                return gagi;
            }
            if (temp.Seconds != 0)
            {
                gagi.intValue = temp.Seconds;
                gagi.stringValue = "seconds";

            }
            return gagi;
        }

    }
}
