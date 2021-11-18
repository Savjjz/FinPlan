using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Expenditure
    {
        public string Name { get; private set; }
        public decimal TotalSum { get; private set; }
        public Expenditure(decimal totalSum, string name)
        {
            TotalSum = totalSum;
            Name = name;
        }
    }
}
