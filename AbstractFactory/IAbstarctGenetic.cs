using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest.AbstractFactory
{
    public abstract class IAbstarctGenetic
    {
        public TSPFitness fitness;
        public List<Chromosome> chromoList, parentList, childList;
        public Population population;
        public static City[] cityMap;
        public Random r;
        public double min, firstMin;
        public abstract void Selection();
        public int popCount = 48;
        public int parentCount = 10;
        public int ChromoId = 0;
        public int genesCount;
        public void FitnessEvaluation()
        {
            fitness = new TSPFitness();
            fitness.EvaluateFitness(chromoList);
            this.min = chromoList.Min(x => x.Fitness);

            //File.AppendAllText(@"C:\Users\hessam\Desktop\genetic\min.txt", min.ToString() + Environment.NewLine);
        }
        public abstract void CrossOver();
        public abstract void Mutation();
        public void BornDiePopulation()
        {
            var list = this.chromoList.OrderByDescending(x => x.Fitness).Take(childList.Count).ToList();
            this.chromoList.RemoveAll(x => list.Contains(x));
            this.chromoList.AddRange(childList);
        }

        public void Start()
        {
            population = new Population();
            chromoList = new List<Chromosome>(population.popInit(popCount, genesCount, ref ChromoId));
            //chromoList = population.popInit(popCount, genesCount, ref ChromoId);
            r = new Random();
            Run();
            //File.AppendAllText(@"C:\Users\hessam\Desktop\genetic\AllRun.doc", this.GetType().Name + "   " + min.ToString() + Environment.NewLine);
        }

        public void Start(List<Chromosome> midPop)
        {
            chromoList = new List<Chromosome>(midPop);
            //chromoList = midPop;
            r = new Random();
            Run();
            
        }

        public void Run()
        {
            FitnessEvaluation(); //impelemented in asbtract
            Selection();
            CrossOver();
            Mutation();
            BornDiePopulation(); //impelemented in asbtract
            firstMin = min;
            for (int i = 0; i < 20000; i++)
            {
                FitnessEvaluation();
                Selection();
                CrossOver();
                Mutation();
                BornDiePopulation();
            }
            FitnessEvaluation();
            //printPath();


        }

        public void printPath()
        {
            if (File.Exists(@"C:\Users\hessam\Desktop\genetic\Path.txt"))
                File.Delete(@"C:\Users\hessam\Desktop\genetic\Path.txt");
            foreach (var item in chromoList)
            {
                File.AppendAllText(@"C:\Users\hessam\Desktop\genetic\Path.txt", item.Id + Environment.NewLine);
            }


        }
 

    }
}
