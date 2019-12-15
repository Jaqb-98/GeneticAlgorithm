using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Crossovers
{
    public interface ICrossover
    {
        DNA Crossover(DNA partner1, DNA partner2, Random random);
    }
}
