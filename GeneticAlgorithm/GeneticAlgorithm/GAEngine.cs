using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticAlgorithm.Problems;
using GeneticAlgorithm.Mutations;
using GeneticAlgorithm.Crossovers;

namespace GeneticAlgorithm
{
    public class GAEngine
    {
        /// <summary>
        /// Array of DNA objects
        /// </summary>
        private DNA[] Population;

        private List<DNA> MatingPool;
        private int Generation;


        private IProblem Problem;
        private IMutate Mutation;
        private ICrossover Crossover;

        /// <summary>
        /// Something that we want evolve into
        /// </summary>
        private double[] target;

        /// <summary>
        /// Chance of each gene being mutated
        /// </summary>
        private float mutationChance;
        private static Random random = new Random();

        public int GetGeneration()
        {
            return Generation;
        }

        public DNA[] GetPopulation()
        {
            return Population;
        }


        public GAEngine(int populationSize, IMutate mutation, float mutationChance, IProblem problem, ICrossover crossover, double[][] Data, double[] target)
        {
            Population = new DNA[populationSize];
            this.mutationChance = mutationChance;
            MatingPool = new List<DNA>();
            Generation = 0;
            this.target = target;
            this.Mutation = mutation;
            this.Problem = problem;
            this.Crossover = crossover;

            for (int i = 0; i < Data.Length; i++)
            {
                Population[i] = new DNA(Data[i],problem);
            }
        }

        /// <summary>
        /// Adds DNA objects to mating pool based of its fitness score
        /// </summary>
        public void Selection()
        {
            MatingPool.Clear();

            foreach (var item in Population)
            {
                float n = (item.GetFitness()) * 100;
                for (int j = 0; j < (int)n; j++)
                {
                    MatingPool.Add(item);
                }
            }
        }

        /// <summary>
        /// Generating new population
        /// </summary>
        public void Generate()
        {
            for (int i = 0; i < Population.Length; i++)
            {
                int a = random.Next(0, MatingPool.Count);
                int b = random.Next(0, MatingPool.Count);
                DNA parent1 = MatingPool[a];
                DNA parent2 = MatingPool[b];
                DNA child = Crossover.Crossover(parent1,parent2,random);
                Mutation.Mutate(child,mutationChance);
                this.Population[i] = child;
            }
            Generation++;
        }


       


        /// <summary>
        /// Calculates fitness score for everything in population.
        /// </summary>
        public void CalculateFitness()
        {
            Problem.CalculateFitness(Population, Problem.Target);
        }


        /// <summary>
        /// Returns highest fitness score in the entire population.
        /// </summary>
        /// <returns></returns>
        public float HighestFitnessInPopulation()
        {
            var a = Population.Select(x => x.GetFitness()).Max();
            return a;
        }


        /// <summary>
        /// Returns string with every member of the population
        /// </summary>
        /// <returns></returns>
        public string populationToString()
        {
            var a = Population.Select(x => x.Genes);

            string populationString = "";

            foreach (var item in a)
            {
                populationString += string.Join("", item) + "\n";
            }

            return populationString;
        }

        /// <summary>
        /// Returns member of the population with the hishest fitness score
        /// </summary>
        /// <returns></returns>
        public string GetBest()
        {
            var b = Population
                             .Where(x => x.GetFitness() == Population.Max(y => y.GetFitness()))
                             .Select(x => x.Genes);
            var c = b.First();

            string best = string.Join("", c);

            return best;

        }


        /// <summary>
        /// Returns average fitness for the whole population
        /// </summary>
        /// <returns></returns>
        public float GetAverageFitness()
        {
            var a = Population.Select(x => x.GetFitness()).Average();
            return a;

        }


    }
}
