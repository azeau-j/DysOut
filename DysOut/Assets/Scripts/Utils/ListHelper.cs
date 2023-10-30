using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Dys_The_Game.Utils
{
    public static class ListHelper
    {
        public static T GetRandom<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
    }
    }
}