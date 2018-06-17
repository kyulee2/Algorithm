/*
For a undirected graph with tree characteristics, we can choose any node as the root. The result graph is then a rooted tree. Among all possible rooted trees, those with minimum height are called minimum height trees (MHTs). Given such a graph, write a function to find all the MHTs and return a list of their root labels.

Format
The graph contains n nodes which are labeled from 0 to n - 1. You will be given the number n and a list of undirected edges (each edge is a pair of labels).

You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

Example 1 :

Input: n = 4, edges = [[1, 0], [1, 2], [1, 3]]

        0
        |
        1
       / \
      2   3 

Output: [1]
Example 2 :

Input: n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]

     0  1  2
      \ | /
        3
        |
        4
        |
        5 

Output: [3, 4]
Note:

According to the definition of tree on Wikipedia: Î tree is an undirected graph in which any two vertices are connected by exactly one path. In other words, any connected graph without simple cycles is a tree.Î
The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.
*/
// Comment: Navie recursion results in time-out. Should cache edge to distance where edge has a directed one.
// So, when we build graph, we actually add two different edges from s to e, and e to s.
// But considering distance (which resturns from the child node), consider the direction.
public class Solution {
    Dictionary<int, List<int[]>> map;
    HashSet<int[]> visited;
    Dictionary<int[], int> cache;
    int Rec(int n)
    {
        int d = 0;
        foreach(var t in map[n]) {
            if (visited.Contains(t))
                continue;
            visited.Add(t);
            // Also set visited from e to s
            foreach(var e in map[t[1]])
                if (e[1] == n)
                    visited.Add(e);
            
            if (cache.ContainsKey(t)) {
                d = Math.Max(d, cache[t]);
            } else {
                int h = Rec(t[1]) + 1;
                cache[t] = h;
                d = Math.Max(d, h);
            }
        }
        return d;
    }
    
    List<int> ans;
    int min;
    public IList<int> FindMinHeightTrees(int n, int[,] edges) {
        // Init data
        min = Int32.MaxValue;
        ans = new List<int>();
        map = new Dictionary<int, List<int[]>>();
        cache = new Dictionary<int[], int>();
        visited = new HashSet<int[]>();
        int len = edges.GetLength(0);
        // Create node
        for(int i=0; i<n; i++)
            map[i] = new List<int[]>();
        
        // Create edges
        for(int i=0; i<len; i++) {
            int s = edges[i,0];
            int t = edges[i,1];
            map[s].Add(new int[]{s,t});
            map[t].Add(new int[]{t,s});
        }
        
        // Main recursion
        for(int i=0; i<n; i++) {
            visited.Clear();
            int h = Rec(i);
            if (h<min) {
                min = h;
                ans.Clear();
                ans.Add(i);
            }
            else if (h==min) {
                ans.Add(i);
            }
        }
        
        return ans;
        
    }
}

