using GeneticTest.AbstractFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.CrossOver
{
    public class MultiPointCrossOver : ICrossOver
    {
        Chromosome parent1, parent2;
        Chromosome child1, child2;
        public int CrossPoint1, CrossPoint2;
        public int ChromoId;
        public MultiPointCrossOver()
        {

        }
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {

            // 1 2 3 'cp1' 4 5 'cp2' 6 7 8
            child1 = new Chromosome();
            child2 = new Chromosome();
            List<Chromosome> list = new List<Chromosome>();
            this.parent1 = parent1;
            this.parent2 = parent2;
            child1.Genes = parent1.Genes.Take(CrossPoint1).ToList().Concat(parent2.Genes.Skip(CrossPoint1).Take(CrossPoint2 - CrossPoint1 - 1).ToList().Concat(parent1.Genes.Skip(CrossPoint2 - 1))).ToList();
            child1.Id = ++ChromoId;
            child2.Genes = parent2.Genes.Take(CrossPoint1).ToList().Concat(parent1.Genes.Skip(CrossPoint1).Take(CrossPoint2 - CrossPoint1 - 1).ToList().Concat(parent2.Genes.Skip(CrossPoint2 - 1))).ToList();
            child2.Id = ++ChromoId;
            list.Add(child1);
            list.Add(child2);
            return list;
        }
    }
}
