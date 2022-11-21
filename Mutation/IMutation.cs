using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.Mutation
{
    public interface IMutation
    {
        void  Mutate(List<Chromosome> population);
    }
}
