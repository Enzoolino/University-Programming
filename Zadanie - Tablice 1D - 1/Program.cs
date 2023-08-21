



using System.Runtime.CompilerServices;

namespace tabliceZadanie
{

    class Tablica1
    {

        public static void Main(string[] args)
        {
            var a = new int[] { -2, -1, 0, 1, 2, 3, 4, 4 };
            var b = new int[] { -3, -2, -1, 0, 1, 2, 3 };

            Print(a, b);


        }


        //Iteruje a przez każde b
        public static void Print(int[] a, int[] b)
        {
            bool empty = true;
            int duplicate = b[0];

            for (int i = 0; i < a.Length; i++)
            {
                bool hasNoReference = true;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        hasNoReference = false;
                        break;
                    }
                    
                }

                if(hasNoReference)
                {
                    empty = false;
                    if (duplicate != a[i])
                    {
                        Console.Write(a[i] + " ");
                        duplicate = a[i];
                    }
                }

                
            }

            if (empty)
            {
                Console.WriteLine("empty");
            }


        }
    }

   
}


