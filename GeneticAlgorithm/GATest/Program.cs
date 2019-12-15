using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    class Program
    {
        static void Main(string[] args)
        {
                                                            // path to data file
            double[][] Data = DataToArray(@"E:\Visual Studio workspace\CHC\GeneticAlgorithm\GATest\data3.txt");

            string targetString = "1 1 1 1 1 0 0 1 0 0 0 0 1 1 0 0 1 0 0 1";



            string[] s1 = targetString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            double[] target = new double[s1.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                if (double.TryParse(s1[i], out target[i])) { }
            }
            

            Population population = new Population(Data.Length, 0.01f, Data, target);

            while ((population.highestFitnessInPopulation()) != 1)
            {
                population.CalculateFitness();
                population.Selection();
                population.Generate();
                population.CalculateFitness();
                DisplayInfo(population);
            }
            Console.ReadKey();

        }

        public static void DisplayInfo(Population population)
        {
            Console.WriteLine("Best: {0}", population.GetBest());
            Console.WriteLine("Best fitness: {0}", population.highestFitnessInPopulation());
            Console.WriteLine("Avg fitness: {0}", population.GetAverageFitness());
            Console.WriteLine("Generations: {0}", population.GetGeneration());
            Console.WriteLine("{0}", population.populationToString());
        }

        public static double[][] DataToArray(string path)
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
    }
}
