using System;

namespace Day3
{
    public static class PowerConsumption
    {
        public static int Get(string[] inputs)
        {
            var counts = new int[2, 12];
            foreach (var input in inputs)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case '0':
                            counts[0, i]++;
                            break;
                        case '1':
                            counts[1, i]++;
                            break;
                    }
                }
            }

            var gamma = string.Empty;
            var epsilon = string.Empty;
            for (var i = 0; i < counts.GetLength(1); i++)
            {
                gamma += counts[0, i] > counts[1, i] ? '0' : '1';
                epsilon += counts[0, i] < counts[1, i] ? '0' : '1';
            }

            var nrGamma = Convert.ToInt32(gamma, 2);
            var nrEpsilon = Convert.ToInt32(epsilon, 2);

            return nrGamma * nrEpsilon;
        }
    }
}