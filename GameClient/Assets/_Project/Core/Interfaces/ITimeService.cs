using System;

namespace BikeSuperRacing.Core.Interfaces
{
    public interface ITimeService
    {
        DateTime GetUtcNow();
    }
}
