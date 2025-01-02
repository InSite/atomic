﻿using System;
using System.Linq;

namespace Atomic.Common
{
    public class Clock
    {
        public static DateTime NextCentury = new DateTime(2100, 1, 1, 0, 0, 0);

        public DateTimeOffset? ConvertTimeZone(DateTimeOffset? when, string tz)
        {
            const string utc = "UTC";

            if (!when.HasValue)
                return null;

            if (!IsValidTimeZone(tz) && IsValidTimeZone(utc))
                tz = utc;

            var info = TimeZoneInfo.FindSystemTimeZoneById(tz);
            var converted = TimeZoneInfo.ConvertTime(when.Value, info);
            return converted;
        }

        public bool IsValidTimeZone(string tz)
        {
            if (string.IsNullOrWhiteSpace(tz))
                return false;

            return TimeZoneInfo.GetSystemTimeZones().Any(x => x.Id == tz);
        }
    }
}