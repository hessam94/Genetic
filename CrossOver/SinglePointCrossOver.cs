using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.CrossOver
{
    public class SinglePointCrossOver : ICrossOver
    {
        Chromosome parent1, parent2;
        Chromosome child1, child2;
        public int CrossPoint;
        public int ChromoId;
        public SinglePointCrossOver()
        {

        }
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            List<Chromosome> list = new List<Chromosome>();
            child1 = new Chromosome();
            child2 = new Chromosome();
            this.parent1 = parent1;
            this.parent2 = parent2;
            child1.Genes = parent1.Genes.Take(CrossPoint).ToList().Concat(parent2.Genes.Skip(CrossPoint).Take(parent2.Genes.Count - CrossPoint).ToList()).ToList();
            child1.Id = ++ChromoId;
            child2.Genes = parent2.Genes.Take(CrossPoint).ToList().Concat(parent1.Genes.Skip(CrossPoint).Take(parent1.Genes.Count - CrossPoint).ToList()).ToList();
            child2.Id = ++ChromoId;
            list.Add(child1);
            list.Add(child2);




            var cc = child1.Genes.GroupBy(xx => xx);
            foreach (var item2 in cc)
            {
                var tt = item2.ToList();
                if (tt.Count > 1)
                {
                    bool flag = true;
                }

            }

            return list;
        }
    }
}
