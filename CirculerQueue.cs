using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class CirculerQueue 
    { 
        private int[] arr; int front, rear,count;
        public int Capcity { get; }

        public CirculerQueue(int n)
        {
            Capcity = n;
           arr = new int[n];
            front = 0;
            rear = -1;
            count = 0;
        }

        public void Enqueue(int value)
        {
            if (IsFull())
            {
                throw new InvalidOperationException();
            }
             rear= (rear+1) % Capcity;
            arr[rear] = value;
            count++;
        }

        public bool IsEmpty() =>
                  count == 0;

        public bool IsFull() =>
                  count == Capcity;
        
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
           
            int val = arr[front];
            front = (front+1) % Capcity;
            count--;
            if (IsEmpty())
            {
                front = -1;
                rear = -1;
            }
            return val;

        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return arr[front];
        }
                       


        public bool Contain(int val) {

            if (IsEmpty())
            {
                return false;
            }
            for (int i = 0; i < count; i++)
            {
                if (arr[i] == val)
                    return true;
            }
            return false;
        
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int i = 0; 
            int current = front;
            while (i < count)
            {
                stringBuilder.Append($"{arr[current]} , ");
                current = (current + 1) % Capcity;
                i++;
            }
            var output = stringBuilder.ToString().TrimEnd([' ', ',']);
            return output;
        }
    }
}
