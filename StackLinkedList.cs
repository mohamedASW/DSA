using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class StackLinkedList
    {
        private LinkedList innerLinkedList = new LinkedList();
        public void Push(int value)=>
                                  innerLinkedList.InsertFront(value);    
        public int Pop()=>
                   innerLinkedList.Shift();
        

        public int Top()=> 
                   innerLinkedList.Front;
        
        public bool Contain(int value)
            => innerLinkedList.Contain(value);

        public override string ToString()
        {
            return innerLinkedList.ToString();
        }

    }
}
