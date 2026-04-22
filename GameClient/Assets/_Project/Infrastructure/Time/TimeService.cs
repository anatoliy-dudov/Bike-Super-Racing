using System;
using BikeSuperRacing.Core.Interfaces;

namespace BikeSuperRacing.Infrastructure.Time
{
    public sealed class TimeService : ITimeService
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
