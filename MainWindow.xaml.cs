using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GeneticTest.AbstractFactory.DiffCrossOver;
using GeneticTest.AbstractFactory.DiffSelection;
using GeneticTest.AbstractFactory;

namespace GeneticTest
{

    public partial class MainWindow : Window
    {
        AbstractFactory.IAbstarctGenetic genetic;
        object A = new object();
        public int FinishedJob = 0;
        public List<Chromosome> MiddlePopulataion = new List<Chromosome>();
        public int genesCount = 38;
        public MainWindow()
        {
            InitializeComponent();
            genetic = new SingleCrossGenetic();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            if (dg.ShowDialog() == true)
            {
                ReadDataSet(dg.FileName);

            }
        }

        public void ReadDataSet(string s)
        {
            var file = File.ReadAllLines(s);
            int lineCount = 0;
            City[] cityMap = new City[0];
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains("DIMENSION"))
                {
                    var temp = file[i].Split(':')[1];
                    temp = temp.Trim();
                    lineCount = int.Parse(temp);
                }

                else if (file[i].Contains("NODE_COORD_SECTION"))
                {
                    cityMap = new City[lineCount + 1];

                    for (int j = i + 1, k = 1; k <= lineCount; j++, k++)
                    {
                        var city = file[j].Split(' ');
                        cityMap[k] = new City { Number = k, x = double.Parse(city[1]), y = double.Parse(city[2]) };
                    }
                    break;
                }
            }
            AbstractFactory.IAbstarctGenetic.cityMap = new City[] { };
            AbstractFactory.IAbstarctGenetic.cityMap = cityMap;

        }

        private void bt_start_Click(object sender, RoutedEventArgs e)
        {
            //Thread th1 = new Thread(() => ClientMethod(new OrderCrossGenetic()));
            //Thread th2 = new Thread(() => ClientMethod(new OrderCrossGenetic()));
            //Thread th3 = new Thread(() => ClientMethod(new OrderCrossGenetic()));
            //th1.Start();
            //th2.Start();
            //th3.Start();

            //ClientMethod(new SingleCrossGenetic());
            //ClientMethod(new MultiCrossGenetic());
            //ClientMethod(new UniformCrossGenetic());
            //ClientMethod(new RouletteSelectionGenetic());
            //ClientMethod(new TournamentSelectionGenetic());


            ClientMethod(new OrderCrossGenetic());
            //ClientMethod(new PartialCrossGenetic());

        }

        public void test()
        { }
        public void ClientMethod(AbstractFactory.IAbstarctGenetic geneticFactory)
        {
            geneticFactory.genesCount = 100000;
            //if (File.Exists(@"C:\Users\hessam\Desktop\genetic\min.txt"))
            //    File.Delete(@"C:\Users\hessam\Desktop\genetic\min.txt");
            geneticFactory.Start();

            lock (A)
            {
                MiddlePopulataion.AddRange(geneticFactory.chromoList.OrderBy(x => x.Fitness).Take(16));
                FinishedJob++;
                MessageBox.Show(geneticFactory.GetType().Name + "  " + geneticFactory.firstMin + "-------" + geneticFactory.min.ToString());
                //File.AppendAllText(@"C:\Users\hessam\Desktop\genetic\AllRun.txt", ((int)geneticFactory.min).ToString()+ Environment.NewLine);
            }
            if (FinishedJob == 3)
            {
                geneticFactory = new OrderCrossGenetic();
                geneticFactory.genesCount = 38;

                geneticFactory.Start(MiddlePopulataion);
                //MessageBox.Show(geneticFactory.GetType().Name + "  " + geneticFactory.firstMin + "-------" + geneticFactory.min.ToString());
                //File.AppendAllText(@"C:\Users\hessam\Desktop\genetic\AllRun.txt", geneticFactory.min.ToString() + Environment.NewLine);
            }
        }
    }
}
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
//public partial class MainWindow : Window
//{
//    public int x, y, z, w;
//    public int[][] Chromo;
//    public int[][] NEWchromo;
//    public int[] F_obj;
//    public double[] Fitness;
//    public double[] SelectionProbability;
//    public double TotalFitness;
//    public double[] CumulativeProbabality;
//    public double CrossoverRate;
//    public int a, b, c, d, e;
//    public int population;
//    public int GeneCount;
//    public double MutationRate;
//    public int Iteration;
//    Random r = new Random();
//    int maxRandom = 55;
//    int pfirst, psecond,plast,psecondlast;
//    string s = " ";
//    int min;
//    bool flag = false;
//    public MainWindow()
//    {
//        InitializeComponent();

