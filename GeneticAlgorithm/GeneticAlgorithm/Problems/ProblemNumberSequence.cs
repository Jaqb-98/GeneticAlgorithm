using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Problems
{
    public class ProblemNumberSequence : IProblem<double>
    {
        public double[][] Data { get; set; }

        public int DNALength { get; set; }

        public double[] Target { get; set; }

        public ProblemNumberSequence()
        {
            Data = DataToArray(@"E:\Visual Studio workspace\CHC\GeneticAlgorithm\GATest\data3.txt");
            DNALength = Data[0].Length;
            Target = TargetToArray("1 1 0 1 1 1 0 1 1 1 1 0 0 0 0 1 0 0 0 0");
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
    }
}
