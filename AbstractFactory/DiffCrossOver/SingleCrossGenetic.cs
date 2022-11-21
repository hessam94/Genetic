using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GeneticTest.CrossOver;

namespace GeneticTest.AbstractFactory.DiffCrossOver
{
    public class SingleCrossGenetic : IAbstarctGenetic
    {
        public SingleCrossGenetic()
        {
        }

        public override void CrossOver()
        {
            SinglePointCrossOver crossOver = new SinglePointCrossOver();
            crossOver.CrossPoint = r.Next(37);
            crossOver.ChromoId =  this.ChromoId;
            childList = new List<Chromosome>();
            for (int i = 0; i < parentList.Count -1; i += 2)
            {
                childList.AddRange(crossOver.Cross(parentList[i], parentList[i + 1]));
            }
            this.ChromoId = crossOver.ChromoId;
   
        }

        public override void Mutation()
        {
            //GeneticTest.Mutation.MutationA mutation = new GeneticTest.Mutation.MutationA();
            //mutation.Mutate(childList);
            GeneticTest.Mutation.MutationA.Mutate(childList);
        }

        public override void Selection()
        {
            RankSelection selection = new RankSelection();
            parentList = new List<Chromosome>();
            parentList = selection.Select(chromoList, parentCount);
        }
    }
}
