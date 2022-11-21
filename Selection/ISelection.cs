﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    public interface ISelection
    {
        List<Chromosome> Select(List<Chromosome> population, int count);
        
    }
}
