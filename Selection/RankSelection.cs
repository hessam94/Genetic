using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    public class RankSelection : ISelection
    {
        Random rand = new Random();
        public List<Chromosome> Select(List<Chromosome> population,int count)
        {
            return population.OrderBy(x => x.Fitness).GroupBy(x => x.Fitness).Select(y=> y.FirstOrDefault()).Take(count).ToList();
        }
        public List<Chromosome> Shuffle(List<Chromosome> list)
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
    }
}
