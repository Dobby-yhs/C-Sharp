using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm
{
    class MyStack<T> : IEnumerable<T>
    {
        const int DEFAULT_SIZE = 4;
        private T[] _stackArr = new T[DEFAULT_SIZE];
        private int _count = 0;

        public int Count => _count;
        public int Capacity => _stackArr.Length;
        public bool IsEmpty => _count == 0;

        public MyStack() : this(DEFAULT_SIZE) { }

        public MyStack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(Capacity));

            _stackArr = new T[capacity];
        }

        public void Push(T item)
        {
            if (_count >= Capacity)
                Resize();

            _stackArr[_count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            T temp = _stackArr[_count - 1];
            _stackArr[_count - 1] = default;
            _count--;

            return temp;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return _stackArr[_count - 1];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_stackArr[i], item))
                    return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];

            for (int i = 0; i < _count; i++)
                result[i] = _stackArr[_count - 1 - i];

            return result;
        }

        public void Clear()
        {

            Array.Clear(_stackArr, 0, _count);

            _count = 0;
        }

        private void Resize()
        {
            int newCapacity = Capacity == 0 ? DEFAULT_SIZE : Capacity * 2;
            T[] newStackArr = new T[newCapacity];

            for (int i = 0; i < _count; i++)
                newStackArr[i] = _stackArr[i];

            _stackArr = newStackArr;
        }

        public void TrimpExcess()
        {
            if (_count == Capacity)
                return;

            T[] newStackArr = new T[_count];

            for (int i = 0; i < _count; i++)
                newStackArr[i] = _stackArr[i];

            _stackArr = newStackArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _count - 1; i >= 0; i--)
                yield return _stackArr[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class DebugTest
    {
        public MyStack<int> _stack = new MyStack<int>();

        public void Test()
        {
            bool isEmpty = _stack.IsEmpty;

            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);
            _stack.Push(40);
            _stack.Push(50);

            isEmpty = _stack.IsEmpty;

            foreach (int item in _stack)
            {
                Console.WriteLine(item);
            }

            int[] data = _stack.ToArray<int>();

            int temp1 = _stack.Pop();
            int temp2 = _stack.Peek();

            bool temp3 = _stack.Contains(50);
            bool temp4 = _stack.Contains(40);

            _stack.Clear();
            _stack.TrimpExcess();
        }
    }
}
