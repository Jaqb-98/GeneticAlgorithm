using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Mutations
{
    public class MutationRandomNumbers : IMutate<double>
    {



        public void Mutate(DNA<double> dna, float mutationChance,Random random)
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
