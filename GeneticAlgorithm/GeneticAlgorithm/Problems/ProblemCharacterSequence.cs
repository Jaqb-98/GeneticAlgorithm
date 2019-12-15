using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Problems
{
    public class ProblemCharacterSequence : IProblem<char>
    {
        public char[][] Data { get; set; }
        public int DNALength { get; set; }

        public char[] Target { get; set; }

        private static Random random = new Random();
        public ProblemCharacterSequence()
        {
            Target = TargetToString("Random sentence");
            Data = RandomStringsGenerator(300,Target.Length);
            DNALength = Data[1].Length;
            
        }

        static char[] TargetToString(string v)
        {
            char[] s = new char[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                s[i] = v[i];
            }
            return s;
        }

        public void CalculateFitness(DNA<char>[] population, char[] target)
        {
           for (int i = 0; i < population.Length; i++)
            {
                int score = 0;
                for (int j = 0; j < DNALength; j++)
                {
                    if (population[i].Genes[j] == target[j])
                    {
                        score++;
                    }
                }
                float fitness = (float)score / DNALength;

                population[i].SetFitness(fitness);
            }

          
        }


        public char[][] RandomStringsGenerator(int numberOfStrings, int numberOfChars)
        {
            char[][] allStrings = new char[numberOfStrings][];
            for (int i = 0; i < numberOfStrings; i++)
            {
                allStrings[i] = new char[numberOfChars];
                for (int j = 0; j < numberOfChars; j++)
                {
                    allStrings[i][j] = (char)random.Next(32, 126);
                }
            }
            return allStrings;
        }
    }
}
