using System;

namespace VisualStudioTranslator.Utils
{
    internal static class Times
    {
        /// <summary>
        /// Get timestamp in milliseconds
        /// </summary>
        internal static long TimeStampWithMsec => Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
    }
}