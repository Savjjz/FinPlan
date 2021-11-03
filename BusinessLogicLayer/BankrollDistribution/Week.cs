using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.BankrollDistribution
{
    public class Week
    {
        public DateTime WeekStart { get; private set; }
        public DateTime WeekEnd { get; private set; }
        public int WeekNumber { get; private set; }

        public Week(DateTime weekStart, DateTime weekEnd)
        {
            WeekStart = weekStart;
            WeekEnd = weekEnd;
        }
        public Week(DateTime weekStart, DateTime weekEnd, int weekNumber)
        {
            WeekStart = weekStart;
            WeekEnd = weekEnd;
            WeekNumber = weekNumber;
        }
    }
}
