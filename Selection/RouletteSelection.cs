using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneticTest.Selection
{
    class RouletteSelection : ISelection
    {
        Random rand = new Random();
        public  List<Chromosome> Shuffle(List<Chromosome> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Chromosome value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
        public List<Chromosome> Select(List<Chromosome> population, int count)
        {
            List<Chromosome> list = new List<Chromosome>();
            double sum = population.Sum(x => x.Fitness);
            foreach (var item in population)
            {
                //item.NormalFitness = 1 - (item.Fitness / sum);
                item.NormalFitness = (sum / item.Fitness);
            }
            sum = population.Sum(x => x.NormalFitness);
            foreach (var item in population)
            {
                item.NormalFitness = (item.NormalFitness / sum);
            }
            population = population.OrderBy(x => x.NormalFitness).ToList();

            population[0].EndFit = population[0].NormalFitness;

            for (int i = 1; i < population.Count; i++)
            {
                population[i].EndFit = population[i].NormalFitness + population[i - 1].EndFit;
            }
            population[population.Count - 1].EndFit = 1;

            for (int i = 0; i < count; i++)
            {
                var templist = new List<Chromosome>(population);
                var temp = rand.NextDouble();
                for (int j = population.Count - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        if (temp >= population[0].EndFit)
                        {
                            list.Add(population[0]);
                        }
                    }
                    else if (temp <= population[j].EndFit && temp > population[j - 1].EndFit)
                    {
                        list.Add(population[j]);
                        break;
                    }
                }


            }

            return list;

        }
    }
}
