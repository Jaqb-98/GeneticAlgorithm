using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Crossovers
{
    public class NumberCrossover: ICrossover<double>
    {
        public DNA<double> Crossover(DNA<double> partner1, DNA<double> partner2, DNA<double> partner3, DNA<double> partner4, Random random)
        {
          
            int DNALength = partner1.Genes.Length;
            DNA<double> child = new DNA<double>(DNALength);

            int crossPoint1 = random.Next(0, DNALength);
            int crossPoint2 = random.Next(crossPoint1, DNALength);
            int crossPoint3 = random.Next(crossPoint2, DNALength);


            for (int i = 0; i < partner1.Genes.Length; i++)
            {
                if (i < crossPoint1) child.Genes[i] = partner1.Genes[i];
                if (crossPoint1 <= i && i < crossPoint2) child.Genes[i] = partner2.Genes[i];
                if (crossPoint2 <= i && i < crossPoint3) child.Genes[i] = partner3.Genes[i];
                else child.Genes[i] = partner4.Genes[i];

            }
            return child;
        }
    }
}
