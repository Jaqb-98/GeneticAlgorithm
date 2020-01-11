using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Problems
{
    public class ProblemNumberSequence : IProblem<double>
    {
        public double[][] Data { get; set; }

        public int DNALength { get; set; }

        public double[] Target { get; set; }

        private static Random random = new Random();

        /// <summary>
        /// Set target length and population size
        /// </summary>
        public ProblemNumberSequence()
        {
            Data = GenerateRandomPopulation(populationSize: 200, DnaLength: 1000, min: 0, max: 1);
            DNALength = Data[0].Length;
            Target = SetTarget(targetLength: 1000, min: 0, max: 1);
        }

        static double[] SetTarget(int targetLength, int min, int max)
        {
            double[] target = new double[targetLength];

            for (int i = 0; i < targetLength; i++)
            {
                target[i] = (double)random.Next(min, max + 1);
            }

            return target;
        }



        public void CalculateFitness(DNA<double>[] population, double[] target)
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

        public void CalculateFitness(List<DNA<double>> population, double[] target)
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




        public double[][] DataToArray(string path)
        {
            string data = System.IO.File.ReadAllText(path);

            string[] data2 = data.Split(new string[] { "\n" }, StringSplitOptions.None);

            double[][] finalData = new double[data2.Length][];

            for (int i = 0; i < data2.Length; i++)
            {
                string[] data3 = data2[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                finalData[i] = new double[data3.Length];

                for (int j = 0; j < data3.Length; j++)
                {
                    if (double.TryParse(data3[j], out finalData[i][j])) { }

                }
            }
            return finalData;
        }

        public double[] TargetToArray(string targetString)
        {

            string[] s1 = targetString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            double[] target = new double[s1.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                if (double.TryParse(s1[i], out target[i])) { }
            }

            return target;
        }

        public double[][] GenerateRandomPopulation(int populationSize, int DnaLength, int min, int max)
        {
            double[][] population = new double[populationSize][];
            for (int i = 0; i < populationSize; i++)
            {
                population[i] = new double[DnaLength];
                for (int j = 0; j < DnaLength; j++)
                {
                    population[i][j] = (double)random.Next(min, max + 1);
                }
            }
            return population;
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
