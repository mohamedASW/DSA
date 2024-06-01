using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class LinkedList 
    {

        class Node
        {
            public int value; 
            public Node? Next;
            public Node(int value , Node? next = null )
            {
                    this.value = value;
                    this.Next  = next;
            }
        }
        Node? Head;
        Node? Tail;
        public int Front
        {
            get
            {
                if (Head is not null)
                {
                    return Head.value;
                }
                throw new InvalidOperationException("empty list");
            }
        } 
        public int Rear
        {
            get
            {
                if (Tail is not null)
                {
                    return Tail.value;
                }
                throw new InvalidOperationException("empty list");
            }
        }
            

        int Count = 0; 
        public void Push( int value)
        {
            var node = new Node(value);
            if (Head is null || Tail is null)
            {
                Head = Tail= node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }
        public void InsertFront(int value)
        {
            var node = new Node(value);
            if (Head is null || Tail is null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Count++;
        }
        public bool IsEmpty()
        {
            return Head is null || Tail is null;
               
            
        }
        

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            
             Node tmp = Head!;
            while (tmp!.Next != Tail)
            {
                tmp = tmp.Next!;
            }
            int value = tmp.Next!.value;
            tmp.Next = null;
            Count--;
            Tail = tmp;
            return value;

        }

        public int Shift()
        {
            if (!IsEmpty())
            {
                var val =  Head!.value;
                Head = Head.Next;
                return val; 

            }
            throw new InvalidOperationException("no item in the list ...");
        }

        public void Update(int oldvalue , int newvalue)
        {
            if (Contain(oldvalue))
            {
                var tmp = Head; 
                while (tmp != null)
                {
                    if (tmp.value == oldvalue)
                    {
                        tmp.value = newvalue;
                    }
                    tmp = tmp.Next;
                }
            }
            else
            throw new InvalidOperationException("no value Exists like this ...!");
        }
        public void InsertAt(int index, int value)
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();

            if (index == 0)
                InsertFront(value);
            else
            {
                var node = new Node(value);
                var tmp = Head;
                int i = 0;
                while (i != index-1)
                {
                    tmp = tmp!.Next;
                    i++;
                }
                var t = tmp!.Next;
                tmp.Next = node;
                node.Next = t;
            }
        }
        public bool Contain(int value)
        {
            var temp  = Head;
            while (temp != null)
            {
                if (temp.value == value)
                    return true; 
                temp = temp.Next;
            }
            return false; 
        }
        public override string ToString()
        {
            var tmp = Head; 
            var stringbuilder  = new StringBuilder();
            while (tmp != null)
            {

                stringbuilder.Append($"{tmp.value} ");
                tmp = tmp.Next;
            }
            return stringbuilder.ToString();
        }
    }
}
