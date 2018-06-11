/*
In this problem, a tree is an undirected graph that is connected and has no cycles. 
The given input is a graph that started as a tree with N nodes (with distinct values 1, 2, ..., N), with one additional edge added. The added edge has two different vertices chosen from 1 to N, and was not an edge that already existed. 
The resulting graph is given as a 2D-array of edges. Each element of edges is a pair [u, v] with u < v, that represents an undirected edge connecting nodes u and v. 
Return an edge that can be removed so that the resulting graph is a tree of N nodes. If there are multiple answers, return the answer that occurs last in the given 2D-array. The answer edge [u, v] should be in the same format, with u < v. 
Example 1:
Input: [[1,2], [1,3], [2,3]]
Output: [2,3]
Explanation: The given undirected graph will be like this:
  1
 / \
2 - 3

Example 2:
Input: [[1,2], [2,3], [3,4], [1,4], [1,5]]
Output: [1,4]
Explanation: The given undirected graph will be like this:
5 - 1 - 2
    |   |
    4 - 3

Note:
The size of the input 2D-array will be between 3 and 1000.
Every integer represented in the 2D-array will be between 1 and N, where N is the size of the input array.


Update (2017-09-26):
We have overhauled the problem description + test cases and specified clearly the graph is an undirected graph. For the directed graph follow up please see Redundant Connection II). We apologize for any inconvenience caused. 
*/
// Comment: Not so hard. The key point is if two nodes already exist, try to visit them to see if they are connect.
// If so, that edge (the first instance to form a cycle) is the answer.
public class Solution {
    Dictionary<int, List<int>> map;
    HashSet<int> visited;
    // Memoization is optional for this test??
    Dictionary<int, bool> mapans;
    bool IsCycle(int s, int t)
    {
        if(s==t)
            return true;
        if (visited.Contains(s))
            return false;     
        // Memoization is optional for this test??
        //if (mapans.ContainsKey(s))
        //    return mapans[s];
        
        visited.Add(s);           
        bool ans = false;
        foreach(var next in map[s]) {
            ans |= IsCycle(next, t);
        }
        // Memoization is optional for this test??
        //mapans[s] = ans;
        visited.Remove(s);
        
        return ans;
    }
    
    public int[] FindRedundantConnection(int[,] edges) {
        visited = new HashSet<int>();
        mapans = new Dictionary<int, bool>();
        map = new Dictionary<int, List<int>>();
        for(int i=0; i<edges.GetLength(0); i++) {
            int src = edges[i,0];
            int dst = edges[i,1];
            if (map.ContainsKey(src) && map.ContainsKey(dst)) {
                //visited.Clear();
                // Memoization is optional for this test??
                //mapans.Clear();
                if (IsCycle(src, dst))
                    return new int[]{src, dst};
            }
            if (!map.ContainsKey(src))
                map[src] = new List<int>();
            if (!map.ContainsKey(dst))
                map[dst] = new List<int>();
            map[src].Add(dst);
            map[dst].Add(src);
        }
        
        return new int[0];
    }
}