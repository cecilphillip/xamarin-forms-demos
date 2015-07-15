using System;
using System.Collections.Generic;

namespace XamarinForms.Incidents.Demo
{
    public static class Extensions
    {
        public static bool Contains (this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf (toCheck, comp) >= 0;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> next)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (next == null)
                throw new ArgumentNullException("next");

            var i = 0;
            foreach (var item in source)
                next(item, i++);
        }
    }
}


