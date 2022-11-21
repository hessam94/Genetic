using GeneticTest.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.CrossOver
{
    public class UniformCrossOver : ICrossOver
    {
        public double probabilty;
        Chromosome child1, child2;
        Random r;
        public int ChromoId;
        public UniformCrossOver()
        {
            r = new Random();
        }
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            List<Chromosome> list = new List<Chromosome>();
            child1 = new Chromosome();
            child2 = new Chromosome();
            child1.Genes = new List<int>(parent1.Genes);
            child2.Genes = new List<int>(parent2.Genes);
            for (int i = 0; i < parent1.Genes.Count; i++)
            {
                if (r.NextDouble() < 0.5)
                {
                    var temp = child1.Genes[i];
                    child1.Genes[i] = child2.Genes[i];
                    child1.Id = ++ChromoId;
                    child2.Genes[i] = temp;
                    child2.Id = ++ChromoId;
                }
            }
            list.Add(child1);
            list.Add(child2);
            return list;
        }
    }
}
