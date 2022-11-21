using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.AbstractFactory.DiffCrossOver
{
    public class OrderCrossOver : ICrossOver
    {
        Chromosome parent1, parent2, child1, child2;
        public int CrossPoint1, CrossPoint2, ChromoId;
        public OrderCrossOver()
        {    }
        public List<Chromosome> Cross(Chromosome parent1, 
                                                     Chromosome parent2)
        {
            child1 = new Chromosome();
            child2 = new Chromosome();
            int GeneCount = parent1.Genes.Count;
            child1.Genes = new List<int>(new int[GeneCount]);
            child2.Genes = new List<int>(new int[GeneCount]);
            List<Chromosome> list = new List<Chromosome>();
            this.parent1 = parent1;
            this.parent2 = parent2;
            int pointer1, pointer2; // the location in child which we insert the item from parent
            // start from 1 so it must have count +1 items inside
            bool[] Visited1 = new bool[GeneCount + 1], Visited2 = new bool[GeneCount + 1];

            if (CrossPoint1 > CrossPoint2)
            {
                var temp = CrossPoint1;
                CrossPoint1 = CrossPoint2;
                CrossPoint2 = temp;
            }
            for (int i = CrossPoint1; i <= CrossPoint2; i++)
            {
                child1.Genes[i] = parent1.Genes[i];
                Visited1[parent1.Genes[i]] = true;
                child2.Genes[i] = parent2.Genes[i];
                Visited2[parent2.Genes[i]] = true;
            }
            pointer1 = CrossPoint2 + 1;
            pointer2 = CrossPoint2 + 1;

            for (int i = CrossPoint2 + 1; i < GeneCount; i++)
            {
                if (Visited1[parent2.Genes[i]] == false)
                {
                    child1.Genes[pointer1 % GeneCount ] = parent2.Genes[i];
                    Visited1[parent2.Genes[i]] = true;
                    pointer1++;
                }
                if (Visited2[parent1.Genes[i]] == false)
                {
                    child2.Genes[pointer2 % GeneCount] = parent1.Genes[i];
                    Visited2[parent1.Genes[i]] = true;
                    pointer2++;
                }
            }

            for (int i = 0; i <= CrossPoint2; i++)
            {
                if (Visited1[parent2.Genes[i]] == false)
                {
                    child1.Genes[pointer1 % GeneCount] = parent2.Genes[i];
                    Visited1[parent2.Genes[i]] = true;
                    pointer1++;
                }
                if (Visited2[parent1.Genes[i]] == false)
                {
                    child2.Genes[pointer2 % GeneCount] = parent1.Genes[i];
                    Visited2[parent1.Genes[i]] = true;
                    pointer2++;
                }
            }
            child1.Id = ++ChromoId;
            child2.Id = ++ChromoId;
            list.Add(child1);
            list.Add(child2);

            return list;
        }
    }
}
