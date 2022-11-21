using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.AbstractFactory.DiffCrossOver
{
    public class PartialCrossOver : ICrossOver
    {
        Chromosome parent1, parent2;
        Chromosome child1, child2;
        public int CrossPoint1, CrossPoint2;
        public int ChromoId;

        public PartialCrossOver()
        {

        }
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            child1 = new Chromosome();
            child2 = new Chromosome();
            int GeneCount = parent1.Genes.Count;
            child1.Genes = new List<int>(new int[GeneCount]);
            child2.Genes = new List<int>(new int[GeneCount]);
            List<Chromosome> list = new List<Chromosome>();
            this.parent1 = parent1;
            this.parent2 = parent2;

            bool[] Visited1 = new bool[GeneCount + 1], Visited2 = new bool[GeneCount + 1];
            for (int i = CrossPoint1; i <= CrossPoint2; i++)
            {
                child1.Genes[i] = parent1.Genes[i];
                Visited1[parent1.Genes[i]] = true;

                child2.Genes[i] = parent2.Genes[i];
                Visited2[parent2.Genes[i]] = true;
            }

            for (int i = CrossPoint1; i <= CrossPoint2; i++)
            {
                if (Visited1[parent2.Genes[i]] == false)
                {
                    bool flag = false;
                    int index = i;
                    while (!flag)
                    {
                       var temp = parent2.Genes.FindIndex(x=> x == parent1.Genes[index]);
                        if (child1.Genes[temp] == 0)
                        {
                            child1.Genes[temp] = parent2.Genes[i];
                            Visited1[parent2.Genes[i]] = true;
                            flag = true;
                        }
                        else
                        {
                            index = temp;
                        }

                    }

                }

                if (Visited2[parent1.Genes[i]] == false)
                {
                    bool flag = false;
                    int index = i;
                    while (!flag)
                    {
                        var temp = parent1.Genes.FindIndex(x => x == parent2.Genes[index]);
                        if (child2.Genes[temp] == 0)
                        {
                            child2.Genes[temp] = parent1.Genes[i];
                            Visited2[parent1.Genes[i]] = true;
                            flag = true;
                        }
                        else
                        {
                            index = temp;
                        }

                    }

                }
            }


            for (int i = 0; i < GeneCount; i++)
            {
                if (Visited1[parent2.Genes[i]] == false)
                {
                    child1.Genes[i] = parent2.Genes[i];
                }
                if (Visited2[parent1.Genes[i]] == false)
                {
                    child2.Genes[i] = parent1.Genes[i];
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
