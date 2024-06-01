using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class StackArray
    {
        private Array internalarray ;
        public StackArray(int size )
        {
            internalarray= new Array(size);
        }
        public void Push(int value)
        {
            internalarray.push(value);
        }
        public int Pop()
        {
            if (!internalarray.isempty())
            {
               var value = internalarray[internalarray.Count-1];
                --internalarray.Count;
                return value;
            }
            else
            throw new InvalidOperationException();
        }
        public bool Contain(int value)
        {
            return internalarray.Contain(value);
        }

        public int Top()
        {
            return internalarray[internalarray.Count-1];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = internalarray.Count - 1; i >= 0; i--)
            {
                stringBuilder.Append($"{internalarray[i]} ,  ");
            }
             var output  = stringBuilder.ToString().TrimEnd([',', ' ']);
            return output;
        }
    }
}
