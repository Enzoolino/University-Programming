
using System;
using System.Linq;



class Program
{
    static void Main(string[] args)
    {
        try
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            if (checked(a + b == c + d || b + c == a + d || c + d == a + b || c + a == b + d))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        catch(OverflowException)
        {
            Console.WriteLine("overflow exception, exit");
        }
        catch(ArgumentException)
        {
            Console.WriteLine("argument exception, exit");
        }
        catch(FormatException)
        {
            Console.WriteLine("format exception, exit");
        }
        catch(Exception)
        {
            Console.WriteLine("non supported exception, exit");
        }
    }
}