//    }

//    public void Do()
//    {
//        GetInput();
//        Iteration = 1;



//        for (int i = 0; i < 500 && !flag; i++, Iteration++)
//        {
//            // try
//            {
//                FitnessProcess();
//            }
//            //catch (Exception e)
//            //{
//            //    var s = e.Message;
//            //}
//            if (!flag)
//            {
//                this.Dispatcher.Invoke((Action)(() =>
//            { list_show.Items.Add(min + "\n"); }));
//                //try
//                {
//                    SelectionProcess();
//                }
//                //catch (Exception ee)
//                //{

//                //}
//                try
//                {
//                    //CrossOverProcess();
//                    CrossOverProcess2();
//                }
//                catch (Exception e2)
//                {

//                }
//                MutationProcess();
//            }
//            else
//                break;
//        }
//        if (flag)
//            Dispatcher.Invoke((Action)(
//                () =>
//                {
//                    list_show.Items.Add(min + "\n"); 
//                    tx_show.Text += "found:   " + Iteration + "\n";
//                    //tx_show.Template += 

//                }));


//    }
//    private void Button_Click(object sender, RoutedEventArgs e)
//    {
//        Thread t = new Thread(() => Do());
//        t.Start();
//    }

//    public void GetInput()
//    {
//        Chromo = new int[10][];
//        population = 10;
//        GeneCount = 4;
//        for (int i = 0; i < population; i++)
//        {
//            Chromo[i] = new int[GeneCount];
//            for (int j = 0; j < GeneCount; j++)
//                Chromo[i][j] = r.Next(maxRandom);
//        }
//    }

//    public void FitnessProcess()
//    {
//        a = 1; b = 2; c = 3; d = 4; e = -20;
//        TotalFitness = 0;
//        F_obj = new int[population];
//        Fitness = new double[population];
//        SelectionProbability = new double[population];
//        min = 10000;
//        for (int i = 0; i < population; i++)
//        {

//            var value = a * Chromo[i][0] + b * Chromo[i][1] + c * Chromo[i][2] + d * Chromo[i][3] + e;
//            if (value < min)
//                min = value;
//            if (value == 0)
//            {
//                min = value;
//                MessageBox.Show(Chromo[i][0] + "  * 1  + " + Chromo[i][1] + " * 2  +  " + Chromo[i][2] + "  * 3  +  " + Chromo[i][3] + " * 4  +  -20 ,");
//                flag = true;
//                return;
//            }
//            else
//            {
//                F_obj[i] = value;
//                Fitness[i] = (double)1 / (1 + F_obj[i]);
//            }
//        }
//        for (int i = 0; i < population; i++)
//            TotalFitness += Fitness[i];

//        for (int i = 0; i < population; i++)
//            SelectionProbability[i] = Fitness[i] / TotalFitness;
//    }

//    public void SelectionProcess()
//    {
//        CumulativeProbabality = new double[population];
//        NEWchromo = new int[population][];
//        CumulativeProbabality[0] = SelectionProbability[0];
//        for (int i = 1; i < population; i++)
//            CumulativeProbabality[i] = CumulativeProbabality[i - 1] + SelectionProbability[i];


