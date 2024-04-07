using System.Collections.Generic;

namespace Multiset
{
    /// <summary>
    /// MultiSet, to rozszerzenie koncepcji zbioru, dopuszczające przechowywanie duplikatów elementów 
    /// </summary>
    /// <remarks>
    /// * Reprezentacja wewnętrzna: `Dictionary<T, int>`
    /// * Porządek zapamiętania elementów jest bez znaczenia, zatem {a, b, a} jest tym samym multizbiorem, co {a, a, b}
    /// * W konstruktorze można przekazać informację o sposobie porównywania elementów (`IEqualityComparer<T>`)
    /// </remarks>
    /// <typeparam name="T">dowolny typ, bez ograniczeń</typeparam>

    public interface IMultiSet<T> : ICollection<T>, IEnumerable<T>
    {

        #region === from ICollection<T> ============================================
        /*
        // opis metod wymaganych do zaimplementowania z ICollection<T>

        // zwraca liczbę wszystkich elementów multizbioru (łącznie z duplikatami)
        public int Count { get; }

        // zwraca `true` jeśli multibiór jest tylko do odczytu, `false` w przeciwnym przypadku
        public bool IsReadOnly { get; }

        // dodaje element do multizbioru
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        public void Add (T item);

        // usuwa element z multizbioru, zwraca `true`, jesli operacja przebiegła pomyślnie, 
        // `false` w przeciwnym przypadku (elementu nie znaleziono)
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        public bool Remove (T item);

        // zwraca `true`, jeśli element należy do multizbioru
        public bool Contains (T item);

        // usuwa wszystkie elementy z multizbioru
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        public void Clear ();

        // kopiuje elementy multizbioru do tablicy, od wskazanego indeksu
        public void CopyTo (T[] array, int arrayIndex);

        */

        // --- from IEnumerable<T> --------------------------

        /*
        // zwraca iterator multizbioru (wariant generyczny)
        public IEnumerator<T> GetEnumerator();

        // zwraca iterator multizbioru (wariant niegeneryczny)
        // C#8 default implementation
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        */
        #endregion -----------------------------------------------------------------


        // dodaje `numberOfItems` takich samych elementów `item` do multizbioru 
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> Add (T item, int numberOfItems = 1);

        // usuwa `numberOfItems` elementów `item` z multizbioru,
        // jeśli `numberOfItems` jest większa niż liczba faktycznie przechowywanych elementów
        //   usuwa wszystkie
        // jesli elementu nie znaleziono - nic nie robi, nie zgłasza żadnego wyjątku
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> Remove (T item,  int numberOfItems = 1);

        // usuwa wszystkie elementy `item`
        // jesli elementu nie znaleziono - nic nie robi, nie zgłasza żadnego wyjątku
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> RemoveAll(T item);

        // dodaje sekwencję `IEnumerable<T>` do multizbioru
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> UnionWith (IEnumerable<T> other);

        // modyfikuje bieżący multizbiór tak, aby zawierał tylko elementy wspólne z `other`
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> IntersectWith(IEnumerable<T> other);

        // modyfikuje bieżący multizbiór tak, aby zawierał tylko te 
        // które nie wystepują w `other`
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> ExceptWith(IEnumerable<T> other);

        // modyfikuje bieżący multizbiór tak, aby zawierał tylko te elementy
        // które wystepują w `other` lub występują w bieżacym multizbiorze,
        // ale nie wystepują równocześnie w obu
        // zgłasza `ArgumentNullException` jeśli `other` jest `null`
        // zgłasza `NotSupportedException` jeśli multizbior jest tylko do odczytu
        // zwraca referencję tej instancji multizbioru (`this`)
        public MultiSet<T> SymmetricExceptWith(IEnumerable<T> other);

        // określa, czy multizbiór jest podzbiorem `other`
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsSubsetOf(IEnumerable<T> other);

        // określa, czy multizbiór jest podzbiorem właściwym `other` (silna inkluzja)
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsProperSubsetOf(IEnumerable<T> other);

        // określa, czy multizbiór jest nadzbiorem `other`
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsSupersetOf(IEnumerable<T> other);

        // określa, czy multizbiór jest nadzbiorem właściwym `other` (silna inkluzja)
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool IsProperSupersetOf(IEnumerable<T> other);

        // określa, czy multizbiór i `other` mają przynajmniej jeden element wspólny
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool Overlaps(IEnumerable<T> other);

        // określa, czy multizbiór i `other` mają takie same elementy w tej samej liczności
        // nie zwracając uwagi na kolejność ich zapamiętania
        // zgłasza `ArgumentNullException`, jeśli `other` jest `null`
        public bool MultiSetEquals(IEnumerable<T> other);

        // określa, czy multizbiór jest pusty     
        public bool IsEmpty { get; }

        // zwraca obiekt wykorzystywany do określania równości elementów kolekcji
        public IEqualityComparer<T> Comparer { get; }
        // -------------------------


        // indexer, zwraca, dla zadanego `item`, liczbę jego powtórzeń w multizbiorze
        public int this[T item] { get; }

        // zwraca MultiSet jako Dictionary
        public IReadOnlyDictionary<T, int> AsDictionary();

        // zwraca MultiSet jako Set, usuwając duplikaty
        public IReadOnlySet<T> AsSet();


        // -------------------------
        // konstruktory, metody statyczne i operatory -> do zaimplementowania (nie da się zadeklarować w interfejsie)


        // zwraca pusty multizbiór
        public static IMultiSet<T> Empty { get; }

        /*
        // Konstruktor, tworzy pusty multizbiór
        public MultiSet();

        // Konstruktor, tworzy pusty multizbiór, w którym równość elementów zdefiniowana jest
        // za pomocą obiektu `comparer`
        public MultiSet(IEqualityComparer<T> comparer)

        // Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
        public MultiSet(IEnumerable<T> sequence)

        // Konstruktor, tworzy multizbiór wczytując wszystkie elementy z `sequence`
        // Równośc elementów zdefiniowana jest za pomocą obiektu `comparer`
        public MultiSet(IEnumerable<T> sequence, IEqualityComparer<T> comparer)

        // tworzy nowy multizbiór jako sumę multizbiorów `first` i `second`
        // zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator +(IMultiSet<T> first, IMultiSet<T> second);

        // tworzy nowy multizbiór jako różnicę multizbiorów: od `first` odejmuje `second`
        // zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator -(IMultiSet<T> first, IMultiSet<T> second);

        // tworzy nowy multizbiór jako część wspólną multizbiorów `first` oraz `second`
        // zwraca `ArgumentNullException`, jeśli którykolwiek z parametrów jest `null`
        public static IMultiSet<T> operator *(IMultiSet<T> first, IMultiSet<T> second);
        */
    }
}