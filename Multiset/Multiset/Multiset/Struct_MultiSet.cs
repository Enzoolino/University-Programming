using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Collections;

namespace Multiset
{
    public struct MultiSet<T> : IMultiSet<T>, IEnumerable<T>, IEnumerator<T>
    {

        private readonly Dictionary<T,int> _valueToNumber = new Dictionary<T,int>();

        #region Constructors
        public MultiSet()
        {
            _valueToNumber = new Dictionary<T, int>();
            Comparer = EqualityComparer<T>.Default;
        }
        
        public MultiSet(IEqualityComparer<T> comparer)
        {
            _valueToNumber = new Dictionary<T, int>(comparer);
            Comparer = comparer;
        }
            
        public MultiSet(IEnumerable<T> sequence) : this()
        {
            _valueToNumber = new Dictionary<T, int>();

            foreach (var item in sequence)
                Add(item);
        }

        public MultiSet(IEnumerable<T> sequence, IEqualityComparer<T> comparer)
        {
            _valueToNumber = new Dictionary<T, int>(comparer);
            Comparer = comparer;

            foreach (var item in sequence)
                Add(item);
        }
        #endregion

        //Zwraca pusty MultiSet
        public static IMultiSet<T> Empty { get => new MultiSet<T>(); }

        //Zwraca boola, który mówi czy MultiSet jest readonly.
        public bool IsReadOnly { get => false; }

        // Określa, czy multizbiór jest pusty
        public bool IsEmpty => this._valueToNumber.Count == 0;

        //Liczba wszystkich elementów MultiSet
        public int Count => _valueToNumber.Values.Sum();

        //Zwraca obiekt wykorzystywany do określania równości
        public IEqualityComparer<T> Comparer { get; private set; }

        //Zwraca Multiset jako Dictionary
        public IReadOnlyDictionary<T, int> AsDictionary() { return this._valueToNumber; }

        //Zwraca Multiset jako Set
        public IReadOnlySet<T> AsSet()
        {
            var set = new HashSet<T>(this._valueToNumber.Keys);
            return set;
        }

        #region Enumerator
        public IEnumerator<T> GetEnumerator()
        {
            return _valueToNumber.SelectMany(kvp => Enumerable.Repeat(kvp.Key, kvp.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        int position = -1;

        public T Current => _valueToNumber.ElementAt(position).Key;
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //Brak elementów, których trzeba się pozbyć
        }

        public bool MoveNext()
        {
            position++;
            return position < _valueToNumber.Count;
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion

        #region Multiset Functions
        public MultiSet<T> Add(T item, int numberOfItems = 1)
        {
            if (IsReadOnly)
                throw new NotSupportedException();

            if (_valueToNumber.ContainsKey(item))
            {
                _valueToNumber[item] += numberOfItems;
            }
            else
            {
                _valueToNumber.Add(item, numberOfItems);
            }
            return this;
        }


        bool removalSucces = true;
        public MultiSet<T> Remove(T item, int numberOfItems = 1)
        {
            if (IsReadOnly)
                throw new NotSupportedException();

            if (_valueToNumber.ContainsKey(item))
            {
                int result = _valueToNumber[item] -= numberOfItems;

                if (result <= 0)
                {
                    _valueToNumber.Remove(item);
                }
                else
                {
                    _valueToNumber[item] = result;
                }
                removalSucces = true;
            }
            else
                removalSucces = false;

            return this;
        }

        public MultiSet<T> RemoveAll(T item)
        {
            if (IsReadOnly)
                throw new NotSupportedException();

            if (_valueToNumber.ContainsKey(item))
            {
                _valueToNumber.Remove(item);
            }
            
            return this;
        }

        public MultiSet<T> UnionWith(IEnumerable<T> other)
        {
            if (other is null) 
                throw new ArgumentNullException(nameof(other));

            if (IsReadOnly)
                throw new NotSupportedException();

            foreach (var item in other)
            {
                Add(item);
            }

            return this;
        }

        public MultiSet<T> IntersectWith(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            if (IsReadOnly)
                throw new NotSupportedException();

            foreach (var mainItem in _valueToNumber.Keys)
            {
                if (!other.Contains(mainItem))
                {
                    RemoveAll(mainItem);
                }
            }
            return this;
        }

        public MultiSet<T> ExceptWith(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            if (IsReadOnly)
                throw new NotSupportedException();

            foreach (var mainItem in _valueToNumber.Keys)
            {
                if (other.Contains(mainItem))
                {
                    RemoveAll(mainItem);
                }
            }
            return this;
        }

        public MultiSet<T> SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            if (IsReadOnly)
                throw new NotSupportedException();

            foreach (var item in other)
            {
                if (_valueToNumber.Keys.Contains(item))
                {
                    RemoveAll(item);
                }
                else
                {
                    Add(item);
                }
            }
            return this;
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            foreach (var mainItem in _valueToNumber.Keys)
            {
                if (!other.Contains(mainItem))
                    return false;
            }
            return true;
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            if (IsSubsetOf(other) && _valueToNumber.Count < other.Count())
                return true;
            else 
                return false;     
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                if (!_valueToNumber.ContainsKey(item))
                    return false;
            }
            return true;
        }


        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            if (IsSupersetOf(other) && _valueToNumber.Count > other.Count())
                return true;
            else
                return false;
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            foreach (var mainItem in _valueToNumber.Keys)
            {
                if (other.Contains(mainItem))
                    return true;
            }
            return false;
        }

