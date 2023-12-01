using Microsoft.AspNetCore.Authentication;

namespace C_proj_MKMN.Services
{
    public class UtcSystemClock : ISystemClock
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
