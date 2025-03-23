using NodaTime;
using NodaTime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Helpers
{
    public static class DateTimeHelpers
    {
        public static IsoDayOfWeek ConvertToIsoDayOfWeek(string day)
        {
            return day.ToLower() switch
            {
                "monday" => IsoDayOfWeek.Monday,
                "tuesday" => IsoDayOfWeek.Tuesday,
                "wednesday" => IsoDayOfWeek.Wednesday,
                "thursday" => IsoDayOfWeek.Thursday,
                "friday" => IsoDayOfWeek.Friday,
                "saturday" => IsoDayOfWeek.Saturday,
                "sunday" => IsoDayOfWeek.Sunday,
                _ => throw new ArgumentException("Invalid day of the week", nameof(day))
            };
        }

        public static DateOnly CalculateNextBackorderDeliveryDate(string dayOfWeek)
        {

            IsoDayOfWeek deliveryDayOfWeek = ConvertToIsoDayOfWeek(dayOfWeek);

            var now = SystemClock.Instance.GetCurrentInstant();
            var timeZone = DateTimeZoneProviders.Tzdb["UTC"];
            var zonedDateTime = now.InZone(timeZone);
            var today = zonedDateTime.LocalDateTime.Date;

            DateOnly startOfWeek = today.ToDateOnly();
            DateOnly endOfWeek = today.ToDateOnly();
            var defaultDeliveryDate = today.Next(deliveryDayOfWeek);

            while (startOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                startOfWeek = startOfWeek.AddDays(-1);
            }

            while (endOfWeek.DayOfWeek != DayOfWeek.Sunday)
            {
                endOfWeek = endOfWeek.AddDays(1);
            }

            if (defaultDeliveryDate.ToDateOnly() <= endOfWeek)
            {
                defaultDeliveryDate.PlusWeeks(1);
            }

            return defaultDeliveryDate.ToDateOnly();
        }

        //public static DateOnly CalculateNextStandardDeliveryDate(string dayOfWeek)
        //{

        //    IsoDayOfWeek deliveryDayOfWeek = ConvertToIsoDayOfWeek(dayOfWeek);

        //    var now = SystemClock.Instance.GetCurrentInstant();
        //    var timeZone = DateTimeZoneProviders.Tzdb["UTC"];
        //    var zonedDateTime = now.InZone(timeZone);
        //    var today = zonedDateTime.LocalDateTime.Date;

        //    DateOnly startOfWeek = today.ToDateOnly();
        //    DateOnly endOfWeek = today.ToDateOnly();
        //    var defaultDeliveryDate = today.Next(deliveryDayOfWeek);

        //    while (startOfWeek.DayOfWeek != DayOfWeek.Monday)
        //    {
        //        startOfWeek = startOfWeek.AddDays(-1);
        //    }

        //    while (endOfWeek.DayOfWeek != DayOfWeek.Sunday)
        //    {
        //        endOfWeek = endOfWeek.AddDays(1);
        //    }

        //    // Calculate Wednesday of the current week
        //    DateOnly wednesdayOfWeek = startOfWeek.AddDays(2);

        //    if (defaultDeliveryDate.ToDateOnly() <= wednesdayOfWeek)
        //    {
        //        defaultDeliveryDate = defaultDeliveryDate.PlusWeeks(1);
        //    }

        //    return defaultDeliveryDate.ToDateOnly();
        //}

        public static DateOnly CalculateNextStandardDeliveryDate(string dayOfWeek)
        {
            IsoDayOfWeek deliveryDayOfWeek = ConvertToIsoDayOfWeek(dayOfWeek);

            // Get the current date and time in UTC
            var now = SystemClock.Instance.GetCurrentInstant();
            var timeZone = DateTimeZoneProviders.Tzdb["UTC"];
            var zonedDateTime = now.InZone(timeZone);
            var today = zonedDateTime.LocalDateTime.Date;
            DateOnly todayDate = today.ToDateOnly();

            // Determine the last automatic submission time (Wednesday 11:59 PM)
            DateOnly lastSubmissionDate = todayDate;
            while (lastSubmissionDate.DayOfWeek != DayOfWeek.Wednesday)
            {
                lastSubmissionDate = lastSubmissionDate.AddDays(1);
            }

            // If today is before or on the Wednesday submission, shift delivery date forward
            if (todayDate <= lastSubmissionDate)
            {
                // Get next delivery day **AFTER** Wednesday
                return NextOccurrenceAfter(lastSubmissionDate, deliveryDayOfWeek);
            }
            else
            {
                // If today is **after** submission (Thursday onward), return next delivery day normally
                return NextOccurrenceAfter(todayDate, deliveryDayOfWeek);
            }
        }

        private static DateOnly NextOccurrenceAfter(DateOnly referenceDate, IsoDayOfWeek targetDayOfWeek)
        {
            DateOnly nextDate = referenceDate;
            while ((IsoDayOfWeek)nextDate.DayOfWeek != targetDayOfWeek)
            {
                nextDate = nextDate.AddDays(1);
            }
            return nextDate;
        }
    }
}
