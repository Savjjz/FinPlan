using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ExcelBlock.ServiceFunctions
{
    class WeekMatchColumn
    {
        public List<string> WeekId { get; private set; } = new List<string>();
        public List<string> ColumnNumbers { get; private set; } = new List<string>();
        public void Add(string weekId, string columnNumber)
        {
            WeekId.Add(weekId);
            ColumnNumbers.Add(columnNumber);
        }
    }
}
