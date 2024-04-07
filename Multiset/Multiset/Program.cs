using Multiset;

namespace Multiset.Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            MultiSet<int> Janusz = new MultiSet<int>();
            MultiSet<int> Matylda = new MultiSet<int>();


            //Add & Remove
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);
            Janusz.Add(1, 2);

            Janusz.Remove(1);

            Janusz.PrintMultiSet();

            Console.WriteLine($"Total count: {Janusz.Count}");
            */

            //-------------------------------------------------------//

            //RemoveAll
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);
            Janusz.Add(1, 2);

            Janusz.RemoveAll(1);

            Janusz.PrintMultiSet();

            Console.WriteLine($"Total count: {Janusz.Count}");
            */

            //-----------------------------------------------------//

            //UnionWith
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);
            Janusz.Add(1, 2);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            Janusz.UnionWith(Matylda);

            Janusz.PrintMultiSet();

            Console.WriteLine($"Total count: {Janusz.Count}");
            */

            //-----------------------------------------------------//

            //IntersectWith
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);
            Janusz.Add(1, 2);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            Janusz.IntersectWith(Matylda);

            Janusz.PrintMultiSet();

            Console.WriteLine($"Total count: {Janusz.Count}");
            */

            //-----------------------------------------------------//

            //ExceptWith
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);
            Janusz.Add(1, 2);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            Matylda.ExceptWith(Janusz);

            Matylda.PrintMultiSet();

            Console.WriteLine($"Total count: {Matylda.Count}");
            */

            //-----------------------------------------------------//

            //SymmetricExceptWith
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);
            Janusz.Add(1, 2);
            Janusz.Add(5);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            Janusz.SymmetricExceptWith(Matylda);

            Janusz.PrintMultiSet();

            Console.WriteLine($"Total count: {Janusz.Count}");
            */

            //-----------------------------------------------------//

            //Bools
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            bool subset = Janusz.IsSubsetOf(Matylda);
            Console.WriteLine(subset);

            bool properSubset = Janusz.IsProperSubsetOf(Matylda);
            Console.WriteLine(properSubset);

            bool superset = Janusz.IsSupersetOf(Matylda);
            Console.WriteLine(superset);

            bool properSuperset = Janusz.IsProperSupersetOf(Matylda);
            Console.WriteLine(properSuperset);

            bool overlaps = Janusz.Overlaps(Matylda);
            Console.WriteLine(overlaps);


            //Equal przed wyrównaniem 
            bool before = Janusz.MultiSetEquals(Matylda);
            Console.WriteLine(before);

            //Equal po wyrównaniu 
            Matylda.Remove(4);
            bool after = Janusz.MultiSetEquals(Matylda);
            Console.WriteLine(after);

            //CzyPusty przed wyczyszczeniem
            Console.WriteLine(Janusz.IsEmpty);

            //CzyPusty po wyczyszczeniu
            Janusz.Clear();
            Console.WriteLine(Janusz.IsEmpty);
            */

            //-----------------------------------------------------//

            //Indexer
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            Console.WriteLine(Janusz[1] + Matylda[1]);
            */

            //-----------------------------------------------------//

            //Wypisanie metody Komparowania
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            Console.WriteLine(Janusz.Comparer);
            */

            //-----------------------------------------------------//

            //Sprawdzenie przekształceń na inne typy
            /*
            var result1 = Janusz.AsDictionary();

            if (result1.GetType() == typeof(Dictionary<int, int>))
            {
                Console.WriteLine("Correct Type !");
            }

            var result2 = Janusz.AsSet();

            if (result2.GetType() == typeof(HashSet<int>))
            {
                Console.WriteLine("Correct Type !");
            }
            */

            //-----------------------------------------------------//

            //Operators
            /*
            Janusz.Add(1);
            Janusz.Add(2);
            Janusz.Add(3);

            Matylda.Add(1);
            Matylda.Add(2);
            Matylda.Add(3);
            Matylda.Add(4);

            MultiSet<int> additionResult = Matylda + Janusz;
            additionResult.PrintMultiSet();
            Console.WriteLine(Environment.NewLine);

            MultiSet<int> subtractionResult = Matylda - Janusz;
            subtractionResult.PrintMultiSet();
            Console.WriteLine(Environment.NewLine);

            MultiSet<int> sharedResult = Matylda * Janusz;
            sharedResult.PrintMultiSet();
            */

            //-----------------------------------------------------//

            //Enumerator
            /*
            Janusz.Add(1);
            Janusz.Add(5);
            Janusz.Add(3);
            Janusz.Add(4, 2);

            foreach (int i in Janusz) { Console.WriteLine(i); }
            */
            
        }
    }
}


