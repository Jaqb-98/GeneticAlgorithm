using System;
using System.Linq;
using System.Collections;
using GeneticAlgorithm.Problems;

namespace GeneticAlgorithm
{
    public class DNA<T>
    {
       
        public T[] Genes;

        //private static Random random = new Random();

        /// <summary>
        /// Score that determines chance of reproduction
        /// </summary>
        private float Fitness;

        IProblem<T> problem;

        public DNA(T[] genesValues,IProblem<T> problem)
        {
            Genes = genesValues;
            this.problem = problem;
            
        }

        public DNA(int size)
        {
            Genes = new T[size]; 
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

