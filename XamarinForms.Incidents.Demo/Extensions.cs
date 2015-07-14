﻿using System;

namespace XamarinForms.Incidents.Demo
{
    public static class Extensions
    {
        public static bool Contains (this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf (toCheck, comp) >= 0;
        }
    }
}


