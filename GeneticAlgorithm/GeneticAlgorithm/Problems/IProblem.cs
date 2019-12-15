using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Problems
{
    public interface IProblem
    {
        double[][] Data { get; set; }

        int DNALength { get; set; }
        double[] Target { get; }

        void CalculateFitness(DNA[] dna, double[] target);
    }
}
