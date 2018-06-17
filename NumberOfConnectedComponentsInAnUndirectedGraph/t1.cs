/*
Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes), write a function to find the number of connected components in an undirected graph.

Example 1:

Input: n = 5 and edges = [[0, 1], [1, 2], [3, 4]]

     0          3
     |          |
     1 --- 2    4 

Output: 2
Example 2:

Input: n = 5 and edges = [[0, 1], [1, 2], [2, 3], [3, 4]]

     0           4
     |           |
     1 --- 2 --- 3

Output:  1
Note:
You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

*/
// Comment: Here for undirected edges, I used one edge creation shared by two src/tgt node.
// This is enough to get this problem. All we need to check if a node is already part of in a group id.
// This way simplifies to handle visited edge set. If two edges created, then need to remove both for each next node visit.
// Somewhat straigh-forward. Carefule to create/use data structure api.
public class Solution {
    int id;
    Dictionary<int, List<int[]>> map; // node to edge
    HashSet<int[]> visited; // edge visited map
    Dictionary<int, int> gmap; // node to group id
            
    void Rec(int n)
    {
        gmap[n] = id;
        foreach(var e in map[n]) {
            if(visited.Contains(e)) continue;
            visited.Add(e);
            
            int s = e[0];
            int t = e[1];
            gmap[s] = id;
            gmap[t] = id;
            int next = s == n ? t : s;
            Rec(next);
        }
    }

    public int CountComponents(int n, int[,] edges) {
        // init data
        map = new Dictionary<int, List<int[]>>();
        visited = new HashSet<int[]>();
        gmap = new Dictionary<int, int>();
        
        // create node/edge map
        for(int i=0; i<n; i++)
            map[i] = new List<int[]>();
        for(int i=0; i<edges.GetLength(0); i++) {
            int s = edges[i,0];
            int t = edges[i,1];
            int[] e = new int[]{s,t};
            map[s].Add(e);
            map[t].Add(e); // share one edge for both s/t
            // we don't need two distinct edges for this problem.
        }
        
        // Rec
        for(int i=0; i<n; i++) {
            if (gmap.ContainsKey(i))
                continue;
            ++id;
            visited.Clear();
            Rec(i);
        }
        return id;
    }
}

