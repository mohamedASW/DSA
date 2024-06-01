using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class BinarySearchTree
    {

        private class Node
        {
            internal int value;
            internal Node left;
            internal Node right;
            public Node(int value)
            {
                left = null!;
                right = null!; 
                this.value = value;
            }
        }

        private Node root = null!;


        public void Insert(int value)
        {
            root = InsertHelper(root, value);
        }
        private Node InsertHelper(Node root , int value)
        {
            if (root is null)
            {
                return new Node(value);
            }
            else
            {
                if(root.value > value)
                {
                    root.left = InsertHelper(root.left, value);
                }
                else 
                 root.right = InsertHelper(root.right, value);  
            }
            return root;
        }


        public bool Contain(int value)
        {
            if (isempty())
            {
                return false;
            }
            return contain(root, value);
        }
        bool contain(Node root , int value)
        {
            if (value == root.value)
            {
                return true;
            }
           else if (value > root.value)
            {
                if (root.right is null)
                    return false;
                return contain(root.right, value);
            }
            else
            {
                if (root.left is null)
                    return false;
                return contain(root.left, value);
            }

        }
        bool isempty() => root is null;

        public int Max()
        {
            if (isempty())
                throw new Exception("no items to get max ...!");
            return max(root);
        }
        int max(Node root)
        {

          
            if (root.right is not null)
            {
                return max(root.right);
            }
            return root.value;
        } 

        public int Min()
        {
            if (isempty())
                throw new Exception("no items to get max ...!");
            return min(root);
        }
        int min(Node root)
        {
            if (root.left is not null)
            {
                return min(root.left);
            }
            return root.value;
        }

        public int Depth(int value)
        {
            if (isempty())
            {
                return -1;
            }
            int dep = depth(root, value);
            return dep>=0?dep:-1;
        } 
        int depth (Node root , int value)
        {

            if (value == root.value)
            {
                return 0;
            }
            if(value > root.value)
            {
                if (root.right is null)
                    return -10000;
                 return  depth(root.right,value) + 1;

            }
            else
            {
                if (root.left is null)
                    return -10000;
                  return  depth(root.left, value) + 1;

            }
            
        }


        public int Height(int value)
        {
            if (isempty())
            {
                return -1;
            }
            else
            {
                Node n = search(root, value);
                if (n is null)
                    return -1;
                return height(n);
            }
        }
        int height (Node root)
        {
                if (root is null)
                {
                    return -1;
                }
                return 1 + Math.Max(height(root.left), height(root.right));
        }
        Node search(Node root , int value)
        {
            if (root is null || value ==root.value)
            {
                return root!;
            }

            if (value > root.value)
            {
                return search(root.right, value);
            }
            else
                return search(root.left, value);
            
        }

        // BFS 

        public void TravarseWithBFS()
        {

            var tmp = root;
            StringBuilder  stringBuilder = new StringBuilder();
            Queue<Node> nodes = new Queue<Node>();
            if (root is not null)
               nodes.Enqueue(tmp);
           while (nodes.Count!=0){
                var peek = nodes.Dequeue(); ;
                stringBuilder.Append($"{peek.value} , ");

                if (peek.left !=null)
                {
                    nodes.Enqueue(peek.left);
                }
                if (peek.right !=null)
                {
                    nodes.Enqueue (peek.right);
                }
            }
            Console.WriteLine(stringBuilder.ToString().TrimEnd(',', ' ')); 
        }

        // REMOVE 

        public void Delete(int value)
        {
            root = DeleteHelper(root, value);
        }
        private Node DeleteHelper(Node root, int value)
        {
            if (root is null)
                return root!;
            else if (value > root.value)
              root.right = DeleteHelper(root.right, value);
            else if (value < root.value)
               root.left = DeleteHelper(root.left, value);
            else
            {
                if (root.left is null)
                {
                    var right =  root.right;
                    root = null!; 
                    return right;
                }
                else if (root.right is null) {
                    var left = root.left;
                    root = null!;
                    return left;
                }
               else
                {
                    root.value = max(root.left);
                    root.left = DeleteHelper(root.left, root.value);
                }
            }
           return root;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            void print(Node root , StringBuilder builder )
            {
                if (root is not null)
                {
                    builder.Append($"{root.value} , ");
                    print(root.left, builder);
                    print(root.right, builder);
                }
            }
            print(root, builder);
            return builder.ToString().TrimEnd([',', ' ']);
        }
    }
}
