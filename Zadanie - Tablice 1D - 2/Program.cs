
namespace Tablice1D
{
    class Tablica2
    {


        public static void Main(string[] args)
        {
            var a = new int[] {0, 3, 4, -3 };
            var b = new int[] { 20, -3, 3, 0, 3, 4, 3, 10, 4, 4, 4 };

            Print(a, b);

          
        }

        public static void Print(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            bool empty = true;
            int overflow = int.MinValue;

            for (int i = 0; i < a.Length; i++)
            {
                bool hasReference = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j] && a[i] != overflow)
                    {
                        hasReference = true;
                        overflow = a[i];
                        
                    }

                    if (hasReference)
                    {
                        empty = false;
                        if (a[i] == a[0])
                        {
                            Console.Write(a[i] + " ");
                            break;
                        }
                        else if (a[i - 1] != a[i])
                        {
                            Console.Write(a[i] + " ");
                            break;
                        }
                    }
                }
            }
            if (empty)
                Console.WriteLine("empty");


        }
    }
}