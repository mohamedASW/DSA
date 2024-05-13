using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public  class Array
    {
        public int Capcity;
        public int Count = 0;
        int[] array;
        public Array(int capcity)
        {
            this.Capcity = capcity;
            array = new int[Capcity];
        }

        public bool IsFul()
        {
            return Count > Capcity;
        }
        public bool isempty()
        {
            return Count == 0;
        }

        public void push(int value)
        {
            if (!IsFul())
                array[Count++] = value;
            else
                throw new InvalidOperationException("invailed opertion");
        }

        public void InsertAt(int index , int value)
        {
            if(!IsFul())
            {
                for (int i = Count; i >  index; i++)
                {
                    array[i] = array[i - 1]; 
                }
                array[index] = value;
            }
            else
                throw new InvalidOperationException("invailed opertion");
        }

        public void Remove(int value)
        {

            if (Contain(value, out int index))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Count -= 1;
            }
            else
                throw new InvalidOperationException("this value not Existed...!");

        }
        public void RemoveAt(int index)
        {
            if (index > 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Count -= 1;
            }
            else
                throw new InvalidOperationException("this index not Existed...!");

        }

        public bool Contain(int value , out int index)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == value)
                {

                    index = i;
                    return true;

                }
            }
            index = -1;
            return false;
        }

        public void update (int index , int value)
        {
            if (index > 0 && index < Count)
                   array[index] = value;
            else
                throw new InvalidOperationException("this index not Existed...!");
        }


        public override string ToString()
        {
            StringBuilder text = new StringBuilder(); 
            for (int i = 0; i < Count; i++)
            {
                text.Append($"{array[i]}  ");
            }
            return text.ToString();
        }
    }
}
