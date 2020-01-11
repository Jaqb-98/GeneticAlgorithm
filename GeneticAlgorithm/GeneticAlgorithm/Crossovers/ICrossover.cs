using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Crossovers
{
    public interface ICrossover<T>
    {
        /// <summary>
        /// Creates a child from parents genes
        /// </summary>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        DNA<T> Crossover(DNA<T> parent1, DNA<T> parent2, DNA<T> parent3, DNA<T> parent4, Random random);
    }
}
