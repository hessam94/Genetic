using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.Mutation
{
    //public class MutationA : IMutation
    public class MutationA
    {
        public static Random r = new Random();
        public static void Mutate(List<Chromosome> newChildren)
        {
            double mutationRate = 0.4;

            if (newChildren.Count > 0)
            {
                int num = newChildren[0].Genes.Count;

                foreach (var child in newChildren)
                {
                    if (r.Next(num) < mutationRate)
                    {
                        var point1 = r.Next(num);
                        var point2 = r.Next(num);
                        var temp = child.Genes[point1];
                        child.Genes[point1] = child.Genes[point2];
                        child.Genes[point2] = temp;
                    }
                }
            }
        }
    }
}
