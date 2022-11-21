using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    public class Genetic
    {
        public List<Chromosome> Population;
        public ISelection selectionMethod;
        public ICrossOver CrossOverMethod;
        public Genetic(List<Chromosome> population,ISelection selection)
        {
            Population = population;
            selectionMethod = selection;
            
        }

        

    }
}
