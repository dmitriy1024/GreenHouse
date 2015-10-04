using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenHouse.WebUI.Infrastructure
{
    public static class DateTimeExtentions
    {
        public static string GetRusDayOfWeek(this DateTime date)
        {
            string dayOfWeek = "";
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayOfWeek = "Понедельник";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "Вторник";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "Среда";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "Четверг";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "Пятница";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "Суббота";
                    break;
                case DayOfWeek.Sunday:
                    dayOfWeek = "Воскресенье";
                    break;
            }
            return dayOfWeek;
        }

        public static string GetShortRusDayOfWeek(this DateTime date)
        {
            string dayOfWeek = "";
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayOfWeek = "Пн";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "Вт";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "Ср";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "Чт";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "Пт";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "Сб";
                    break;
                case DayOfWeek.Sunday:
                    dayOfWeek = "Вс";
                    break;
            }
            return dayOfWeek;
        }
    }
}