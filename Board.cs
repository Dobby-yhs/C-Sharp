using System;

namespace CSharp
{
    class Node<T>
    {
        public T Data;
        public Node<T> Next;  // 참조
        public Node<T> Prev;
    }

    class MyLinkedList<T>
    {
        public Node<T> Head = null;
        public Node<T> Tail = null;
        public int Count = 0;

        // O(1)
        public Node<T> AddLast(T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = data;

            if (Head == null)
                Head = newNode;

            if (Tail != null)
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }

            Tail = newNode;
            Count++;

            return newNode;
        }

        // O(1)
        // 매개변수의 node가 MyLinkdedList에 속하지 않은 예외의 경우는 없다고 상정하고 진행
        public void Remove(Node<T> node)
        {
            if (Head == node)
                Head = Head.Next;

            if (Tail == node)
                Tail = Tail.Prev;

            if (node.Prev != null)
                node.Prev.Next = node.Next;

            // 해당  node가 Head일 때, Head = Head.Next로 Next에 대한 처리는 하지만 Prev에 대한 처리는 하지 않는다.
            // 그렇기에 해당 node가 Head라면, 아래의 node.Prev가 null일 경우도 발생할 수 있다.
            if (node.Next != null)
                node.Next.Prev = node.Prev;

            Count--;
        }
    }

    class Board
    {
        public int[] _data = new int[25];   // 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();  // 연결 리스트 (c++의 list)

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            Node<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}
