using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Crossovers;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Problems;
using System.Diagnostics;

namespace GATest
{
    class Program
    {
        public static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            Runner();
            sw.Stop();
            Console.WriteLine("Et: " + sw.Elapsed);
            Console.ReadKey();
        }

        static void Runner()
        {
            IMutate<double> mutation = new MutationRandomNumbers();
            ICrossover<double> crossover = new NumberCrossover();
            IProblem<double> problem = new ProblemNumberSequence();


            //set mutation chance
            float mutationChance = 0.001f;

            GAEngine<double> GAE = new GAEngine<double>(problem.Data.Length, mutation, mutationChance, problem, crossover, problem.Data, problem.Target);


            while (GAE.HighestFitnessInPopulation() != 1)
            {
                problem.CalculateFitness(GAE.GetPopulation(), problem.Target);
                GAE.Selection();
                GAE.Generate();
                problem.CalculateFitness(GAE.GetPopulation(), problem.Target);
                DisplayInfo<double>(GAE);
            }
        }



        static void DisplayInfo<T>(GAEngine<T> GAE)
        {
            //Display target
            if (GAE.GetGeneration() == 1)
                Console.WriteLine("Target: {0}" ,   GAE.Problem.DisplayTarget());

            //display best dna in population
            // Console.WriteLine("Best: {0}",       GAE.GetBest().ToString());

            //display highest fitness score
            Console.WriteLine("Best fitness: {0}",  GAE.HighestFitnessInPopulation());

            //display average fitness of the population
            Console.WriteLine("Avg fitness: {0}",   GAE.GetAverageFitness());

            // display generation
            Console.WriteLine("Generation: {0}",    GAE.GetGeneration());

            //display whole population
            //Console.WriteLine("{0}",              GAE.populationToString());

            Console.WriteLine();
        }
    }
}
