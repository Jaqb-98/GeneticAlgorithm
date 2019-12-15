using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Crossovers
{
    public class BasicCrossover : ICrossover
    {
        public DNA Crossover(DNA partner1, DNA partner2, Random random)
        {
            DNA child = new DNA(partner1.Genes.Length);

            int midpoint = random.Next(0, partner1.Genes.Length);
            for (int i = 0; i < partner1.Genes.Length; i++)
            {
                if (i < midpoint) child.Genes[i] = partner1.Genes[i];
                else child.Genes[i] = partner2.Genes[i];

            }
            return child;
        }
    }
}
