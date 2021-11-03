using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.ExcelBlock.ServiceFunctions
{
    class TransactionMatchRow
    {
        public List<string> TransactionId { get; private set; } = new List<string>();
        public List<string> RowNumbers { get; private set; } = new List<string>();
        public void Add(string transactionId, string rowNumber)
        {
            TransactionId.Add(transactionId);
            RowNumbers.Add(rowNumber);
        }
    }
}
