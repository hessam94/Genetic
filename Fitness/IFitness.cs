using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    interface IFitness
    {
        void EvaluateFitness(List<Chromosome> population);
    }
}