//        int l = SelectionProbability.Length;
//        double[] tempsort = new double[l];
//        Array.Copy(SelectionProbability, tempsort, SelectionProbability.Length);
//        Array.Sort(tempsort);
//        pfirst = Array.FindIndex(SelectionProbability, x => x == tempsort[l - 1]);
//        psecond = Array.FindIndex(SelectionProbability, x => x == tempsort[l - 2]);

//        plast = Array.FindIndex(SelectionProbability, x => x == tempsort[0]);
//        psecondlast = Array.FindIndex(SelectionProbability, x => x == tempsort[1]);
//        //for (int i = 0; i < population; i++)
//        //{
//        //    var temp = GetSelectedChromo(r);
//        //    if (temp != -1)
//        //        //s += temp + "  ";
//        //        NEWchromo[i] = Chromo[temp];

//        //}


//        //for (int i = 0; i < population; i++)
//        //    Chromo[i] = NEWchromo[i];

//        //MessageBox.Show(s);
//    }

//    public int GetSelectedChromo(Random r2)
//    {
//        //Random r2 = new Random();
//        double num = r2.NextDouble();
//        s += "  " + num + "...";
//        if (num <= CumulativeProbabality[0])
//            return 0;
//        else
//        {
//            for (int i = 0; i < population - 1; i++)
//            {
//                if (num > CumulativeProbabality[i] && num <= CumulativeProbabality[i + 1])
//                    return i + 1;
//            }
//        }
//        return population - 1;
//    }

//    List<int> parents;
//    int num;

//    public void CrossOverProcess2()
//    {
//        num = r.Next(GeneCount - 1);
//        CrossOver2(pfirst, psecond, num);

//    }
//    public void CrossOverProcess()
//    {
//        try
//        {
//            CrossoverRate = 0.25;
//            parents = new List<int>();

//            for (int i = 0; i < population; i++)
//                if (r.NextDouble() < CrossoverRate)
//                    parents.Add(i);

//            if (parents.Count % 2 == 1)
//                parents.RemoveAt(0);

//            if (parents.Count > 1)
//            {

//                //int i = 0;
//                for (int i = 0; i < parents.Count; i += 2)
//                {
//                    num = r.Next(GeneCount - 1);
//                    var p1 = parents[i];
//                    var p2 = parents[(i + 1) % parents.Count];
//                    CrossOver(p1, p2, num);
//                }
//                if (NEWchromo != null)
//                    Chromo = NEWchromo;
//            }
//        }
//        catch (Exception e)
//        {

//        }
//    }

//    public void CrossOver(int p1, int p2, int point)
//    {

//        for (int ii = point; ii < GeneCount; ii++)
//        {
//            var temp = NEWchromo[p1][ii];
//            NEWchromo[p1][ii] = NEWchromo[p2][ii];
//            NEWchromo[p2][ii] = temp;
//        }
//    }

//    public void CrossOver2(int p1, int p2, int point)
//    {

//        //List<int> child1, child2;
//        var child1 = Chromo[p1].Take(point ).ToList();
//        child1.AddRange (  Chromo[p2].Skip(point).ToList());
//        var child2 = Chromo[p2].Take(point ).ToList();
//        child2.AddRange(Chromo[p1].Skip(point ).ToList());
//        try
//        {
//            //for (int ii = point; ii < GeneCount; ii++)
//            //{
//            //    var temp = Chromo[p1][ii];
//            //    Chromo[p1][ii] = Chromo[p2][ii];
//            //    Chromo[p2][ii] = temp;
//            //}

//            Chromo[plast] = child1.ToArray();
//            Chromo[psecondlast] = child2.ToArray();

//        }
//        catch (Exception e)
//        {

//        }
//    }

//    public void MutationProcess()
//    {
//        MutationRate = 0.1;
//        var num = GeneCount * population;
//        int mutNum = Convert.ToInt32(Math.Round(num * MutationRate));

//        for (int count = 0; count < mutNum; count++)
//        {
//            var temp = r.Next(maxRandom);
//            var i = r.Next(population);
//            var j = r.Next(GeneCount);
//            Chromo[i][j] = temp;
//        }

//    }
//}





