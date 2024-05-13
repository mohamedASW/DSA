using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary
{
    public class Graph
    {
        int verticesCount;
        List<int>[] AdjList;

        public Graph(int verticescount)
        {
            this.verticesCount = verticescount;

            AdjList = new List<int>[verticescount];
            for (int i = 0; i < verticesCount; i++)
            {
                AdjList[i] = new List<int>();
            }
        }

        public void Add(int headvertix , int lastvertix)
        {
            AdjList[headvertix].Add(lastvertix);
        }


        public void BFS(int startvertix)
        {
            bool[] visited = new bool[verticesCount];
            Queue<int>vertices = new Queue<int>();
            visited[startvertix] = true;
            vertices.Enqueue(startvertix);

            while (vertices.Count!=0)
            {
                var n = vertices.Dequeue();
                Console.WriteLine($"{n}  ");

                foreach (var item in AdjList[n])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        vertices.Enqueue(item);
                    }
                }

            }
        } 

        public int ShortestStepsByBFS(int startvertix , int endvertix)
        {
            bool[] visited = new bool[verticesCount];
            int steps  = 0; 
            bool found = false;
            Queue<int> vertices = new Queue<int>();
            visited[startvertix] = true;
            vertices.Enqueue(startvertix);
            while (vertices.Count!=0)
            {
                var curvertix = vertices.Dequeue();
                steps++;
                foreach (var item in AdjList[curvertix])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        vertices.Enqueue(item);
                        
                        if (item ==endvertix)
                        {
                            found = true;
                            break; 
                        }
                    }
                }
                if (found)
                    break;
            }
            if (found)
                return steps; 
          return -1;
        }

        public List<int> ShortestPathBFS(int sourcevertix, int endvertix)
        {
            bool[] visit = new bool[verticesCount];
            int[] parents = new int[verticesCount];
            System.Array.Fill(parents, -1);
            Queue<int> vertices = new Queue<int>();
            visit[sourcevertix] = true;
            vertices.Enqueue(sourcevertix);

            while (vertices.Count != 0)
            {
                var curvertix = vertices.Dequeue();
                if (curvertix == endvertix)
                    break;
                foreach (var neighbor in AdjList[curvertix])
                {
                    if (!visit[neighbor])
                    {
                        visit[neighbor] = true;
                        parents[neighbor] = curvertix;
                        vertices.Enqueue(neighbor);
                    }
                }

            }

            List<int> bactrackthepath = new List<int>();
            int vertix = endvertix;
            while (vertix != -1)
            {
                bactrackthepath.Add(vertix);
                vertix = parents[vertix];
            }
            bactrackthepath.Reverse();
            return bactrackthepath;

        }

        public  void DFS(int startvertix)
        {
            bool[] visited  = new bool[verticesCount];
           DFSUtlization(startvertix, visited);
        }

        private void DFSUtlization(int startvertix, bool[] visited)
        {
            
            
                Console.Write($"{startvertix}  ");
                visited[startvertix] = true;
                foreach (var vertix in AdjList[startvertix])
                {
                    if (!visited[vertix])
                        DFSUtlization(vertix, visited);
                }

            
        }

        private List<int> DFSshortestpath(int v , int target , bool[] visited , List<int> path , List<List <int>> paths)
        {

            visited[v] = true;
            path.Add(v);
            if (v == target)
            {
                paths.Add(new List<int>(path));
               
            }
            else
            {

                foreach (int vertix in AdjList[v])
                {
                    if (!visited[vertix])
                    {
                        DFSshortestpath(vertix, target, visited, path, paths);
                        
                    }
                }
            }

            path.RemoveAt(path.Count - 1);
            visited[v] = false;
            return path;

        }

        public List<int>? FindPath(int src, int target)
        {
            bool[] visited = new bool[verticesCount];
            List<int> path = new List<int>();
            List<List<int>> paths = new List<List<int>>();
            DFSshortestpath(src, target, visited, path, paths);
            return paths.MinBy(p => p.Count());
        }
    }
}
