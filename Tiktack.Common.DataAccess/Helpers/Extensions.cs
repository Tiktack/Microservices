using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tiktack.Common.DataAccess.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<string> GetNavigationProps(this Type entityType)
        {
            return entityType.GetProperties()
                .Where(p =>
                    typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                    && p.PropertyType != typeof(string)
                    || p.PropertyType.Namespace == entityType.Namespace)
                .Select(p => p.Name);
        }
    }
}
