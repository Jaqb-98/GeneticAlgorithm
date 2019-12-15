using System;
using System.Linq;
using GeneticAlgorithm.Problems;

namespace GeneticAlgorithm
{
    public class DNA
    {
       
        public double[] Genes;

        private static Random random = new Random();

        /// <summary>
        /// Score that determines chance of reproduction
        /// </summary>
        private float Fitness;

        IProblem problem;

        public DNA(double[] genesValues,IProblem problem)
        {
            Genes = genesValues;
            this.problem = problem;
            
        }

        public DNA(int size)
        {
            Genes = new double[size]; 
        }

        public void SetFitness(float value)
        {
            Fitness = value;
        }

        public int GetGenesLength()
        {
            return Genes.Length;
        }

        public float GetFitness()
        {
            return Fitness;
        }


    }

}

