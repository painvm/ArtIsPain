using System;
using AutoMapper;

namespace ArtIsPain.Server.Map
{
    public abstract class BaseProfile : Profile
    {
        public BaseProfile()
        {
        }

        protected static DateTimeOffset? MapDate(DateTimeOffset? date)
        {
            if (!date.HasValue)
            {
                return null;
            }

            return MapDate(date.Value);
        }

        protected static DateTimeOffset MapDate(DateTimeOffset date)
        {
            return DateTime.SpecifyKind(date.UtcDateTime.Date, DateTimeKind.Utc);
        }
    }
}
