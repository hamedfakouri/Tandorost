using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.GlobalExtentions
{
    public static class GlobalExtention
    {
        public static string ToPersianLongDateTime(this DateTime dateTime)
        {
            PersianCalendar pc=new PersianCalendar();
            return string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", pc.GetYear(dateTime)
                ,pc.GetMonth(dateTime),pc.GetDayOfMonth(dateTime),pc.GetHour(dateTime)
                ,pc.GetMinute(dateTime),pc.GetSecond(dateTime),pc.GetMilliseconds(dateTime));
        }

        public static string ToPersianDateTimeNormalFormat(this DateTime dateTime)
        {
            PersianCalendar pc=new PersianCalendar();
            return string.Format("{0}-{1}-{2} {3}:{4}", pc.GetYear(dateTime), 
                pc.GetMonth(dateTime),pc.GetDayOfMonth(dateTime), pc.GetHour(dateTime)
                ,pc.GetMinute(dateTime));
        }
    }
}
