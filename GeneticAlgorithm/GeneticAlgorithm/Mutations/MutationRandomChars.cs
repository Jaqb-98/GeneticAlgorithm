using System;
using System.Collections.Generic;
using System.Text;
using System.Text;

namespace GeneticAlgorithm.Mutations
{
    public class MutationRandomChars : IMutate<char>
    {
        private static Random random = new Random();
        public void Mutate(DNA<char> dna, float mutationChance)
        {
            for (int i = 0; i < dna.Genes.Length; i++)
            {
                
                if (random.NextDouble() <= mutationChance)
                {
                    dna.Genes[i] =(char) random.Next(32, 126);
                }
            }
        }
    }
}
