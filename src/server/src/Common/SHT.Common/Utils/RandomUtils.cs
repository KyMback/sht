using System;
using System.Collections.Generic;
using System.Linq;

namespace SHT.Common.Utils
{
    public static class RandomUtils
    {
        public static IReadOnlyList<int> GenerateRandomSequence(int from, int count)
        {
            var random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
            return Enumerable.Range(from, count).OrderBy(x => random.Next()).ToArray();
        }
    }
}