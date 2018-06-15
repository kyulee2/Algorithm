/*
Given n nodes labeled from 0 to n-1 and a list of undirected edges (each edge is a pair of nodes), write a function to check whether these edges make up a valid tree.
Example 1:
Input: n = 5, and edges = [[0,1], [0,2], [0,3], [1,4]]
Output: true
Example 2:
Input: n = 5, and edges = [[0,1], [1,2], [2,3], [1,3], [1,4]]
Output: false
Note: you can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0,1] is the same as [1,0] and thus will not appear together in edges.
*/
// Comment: The graph is undirected map. So, I added both edges from src to tgt, vice-versa.
// The tricky part is to track such edge maps (visitedmap) not to visit back using the same edge.
// visited map below for node is to detect cycle. To be a valid tree, we can check this by starting from any node.
// Only spoiler is n<2 or empty edge set case.
public class Solution
{
    Dictionary<int, HashSet<int>> map;
    Dictionary<int, HashSet<int>> visitedmap;
    HashSet<int> visited;
    int len;
    void createNode(int src)
    {
        if (!map.ContainsKey(src)) { 
            map[src] = new HashSet<int>();
            visitedmap[src] = new HashSet<int>();
        }
    }

    void addEdge(int src, int tgt)
    {
        map[src].Add(tgt);
        map[tgt].Add(src);
    }

    bool Rec(int n)
    {
        if (visited.Contains(n))
            return false;
        visited.Add(n);
        bool ans = true;
        foreach(var c in map[n])
        {
            if (visitedmap[n].Contains(c))
                continue;
            // Mark visited edge n <-> c
            visitedmap[n].Add(c);
            visitedmap[c].Add(n);

            ans &= Rec(c);
        }
        return ans;
    }

    public bool ValidTree(int n, int[,] edges)
    {
        visitedmap = new Dictionary<int, HashSet<int>>();
        map = new Dictionary<int, HashSet<int>>();
        visited = new HashSet<int>();
        len = edges.GetLength(0);
        for(int i=0; i<len;i++)
        {
            int src = edges[i, 0];
            int tgt = edges[i, 1];
            createNode(src);
            createNode(tgt);
            addEdge(src, tgt);
        }
        // Spoiler: 1,[] -- this should be false, I think
        // But test wants true.
        // while 2,[] is true.
        // 
        if (map.Count==0 && n<2)
            return true;
        
        if (map.Count != n)
            return false;
        bool ret = Rec(0);
        if (!ret)
            return false;
        return visited.Count == n;
    }
}


