using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyJob.DataLayer.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValues<T>(this T e) where T : IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}