        public bool MultiSetEquals(IEnumerable<T> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            MultiSet<T> otherSet = new MultiSet<T>(other);

            if (_valueToNumber.Keys.Count != otherSet.Count())
                return false;

            foreach (var item in _valueToNumber.Keys)
            {
                if (!otherSet._valueToNumber.TryGetValue(item, out int otherCount) || _valueToNumber[item] != otherCount)
                {
                    return false;
                }
            }
            return true;
        }

        //Indexer
        public int this[T item] { get => _valueToNumber[item]; }

        public void PrintMultiSet()
        {
            Console.WriteLine("MultiSet elements:");
            foreach (var item in _valueToNumber.Keys)
            {
                Console.WriteLine($"Value: {item}, Amount: {_valueToNumber[item]}");
            }
        }

        #endregion

        #region Collection Functions
        public void Add(T item)
        {
            Add(item, 1);
        }

        public bool Remove(T item)
        {
            Remove(item, 1);
            return removalSucces;
        }

        public void Clear()
        {
            _valueToNumber.Clear();
        }

        public bool Contains(T item)
        {
            if (_valueToNumber.ContainsKey(item)) 
                return true;
            else 
                return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("The number of elements in the multiset is greater than the available space from arrayIndex to the end of the destination array.");

            int currentIndex = arrayIndex;
            foreach (var item in this)
            {
                array[currentIndex] = item;
                currentIndex++;
            }
        }



        #endregion

        #region Operators
        public static MultiSet<T> operator +(MultiSet<T> first, MultiSet<T> second)
        {
            if (first._valueToNumber == null || second._valueToNumber == null)
                throw new ArgumentNullException(nameof(first));

            MultiSet<T> result = new MultiSet<T> (first);
            result.UnionWith(second);

            return result;
        }

        public static MultiSet<T> operator -(MultiSet<T> first, MultiSet<T> second)
        {
            if (first._valueToNumber == null || second._valueToNumber == null)
                throw new ArgumentNullException(nameof(first));

            MultiSet<T> result = new MultiSet<T> (first);

            foreach (var item in second)
            {
                result.Remove(item, second._valueToNumber[item]);
            }

            return result;
        }

        public static MultiSet<T> operator *(MultiSet<T> first, MultiSet<T> second)
        {
            if (first._valueToNumber == null || second._valueToNumber == null)
                throw new ArgumentNullException(nameof(first));

            MultiSet<T> result = new MultiSet<T>(first);
            result.IntersectWith(second);

            return result;
        }

        #endregion

    }
}
