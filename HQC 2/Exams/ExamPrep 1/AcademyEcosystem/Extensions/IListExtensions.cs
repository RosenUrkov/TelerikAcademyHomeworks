namespace AcademyEcosystemCLI.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class IListExtensions
    {
        public static void RemoveAll<T>(this IList<T> list, Func<T,bool> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
}
