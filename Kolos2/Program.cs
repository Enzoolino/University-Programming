





class Program
{

    static void Main(string[] args)
    {

        int basis = 1;
        int edge = -2;
        int precision = -3;

        double result = RegularSquarePyramidVolume(basis, edge, precision);

        string convertedResult = result.ToString("F" + precision);

        Console.WriteLine(convertedResult);

    }




    public static double RegularSquarePyramidVolume(int basis, int edge, int precision)
    {
        if (precision < 2 || precision > 8 || basis < 0 || edge < 0)
        {
            throw new ArgumentOutOfRangeException("wrong arguments");
        }
        
        double x = (Math.Sqrt(2) * basis)/2;
        if ( x > edge)
         {
                throw new ArgumentException("object not exist");
         }


        double PP = basis * basis;
        double H2 = ((double)edge * (double)edge) - (x * x);
        double H = Math.Sqrt(H2);


            double volume = (PP * H) / 3;
            
        

        return Math.Round(volume, precision);
    }


}