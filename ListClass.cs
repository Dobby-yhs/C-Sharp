using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class MyList<T> : IEnumerable<T>
    {
        const int DEFAULT_SIZE = 4;

        private T[] arr = new T[DEFAULT_SIZE];
        private int _count = 0;

        public int Count => _count;
        public int Capacity => arr.Length;
        public bool IsEmpty => _count == 0;
        public bool IsFull => _count == Capacity;

        public MyList() : this(DEFAULT_SIZE) { }
        public MyList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            arr = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return arr[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                arr[index] = value;
            }
        }

        public void Add(T item)
        {
            if (IsFull)
                Resize();

            arr[_count++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (IsFull)
                Resize();

            for (int i = _count; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[index] = item;
            _count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            for (int i = index; i < _count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            _count--;
            arr[_count] = default;
        }

        public int IndexOf(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < _count; i++)
            {
                if (comparer.Equals(arr[i], item))
                    return i;
            }

            return -1;
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(arr[i]))
                    return arr[i];
            }

            return default;
        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(arr[i]))
                    return i;
            }

            return -1;
        }

        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < _count; i++)
            {
                if (comparer.Equals(arr[i], item))
                    return true;
            }

            return false;
        }

        public void Clear()
        {
            Array.Clear(arr, 0, _count);

            //for (int i = 0; i < _count; i++)
            //{
            //    arr[i] = default;
            //}

            _count = 0;
        }

        public void Reverse()
        {
            // 효율적 방식
            int left = 0;
            int right = _count - 1;

            while (left < right)
            {
                T temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                left++;
                right--;
            }

            // Array의 Reverse() 메서드 활용
            // Array.Reverse(arr);

            // 새 배열 생성하여 구현
            /*
            T[] newArr = new T[Capacity];
            int j = _count - 1;

            for (int i = 0; i < _count; i++)
            {
                newArr[i] = arr[j];
                j--;
            }

            arr = newArr;
            */
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < _count; i++)
            {
                action(arr[i]);
            }
        }

        public int RemoveAll(Predicate<T> match)
        {
            int removed = 0;

            for (int i = 0; i < _count; i++)
            {
                if (match(arr[i]))
                {
                    RemoveAt(i);
                    i--;
                    removed++;
                }
            }

            return removed;
        }

        public void Sort()
        {
            // Quick Sort 활용
            if (_count <= 1)
                return;

            QuickSort(0, _count - 1);

            // Insertion Sort (삽입 정렬) 활용
            /*
            for (int i = 1; i < _count; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && Comparer<T>.Default.Compare(arr[j], key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;                
            }
            */

            // Array의 Sort 메서드 활용
            // Array.Sort(arr, 0, _count);
        }

        public void QuickSort(int left, int right)
        {
            if (left >= right)
                return;

            int pivotIndex = Partition(left, right);

            QuickSort(left, pivotIndex);
            QuickSort(pivotIndex + 1, right);
        }

        private int Partition(int left, int right)
        {
            int mid = (left + right) / 2;
            Swap(mid, right);

            T pivot = arr[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (Comparer<T>.Default.Compare(arr[j], pivot) < 0)
                {
                    Swap(i, j);
                    i++;
                }
            }

            Swap(i, right);
            return i;
        }

        private void Swap(int i, int j)
        {
            if (i == j)
                return;

            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public T[] ToArray()
        {
            T[] newArr = new T[_count];

            for (int i = 0; i < _count; i++)
            {
                newArr[i] = arr[i];
            }

            return newArr;
        }

        public void TrimExcess()
        {
            if (IsFull)
                return;

            int newCapacity = _count == 0 ? DEFAULT_SIZE : _count;
            T[] newArr = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        private void Resize()
        {
            int newCapacity = Capacity == 0 ? DEFAULT_SIZE : Capacity * 2;
            T[] newArr = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
                yield return arr[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class DebugingList()
    {
        public MyList<int> myList = new MyList<int>();

        public void Test()
        {
            bool isTest = myList.IsEmpty;
            isTest = myList.IsFull;

            myList.Add(101);
            myList.Add(102);
            myList.Add(103);
            myList.Add(104);
            myList.Add(105);

            myList.Remove(103);
            myList.RemoveAt(3);

            isTest = myList.IsEmpty;
            isTest = myList.IsFull;

            myList.Clear();

            int[] arr = new int[5];
            arr[0] = 105;
            arr[1] = 104;
            arr[2] = 103;
            arr[3] = 102;
            arr[4] = 101;

            myList.AddRange(arr);
            myList.Sort();

            myList.Add(106);
            myList.Add(107);

            int[] newArr = myList.ToArray();

            myList.Reverse();

            var result = myList.Find(x => x == 101);
            result = myList.FindIndex(x => x == 101);

            myList.ForEach(x => Console.WriteLine(x));

            myList.RemoveAll(x => x % 2 == 0);

            myList.TrimExcess();
        }
    }
}
