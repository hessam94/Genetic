using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.Selection
{
    public class TournamentSelection : ISelection
    {
        Random rand = new Random();
        public int K = 8;// k is number of individuals that every time is selected and
                         // then best of them is selected as the parent, for each parent same 

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
        List<Chromosome> tempList = new List<Chromosome>();
        public List<Chromosome> Select(List<Chromosome> population, int count)
        {
            int popLen = population.Count;
            List<Chromosome> tempPop;
            List<Chromosome> tempParent = new List<Chromosome>();
            for (int i = 0; i < count; i++)
            {
                tempPop = new List<Chromosome>(population);
                for (int j = 0; j < K; j++)
                {
                    var temp = rand.Next(popLen - j -1);
                    tempList.Add(tempPop[temp]);
                    tempPop.RemoveAt(temp);
                }
                tempParent.Add(SelectBest(tempList));
            }
            return tempParent;
        }

        public Chromosome SelectBest(List<Chromosome> list)
        {
            return list.OrderBy(x => x.Fitness).FirstOrDefault();
        }
    }
}
