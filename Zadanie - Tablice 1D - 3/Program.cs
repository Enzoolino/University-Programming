
using System.Runtime.CompilerServices;
using System.Collections.Generic;
namespace tabliceZadanie
{

    class Tablica1
    {

        public static void Main(string[] args)
        {
            var a = new int[] { -2, -1, 0, 1, 2, 3, 4, 4 };
            var b = new int[] { -3, -2, -1, 0, 1, 2, 3, 5 };

            Print(a, b);


        }


        //Iteruje a przez każde b
        public static void Print(int[] a, int[] b)
        {
            var ab = new int[a.Length + b.Length];

            Array.Copy(a, ab, a.Length);
            Array.Copy(b, 0, ab, a.Length, b.Length);

            Array.Sort(ab);



            bool empty = true;
            int checkDuplication = ab[0];

            for (int i = 0; i < ab.Length; i++)
            {

                //bool duplication = true;
                int count = 0;
                bool notContainingA = true;
                bool notContainingB = true;

                for (int j = 0; j < ab.Length; j++)
                {

                    if (ab[i] == ab[j])
                    {
                        count++;  
                    }
                }

                for (int l = 0; l < a.Length; l++)
                {
                    if (ab[i] == a[l])
                    {
                        notContainingA = false;
                    }
                }

                for (int k = 0; k < b.Length; k++)
                {
                    if (ab[i] == b[k])
                    {
                        notContainingB = false;
                    }
                }


                if (count == 1 || (notContainingA == false && notContainingB) || (notContainingA && notContainingB == false))
                {
                    empty = false;

                    if (count > 1 && checkDuplication != ab[i])
                    {
                        Console.Write(ab[i] + " ");
                        checkDuplication = ab[i];
                    }
                    else if (count == 1)
                    {
                        Console.Write(ab[i] + " ");
                    }
                    
                }
                
            }

            if (empty)
                Console.WriteLine("empty");
            

        }
    }


}


