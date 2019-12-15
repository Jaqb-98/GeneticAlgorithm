using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Crossovers;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Problems;

namespace GATest
{
    class Program
    {
        public static void Main()
        {
            Runner();
        }

        static void Runner()
        {
            IMutate<double> mutation = new MutateBinary();
            ICrossover<double> crossover = new NumberCrossover();
            IProblem<double> problem = new ProblemNumberSequence();
            float mutationChance = 0.01f;

            GAEngine<double> GAE = new GAEngine<double>(problem.Data.Length, mutation, mutationChance, problem, crossover, problem.Data, problem.Target);

            while(GAE.HighestFitnessInPopulation() != 1)
            {
                problem.CalculateFitness(GAE.GetPopulation(),problem.Target);
                GAE.Selection();
                GAE.Generate();
                problem.CalculateFitness(GAE.GetPopulation(), problem.Target);
                DisplayInfo<double>(GAE);
            }

            Console.ReadKey();
        }

        static void DisplayInfo<T>(GAEngine<T> GAE)
        {
            Console.WriteLine("Best: {0}",          GAE.GetBest().ToString());
            Console.WriteLine("Best fitness: {0}",  GAE.HighestFitnessInPopulation());
            Console.WriteLine("Avg fitness: {0}",   GAE.GetAverageFitness());
            Console.WriteLine("Generations: {0}",   GAE.GetGeneration());
            Console.WriteLine("{0}",                GAE.populationToString());
        }
    }
}
