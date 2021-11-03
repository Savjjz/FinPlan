using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.ExcelBlock.ServiceFunctions
{
    public static class StringExtensionsForExcel
    {
        public static string NextColumn(this string cellNumber)
        {
            string currentColumn = cellNumber.GetColumnNumber();
            char[] charArray = currentColumn.ToCharArray();
            bool isNextRank = false;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                if ((charArray[i] == 'Z') && (i != 0))
                {
                    charArray[i] = 'A';
                }
                else if ((charArray[i] == 'Z') && (i == 0))
                {
                    charArray[i] = 'A';
                    isNextRank = true;
                }
                else
                {
                    int num = (int)charArray[i] + 1;
                    charArray[i] = Convert.ToChar(num);
                    break;
                }
            }
            string nextCell = "";
            if (isNextRank)
            {
                nextCell = new string(charArray);
                nextCell += "A";
                nextCell += cellNumber.GetLineNumber();
            }
            else
            {
                nextCell = new string(charArray);
                nextCell += cellNumber.GetLineNumber();
            }
            return nextCell;
        }

        public static string PreviousColumn(this string cellNumber)
        {
            string currentColumn = cellNumber.GetColumnNumber();
            char[] charArray = currentColumn.ToCharArray();
            bool isPreviousRank = false;
            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                if ((charArray[i] == 'A') && (i != 0))
                {
                    charArray[i] = 'Z';
                }
                else if ((charArray[i] == 'A') && (i == 0))
                {
                    charArray[i] = 'Z';
                    isPreviousRank = true;
                }
                else
                {
                    int num = (int)charArray[i] - 1;
                    charArray[i] = Convert.ToChar(num);
                    break;
                }
            }
            string previousCell = new string(charArray);
            previousCell += cellNumber.GetLineNumber();
            if (isPreviousRank)
                previousCell = previousCell.Substring(1);
            return previousCell;
        }

        public static string NextLine(this string cellNumber)
        {
            int currentLine = Convert.ToInt32(cellNumber.GetLineNumber());
            currentLine++;
            string nextCell = cellNumber.GetColumnNumber() + Convert.ToString(currentLine);
            return nextCell;
        }

        public static string PreviousLine(this string cellNumber)
        {
            int currentLine = Convert.ToInt32(cellNumber.GetLineNumber());
            currentLine--;
            string previousCell = cellNumber.GetColumnNumber() + Convert.ToString(currentLine);
            return previousCell;
        }

        internal static string GetLineNumber(this string cellNumber)
        {
            //Получить из строки только числа
            return string.Join("", cellNumber.Where(c => char.IsDigit(c)));
        }

        internal static string GetColumnNumber(this string cellNumber)
        {
            //Получить из строки только буквы
            return string.Join("", cellNumber.Where(c => !char.IsDigit(c)));
        }

        /// <summary>
        /// Получить число возможных слов в алфавите начиная с символа "A"  и заканчивая символом 
        /// </summary>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        internal static int GetAlphabetSize(this string cellNumber)
        {
            char[] charArray = cellNumber.GetColumnNumber().ToCharArray();
            int alphabetSize = 1;
            const int sizeOfRank = 26;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < charArray.Length; j++)
                    {
                        alphabetSize *= (Convert.ToInt32(charArray[j]) - Convert.ToInt32('A') + 1);
                    }
                }
                else
                {
                    alphabetSize += Convert.ToInt32(Math.Pow(sizeOfRank, i));
                }
            }
            return alphabetSize;
        }

    }
}
