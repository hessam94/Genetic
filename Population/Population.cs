using GeneticTest.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    public class Population
    {
        public List<Chromosome> chromoList;
        public List<Chromosome> popInit(int popCount, int genesCount , ref  int chId)
        {
            chromoList = new List<Chromosome>();
            Random r = new Random();
            
            for (int i = 1; i <= popCount; i++)
            {
                Chromosome tempChromo = new Chromosome();
                tempChromo.Genes = new List<int>();
                List<int> genes = new List<int>(genesCount);
                for (int k = 1; k <= genesCount; k++)
                    genes.Add(k);
                for (int j = 0; j < genesCount; j++)
                {
                    int temp = r.Next(1, genesCount - j);
                    tempChromo.Genes.Add(genes[temp - 1]);
                    genes.RemoveAt(temp - 1);
                }
                tempChromo.Id = ++chId;
                chromoList.Add(tempChromo);
            }
            
            return chromoList;
        }

    }
}
