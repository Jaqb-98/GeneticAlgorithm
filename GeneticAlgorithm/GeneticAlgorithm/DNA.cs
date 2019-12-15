using System;
using System.Linq;

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

        public DNA(double[] genesValues)
        {
            Genes = genesValues;
            
        }

        public DNA(int size)
        {
            Genes = new double[size];
            
        }


        public void CalculateFitness(double[] target)
        {
            int score = 0;
            for (int i = 0; i < Genes.Length; i++)
            {
                if (Genes[i] == target[i])
                {
                    score++;
                }
            }
            float fit = (float)score / Genes.Length;

            SetFitness(fit);

        }



        /// <summary>
        /// Creates a new DNA object using it's parents genes
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public DNA Crossover(DNA partner)
        {
            DNA child = new DNA(Genes.Length);

            int midpoint = random.Next(0,Genes.Length);
            for (int i = 0; i < Genes.Length; i++)
            {
                if (i < midpoint) child.Genes[i] = partner.Genes[i];
                else              child.Genes[i] = Genes[i];
               
            }
            return child;
        }


        /// <summary>
        /// Have chance to change genes in DNA object, based on mutation chance
        /// </summary>
        /// <param name="mutationChance"></param>
        public void Mutate(float mutationChance)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() <= mutationChance)
                {
                    Genes[i] = random.Next(0, 10);
                }
            }

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

