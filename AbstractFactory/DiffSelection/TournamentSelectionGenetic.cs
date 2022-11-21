using GeneticTest.CrossOver;
using GeneticTest.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.AbstractFactory.DiffSelection
{
    public class TournamentSelectionGenetic : IAbstarctGenetic
    {
        public override void CrossOver()
        {
            SinglePointCrossOver crossOver = new SinglePointCrossOver();
            crossOver.CrossPoint = r.Next(37);
            crossOver.ChromoId = this.ChromoId;
            childList = new List<Chromosome>();
            for (int i = 0; i < parentList.Count; i += 2)
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
            TournamentSelection selection = new TournamentSelection();
            selection.K = 4;
            parentList = selection.Select(chromoList, parentCount);
        }
    }
}
