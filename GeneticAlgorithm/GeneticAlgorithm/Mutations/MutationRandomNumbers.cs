using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Mutations
{
    public class MutationRandomNumbers : IMutate
    {
        private static Random random = new Random();

       
        public void Mutate(DNA dna, float mutationChance)
        {
            for (int i = 0; i < dna.Genes.Length; i++)
            {
                if (random.NextDouble() <= mutationChance)
                {
                    dna.Genes[i] = random.Next(0, 10);
                }
            }
        }
    }
}
