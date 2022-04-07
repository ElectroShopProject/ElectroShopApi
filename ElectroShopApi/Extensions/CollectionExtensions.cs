using System.Collections.Generic;

namespace ElectroShopApi
{
    public static class CollectionExtensions
    {
        public static List<T> Values<T>(this HashSet<T> set)
        {
            List<T> list = new();

            foreach (T element in set)
            {
                list.Add(element);
            }

            return list;
        }
    }
}
