using Academy.Framework.Core.Contracts;
using System;

namespace Academy.Core.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public static IDateTimeProvider Provider { get; set; } = new DateTimeProvider();

        public DateTime GetDateTime()
        {
            return new DateTime(2017, 1, 16, 0, 0, 0);
        }
    }
}
