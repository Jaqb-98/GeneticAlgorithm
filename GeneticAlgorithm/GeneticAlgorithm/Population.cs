using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class Population
    {
        /// <summary>
        /// Array of DNA objects
        /// </summary>
        private DNA[] population;

        private List<DNA> matingPool;
        private int Generation;

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


        public Population(int populationSize, float mutationChance, double[][] Data, double[] target)
        {
            population = new DNA[populationSize];
            this.mutationChance = mutationChance;
            matingPool = new List<DNA>();
            Generation = 0;
            this.target = target;

            for (int i = 0; i < Data.Length; i++)
            {
                population[i] = new DNA(Data[i]);
            }
        }

        /// <summary>
        /// Adds DNA objects to mating pool based of its fitness score
        /// </summary>
        public void Selection()
        {
            matingPool.Clear();

            foreach (var item in population)
            {
                float n = (item.GetFitness()) * 100;
                for (int j = 0; j < (int)n; j++)
                {
                    matingPool.Add(item);
                }
            }
        }

        /// <summary>
        /// Generating new population
        /// </summary>
        public void Generate()
        {
            for (int i = 0; i < population.Length; i++)
            {
                int a = random.Next(0, matingPool.Count);
                int b = random.Next(0, matingPool.Count);
                DNA parent1 = matingPool[a];
                DNA parent2 = matingPool[b];
                DNA child = parent1.Crossover(parent2);
                child.Mutate(mutationChance);
                this.population[i] = child;
            }
            Generation++;
        }


        /// <summary>
        /// Calculates fitness score for everything in population.
        /// </summary>
        public void CalculateFitness()
        {
            foreach (var item in population)
            {
                item.CalculateFitness(target);
            }
        }


        /// <summary>
        /// Returns highest fitness score in the entire population.
        /// </summary>
        /// <returns></returns>
        public float highestFitnessInPopulation()
        {
            var a = population.Select(x => x.GetFitness()).Max();
            return a;
        }


        /// <summary>
        /// Returns string with every member of the population
        /// </summary>
        /// <returns></returns>
        public string populationToString()
        {
            var a = population.Select(x => x.Genes);

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
            var b = population
                             .Where(x => x.GetFitness() == population.Max(y => y.GetFitness()))
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
            var a = population.Select(x => x.GetFitness()).Average();
            return a;

        }


    }
}
