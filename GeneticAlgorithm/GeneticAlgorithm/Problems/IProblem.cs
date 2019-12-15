using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Problems
{
    public interface IProblem<T>
    {
        T[][] Data { get; set; }

        int DNALength { get; set; }
        T[] Target { get; }


        /// <summary>
        /// Calculates fitness score for every member of the population
        /// </summary>
        /// <param name="population"></param>
        /// <param name="target"></param>
        void CalculateFitness(DNA<T>[] population, T[] target);
    }
}
