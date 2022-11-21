using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    public class Chromosome
    {
        public Chromosome()
        { }
        public int Id;
        public List<int> Genes;
        public double Fitness;
        public bool IsEvaluated;
        public double BeginFit, EndFit;
        public double NormalFitness;

    }
}
