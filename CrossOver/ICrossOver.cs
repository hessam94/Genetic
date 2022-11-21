using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    public interface ICrossOver
    {
        List<Chromosome> Cross(Chromosome parent1, Chromosome parent2);
    }
}
