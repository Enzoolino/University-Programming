using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BitMatrix
{
    public partial class BitMatrix
    {
        public static BitMatrix Parse(string s)
        {

            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException();

            string[] rows = s.Split (new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int numRows = rows.Length;
            int numCols = rows[0].Length;


            for (int i = 1; i < numRows; i++)
            {
                if (rows[i].Length != numCols)
                {
                    throw new FormatException();
                }
            }

            BitMatrix result = new BitMatrix(numRows, numCols);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (rows[i][j] == '1')
                    {
                        result[i, j] = 1;
                    }
                    else if (rows[i][j] == '0')
                    {
                        result[i, j] = 0;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
            }
            return result;
        }

        public static bool TryParse(string s, out BitMatrix result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = null;
                return false;
            }

            string[] rows = s.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int numRows = rows.Length;
            int numCols = rows[0].Length;

            for (int i = 1; i < numRows; i++)
            {
                if (rows[i].Length != numCols)
                {
                    result = null;
                    return false;
                }
            }

            BitMatrix resultInside = new BitMatrix(numRows, numCols);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (rows[i][j] == '1')
                    {
                        resultInside[i, j] = 1;
                    }
                    else if (rows[i][j] == '0')
                    {
                        resultInside[i, j] = 0;
                    }
                    else
                    {
                        result = null;
                        return false;
                    }
                }
            }
            result = resultInside;
            return true;
        }
    }
}
