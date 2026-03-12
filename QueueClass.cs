using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm
{
    class MyQueue<T> : IEnumerable<T>
    {
        const int DEFAULT_SIZE = 4;

        private T[] _array = new T[DEFAULT_SIZE];

        private int _head = 0;  // 현재 맨 앞 원소 위치
        private int _tail = 0;  // 다음에 삽입할 위치
        private int _count = 0;

        public int Count => _count;
        public int Capacity => _array.Length;
        public bool IsEmpty => _count == 0;
        private bool IsFull => _count == Capacity;

        public MyQueue() : this(DEFAULT_SIZE) { }
        public MyQueue(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            _array = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (IsFull)
                Resize();

            _array[_tail] = item;
            _tail = (_tail + 1) % Capacity;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            T value = _array[_head];
            _array[_head] = default;

            _head = (_head + 1) % Capacity;
            _count--;

            return value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return _array[_head];
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _array[(_head + i) % Capacity] = default;
            }

            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < _count; i++)
            {
                if (comparer.Equals(_array[(_head + i) % Capacity], item))
                    return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];

            for (int i = 0; i < _count; i++)
            {
                result[i] = _array[(_head + i) % Capacity];
            }

            return result;
        }

        public void TrimExcess()
        {
            if (_count == Capacity)
                return;

            int newCapacity = _count == 0 ? DEFAULT_SIZE : _count;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[(_head + i) % Capacity];
            }

            _array = newArray;
            _head = 0;
            _tail = _count;
        }

        private void Resize()
        {
            int newCapacity = Capacity == 0 ? DEFAULT_SIZE : Capacity * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[(_head + i) % Capacity];
            }

            _array = newArray;
            _head = 0;
            _tail = _count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
                yield return _array[(_head + i) % Capacity];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
