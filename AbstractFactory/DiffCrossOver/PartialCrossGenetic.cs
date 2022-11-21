using GeneticTest.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.AbstractFactory.DiffCrossOver
{
    public class PartialCrossGenetic : IAbstarctGenetic
    {
        public override void CrossOver()
        {
            PartialCrossOver crossOver = new PartialCrossOver();
            crossOver.CrossPoint1 = r.Next(1, 19);
            crossOver.CrossPoint2 = r.Next(20, 37);
            crossOver.ChromoId = this.ChromoId;
            childList = new List<Chromosome>();
            for (int i = 0; i < parentList.Count - 1; i += 2)
            {
                childList.AddRange(crossOver.Cross(parentList[i], parentList[i + 1]));
            }
            this.ChromoId = crossOver.ChromoId;
        }

        public override void Mutation()
        {
            GeneticTest.Mutation.MutationA.Mutate(childList);
        }

        public override void Selection()
        {
            RankSelection selection = new RankSelection();

            // RouletteSelection selection = new RouletteSelection();
            //TournamentSelection selection = new TournamentSelection();
            parentList = new List<Chromosome>();
            parentList = selection.Select(chromoList, parentCount);

        }
    }
}
