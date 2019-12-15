using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Mutations
{
    public interface IMutate<T>
    {

        /// <summary>
        /// This method have a chance to mutate single gene in the population besed on the mutation chance parameter
        /// </summary>
        /// <param name="dna"></param>
        /// <param name="mutationChance"></param>
        void Mutate(DNA<T> dna, float mutationChance);
    }
}
