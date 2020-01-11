using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Mutations
{
    public class MutateBinary : IMutate<double>
    {

 
        public void Mutate(DNA<double> dna, float mutationChance,Random random)
        {
            for (int i = 0; i < dna.Genes.Length; i++)
            {
                if (random.NextDouble() <= mutationChance)
                {
                    dna.Genes[i] =(int) dna.Genes[i]^1;
                }
            }
        }
    }
}
