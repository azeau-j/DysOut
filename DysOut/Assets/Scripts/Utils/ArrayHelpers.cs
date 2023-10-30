using System;
using System.Linq;

namespace Dys_The_Game.Utils
{
    public static class ArrayHelpers
    {
        public static T GetRandom<T>(this T[] list, T[] exclude = null) {
            Random random = new Random();
            int randomId = random.Next(list.Length);
            T randomItem = list[randomId];

            if (exclude != null && exclude.Contains(randomItem))
                randomItem = list.GetRandom(exclude);
            
            return randomItem;
        }
    }
}