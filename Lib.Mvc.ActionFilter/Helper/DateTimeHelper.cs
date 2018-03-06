using System;

namespace Lib.Mvc.ActionFilter
{
    public static class DateTimeHelper
    {
        public static string ToCustomString(this DateTime helper)
        {
            return helper.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}