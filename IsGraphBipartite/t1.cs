/*
Given an undirected graph, return true if and only if it is bipartite.
Recall that a graph is bipartite if we can split it's set of nodes into two independent subsets A and B such that every edge in the graph has one node in A and another node in B.
The graph is given in the following form: graph[i] is a list of indexes j for which the edge between nodes i and j exists.  Each node is an integer between 0 and graph.length - 1.  There are no self edges or parallel edges: graph[i] does not contain i, and it doesn't contain any element twice.
Example 1:
Input: [[1,3], [0,2], [1,3], [0,2]]
Output: true
Explanation: 
The graph looks like this:
0----1
|    |
|    |
3----2
We can divide the vertices into two groups: {0, 2} and {1, 3}.
Example 2:
Input: [[1,2,3], [0,2], [0,1,3], [0,2]]
Output: false
Explanation: 
The graph looks like this:
0----1
| \  |
|  \ |
3----2
We cannot find a way to divide the set of nodes into two independent subsets.
 
Note:
graph will have length in range [1, 100].
graph[i] will contain integers in range [0, graph.length - 1].
graph[i] will not contain i or duplicate values.
The graph is undirected: if any element j is in graph[i], then i will be in graph[j].
*/
// Comment: Essentially the same problem as PossibleBipartition. Only difference is the way how input graph is given. No assumption about range of node. So, use Dictionary
public class Solution {
    public bool IsBipartite(int[][] graph) {
        // build graph
        int len = graph.Length;
        var map = new Dictionary<int, HashSet<int>>();        
        var status = new Dictionary<int, int>();         
        for(int i=0; i<len; i++) {
            if (!map.ContainsKey(i)) {
                map[i] = new HashSet<int>();
                status[i] = 0;
            }
            foreach(var n in graph[i]) {
                if (!map.ContainsKey(n)) {
                    map[n] = new HashSet<int>();
                    status[n] = 0;
                }
                map[i].Add(n);
                map[n].Add(i);
            }
        }
        

        bool Rec(int r, int c)
        {
            if (status[r] != 0) {
                if (status[r] != c)
                    return false;
                return true;
            }
            status[r] = c;
            
            foreach(var next in map[r])
                if (!Rec(next, c==1 ? 2: 1))
                    return false;
            return true;
        }
        
        // main loop
        foreach(var k in map.Keys) {
            if (status[k] == 0) {
                if (!Rec(k, 1))
                    return false;
            }
        }
        
        return true;
    }
}