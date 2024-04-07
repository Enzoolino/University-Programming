
using System.Collections;

namespace Lib_BitMatrix
{
    class Program
    {
        public static void Main(string[] args)
        {

            // operator ^
            // poprawne dane
            var m1 = new BitMatrix(2, 3, 1, 0, 1, 0, 1, 0);
            var m2 = new BitMatrix(2, 3, 0, 1, 0, 0, 1, 0);
            //czy ^ jest symetryczny
            if ((m1 ^ m2).Equals(m2 ^ m1))
                Console.WriteLine("Correct data, symmetry: Pass");

            //czy wykonany poprawnie ^
            var expected = new BitMatrix(2, 3, 1, 1, 1, 0, 0, 0);
            var m3 = m1 ^ m2;
            if (expected.Equals(m3))
                Console.WriteLine("Correct data: Pass");

            //czy wynik jest niezależną kopią
            if (!ReferenceEquals(m1, m3) && !ReferenceEquals(m2, m3))
                Console.WriteLine("Correct data, ReferenceEquals: Pass");
            m1[1, 2] = 1; Console.WriteLine(m1[1, 2] != m3[1, 2]);

            // argument `null ^ null`
            try
            {
                var m = (BitMatrix)null ^ (BitMatrix)null;
                Console.WriteLine(m);
                Console.WriteLine("Arguments null: Fail");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Arguments null: Pass");
            }

            // right argument `null`
            try
            {
                var m = (BitMatrix)null ^ new BitMatrix(2, 2);
                Console.WriteLine(m);
                Console.WriteLine("Right argument null: Fail");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Right argument null: Pass");
            }

            // left argument `null`
            try
            {
                var m = new BitMatrix(2, 2) ^ (BitMatrix)null;
                Console.WriteLine(m);
                Console.WriteLine("Left argument null: Fail");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Left argument null: Pass");
            }

            // incorrect dimensions
            try
            {
                var m = new BitMatrix(2, 3) ^ new BitMatrix(2, 2);
                Console.WriteLine(m);
                Console.WriteLine("Incorrect dimensions: Fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect dimensions: Pass");
            }

        }
    }
}
