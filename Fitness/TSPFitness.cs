using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticTest.AbstractFactory;
using GeneticTest.AbstractFactory.DiffCrossOver;

namespace GeneticTest
{
    public class TSPFitness : IFitness
    {
        public void EvaluateFitness(List<Chromosome> population)
        {
            // city map is already reed from the file
            foreach (var item in population)
            {
                if (item.IsEvaluated == false)
                {
                    for (int i = 0; i < item.Genes.Count -1; i++)
                    {
                        item.Fitness += CalculatePath(
                                                SingleCrossGenetic.cityMap[item.Genes[i + 1]].x, SingleCrossGenetic.cityMap[item.Genes[i]].x,
                                                SingleCrossGenetic.cityMap[item.Genes[i + 1]].y, SingleCrossGenetic.cityMap[item.Genes[i]].y
                                                );
                    }
                    item.IsEvaluated = true;
                }

            }


        }
        public double CalculatePath(double x2, double x1, double y2, double y1)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

    }
}
