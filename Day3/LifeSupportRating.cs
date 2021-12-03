using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class LifeSupportRating
    {
        public static int Get(string[] inputs)
        {
            var mostcommon = inputs;
            var leastCommon = inputs;

            var index = 0;
            while (mostcommon.Length > 1 || leastCommon.Length > 1)
            {
                mostcommon = GetMostCommon(mostcommon, index);
                leastCommon = GetLeastCommon(leastCommon, index);
                index++;
            }

            var oxygenGeneratorRating = Convert.ToInt32(mostcommon[0], 2);
            var co2ScrubberRating = Convert.ToInt32(leastCommon[0], 2);

            return oxygenGeneratorRating * co2ScrubberRating;
        }

        private static string[] GetMostCommon(string[] inputs, int index)=>
            Get(
                inputs,
                index,
                (dict) => dict['1'].ToArray(),
                (dict) => dict.Max(g => g.Value.Count()));

        private static string[] GetLeastCommon(string[] inputs, int index) =>
            Get(
                inputs,
                index,
                (dict) => dict['0'].ToArray(),
                (dict) => dict.Min(g => g.Value.Count()));

        private static string[] Get(
            string[] inputs,
            int index,
            Func<Dictionary<char, IGrouping<char, string>>, string[]> defaultWhenEqual,
            Func<Dictionary<char, IGrouping<char, string>>, int> compareValue)
        {
            if (inputs.Length == 1)
                return inputs;

            var groups = inputs
                .GroupBy(s => s[index])
                .ToDictionary(g => g.Key);

            return groups['0'].Count() == groups['1'].Count() ?
                defaultWhenEqual(groups) :
                groups
                    .First(g => g.Value.Count() == compareValue(groups))
                    .Value
                    .ToArray();
        }
    }
}