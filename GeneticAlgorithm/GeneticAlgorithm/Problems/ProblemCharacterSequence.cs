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
            Target = SetTarget(1000);
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

        static char[] SetTarget(int targetLength)
        {
            char[] target = new char[targetLength];

            for (int i = 0; i < targetLength; i++)
            {
                target[i]= (char)random.Next(32, 126);
            }

            return target;
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

        public void CalculateFitness(List<DNA<char>> population, char[] target)
        {
            for (int i = 0; i < population.Count; i++)
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

        public string DisplayTarget()
        {
            string s = string.Empty;
            for (int i = 0; i < Target.Length; i++)
            {
                s += $"{Target[i]}";
            }
            return s;
        }
    }
}
