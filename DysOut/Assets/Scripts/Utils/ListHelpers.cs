using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Dys_The_Game.Utils
{
    public static class ListHelpers
    {
        public static T GetRandom<T>(this List<T> list, T[] exclude = null) {
            Random random = new Random();
            int randomId = random.Next(list.Count);
            T randomItem = list[randomId];

            if (exclude != null && exclude.Contains(randomItem))
                randomItem = list.GetRandom(exclude);
            
            return randomItem;
        }
    }
}