using System;

namespace Atomic.Common
{
    public class LockoutCollection
    {
        public Lockout[] Items { get; set; }

        public Lockout Upcoming { get; set; }

        public DateTimeOffset? UpcomingDeadline { get; set; }

        public string UpcomingDuration { get; set; }

        public Lockout Current { get; set; }

        public LockoutCollection()
        {
            Items = new Lockout[0];
        }

        public LockoutCollection(Lockout[] lockouts, DateTimeOffset when, string enterprise, string environment, string[] roles)
        {
            if (lockouts == null || lockouts.Length == 0)
                return;

            Items = lockouts;

            // If there is an active lockout, then it is the current lockout.

            foreach (var lockout in lockouts)
            {
                if (lockout.IsActive(when, enterprise, environment))
                {
                    Current = lockout;
                    return;
                }
            }

            // If there is a lockout upcoming within the next hour, then set it as the upcoming lockout.

            foreach (var lockout in lockouts)
            {
                var next = lockout.MinutesUntilNextActualStartTime(when, enterprise, environment);

                if (next != null && next.Value < 60)
                {
                    Upcoming = lockout;
                    UpcomingDeadline = lockout.NextActualStartTime(when, enterprise, environment);
                    UpcomingDuration = lockout.Interval.Length;
                    return;
                }
            }
        }
    }
}