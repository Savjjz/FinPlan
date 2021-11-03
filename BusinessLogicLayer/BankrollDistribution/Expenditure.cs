using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Expenditure
    {
        public string Name { get; private set; }
        public double TotalSum { get; private set; }
        public Expenditure(double totalSum, string name)
        {
            TotalSum = totalSum;
            Name = name;
        }
    }
}
