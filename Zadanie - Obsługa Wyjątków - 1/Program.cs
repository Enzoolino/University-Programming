




namespace Wyjątki
{

    class Wyjątek1
    {
        public static void Main()
        {


           int a = int.Parse(Console.ReadLine());
           int b = int.Parse(Console.ReadLine());
           int c = int.Parse(Console.ReadLine());
           int precision = 6;

            double perimeter = TrianglePerimeter(a, b, c, precision);
            string formattedNumber = perimeter.ToString("F" + precision);
            Console.WriteLine(formattedNumber);


        }

        public static double TrianglePerimeter(int a, int b, int c, int precision)
        {

            int[] sideArray = new int[] { a, b, c };
            Array.Sort(sideArray);

            if (a < 0 || b < 0 || c < 0 || precision > 8 || precision < 2)
            {
                throw new ArgumentOutOfRangeException("wrong arguments");
            }
            else if (sideArray[0] + sideArray[1] < sideArray[2] )
            {
                throw new ArgumentException("object not exist");
            }



            double perimeter = (double)a + b + c;
            
            return perimeter;

            

        }

    }
}