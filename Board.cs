using System;

namespace CSharp
{
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0;  // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } }  // 예약된 데이터 개수

        // O(1)
        // O(N)과 같지만, 조건문이 거의 실행되지 않는다고 가정하여 O(1)로 본다.
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인
            if (Count >= Capacity)
            {
                // 공간 확보
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }

            // 2. 공간에 데이터를 삽입
            _data[Count++] = item;
        }

        // O(1)
        // 인덱서 문법
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];
            _data[Count - 1] = default(T); // T라는 형식의 초기값으로 Count - 1번째 인덱스를 설정

            Count--;
        }
    }

    class Board
    {
        public int[] _data = new int[25];   // 배열
        public MyList<int> _data2 = new MyList<int>();  // 동적 배열 (c++의 vector)
        public LinkedList<int> _data3 = new LinkedList<int>();  // 연결 리스트 (c++의 list)

        public void Initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}
