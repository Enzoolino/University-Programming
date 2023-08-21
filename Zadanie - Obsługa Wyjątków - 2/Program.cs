using System.Threading.Tasks;
using System.Linq;
using System;



namespace Wyjątki
{
    class Wyjątek2
    {
        static void Main(string[] args)
        {
            
            try
            {
                string input1 = Console.ReadLine();
                string input2 = Console.ReadLine();
                string input3 = Console.ReadLine();


                int convertedInput1 = int.Parse(input1);
                int convertedInput2 = int.Parse(input2);
                int convertedInput3 = int.Parse(input3);

                int result = checked(convertedInput1 * convertedInput2 * convertedInput3);

                Console.WriteLine(result);

            }
            catch (FormatException)
            {
                Console.WriteLine("format exception, exit");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("argument exception, exit");
            }
            catch (OverflowException)
            {
                Console.WriteLine("overflow exception, exit");
            }
            catch (Exception)
            {
                Console.WriteLine("non supported exception, exit");
            }




        }
    }



}

