using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GeneticAlgorithm
{

    public static class ThreadLocalRandom
    {

        private static readonly Random globalRandom = new Random();
        private static readonly object globalLock = new object();


        private static readonly ThreadLocal<Random> threadRandom = new ThreadLocal<Random>(NewRandom);


        public static Random NewRandom()
        {
            lock (globalLock)
            {
                return new Random(globalRandom.Next());
            }
        }

        public static Random Instance { get { return threadRandom.Value; } }


        public static int Next()
        {
            return Instance.Next();
        }

        public static int Next(int maxValue)
        {
            return Instance.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return Instance.Next(minValue, maxValue);
        }

        public static double NextDouble()
        {
            return Instance.NextDouble();
        }

      
    }
}

