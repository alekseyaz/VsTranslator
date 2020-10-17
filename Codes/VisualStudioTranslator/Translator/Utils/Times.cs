﻿using System;

namespace VisualStudioTranslator.Translator.Utils
{
    internal static class Times
    {
        /// <summary>
        /// 获取时间戳 毫秒
        /// </summary>
        internal static long TimeStampWithMsec => Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
    }
}