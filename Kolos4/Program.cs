






class Program
{


    static void Main(string[] args)
    {
        int[][] tab = new int[2][];

        tab[0] = new int[] { 1, 1};
        tab[1] = new int[] { 2, -1};
        


        double result = Srednia(tab);
        Console.WriteLine(result);
    }


    public static double Srednia(int[][] tab)
    {
        double countSum = 0;
        double countNumbers = 0;


        if (tab == null || tab.Length == 0)
        {
            return 0.00;
        }
        else
        {


            foreach (int[] row in tab)
            {
                foreach (int i in row)
                {
                    if (i > 0)
                    {
                        countSum += i;
                        countNumbers++;
                    }
                }
            }

            if (countNumbers == 0)
            {
                return 0.00;
            }

            double average = Math.Round((countSum / countNumbers) * 100.0)/100.0;

            

            return average;
        }

       
    }






}


