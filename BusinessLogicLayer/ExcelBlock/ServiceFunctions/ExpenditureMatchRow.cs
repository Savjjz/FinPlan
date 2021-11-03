using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ExcelBlock.ServiceFunctions
{
    class ExpenditureMatchRow
    {
        public List<string> ExpenditureId { get; private set; } = new List<string>();
        public List<string> RowNumbers { get; private set; } = new List<string>();
        public void Add(string expenditureId, string rowNumber)
        {
            ExpenditureId.Add(expenditureId);
            RowNumbers.Add(rowNumber);
        }
    }
}
