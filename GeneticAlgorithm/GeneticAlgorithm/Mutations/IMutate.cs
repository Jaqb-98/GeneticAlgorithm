using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Mutations
{
    public interface IMutate
    {
        void Mutate(DNA dna, float mutationChance);
    }
}
