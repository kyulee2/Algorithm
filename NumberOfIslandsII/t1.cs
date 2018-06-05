/*
A 2d grid map of m rows and n columns is initially filled with water. We may perform an addLand operation which turns the water at position (row, col) into a land. Given a list of positions to operate, count the number of islands after each addLand operation. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
Example:
Input: m = 3, n = 3, positions = [[0,0], [0,1], [1,2], [2,1]]
Output: [1,1,2,3]
Explanation:
Initially, the 2d grid grid is filled with water. (Assume 0 represents water and 1 represents land).
0 0 0
0 0 0
0 0 0
Operation #1: addLand(0, 0) turns the water at grid[0][0] into a land.
1 0 0
0 0 0   Number of islands = 1
0 0 0
Operation #2: addLand(0, 1) turns the water at grid[0][1] into a land.
1 1 0
0 0 0   Number of islands = 1
0 0 0
Operation #3: addLand(1, 2) turns the water at grid[1][2] into a land.
1 1 0
0 0 1   Number of islands = 2
0 0 0
Operation #4: addLand(2, 1) turns the water at grid[2][1] into a land.
1 1 0
0 0 1   Number of islands = 3
0 1 0
Follow up:
Can you do it in time complexity O(k log mn), where k is the length of the positions?
*/
// Comment: merge has a spoiler. Using BitArray instead of HashSet is 
// another consideration for easier merge
// Instead of islands, we could simple use cnt to track # of islands.
public class Solution {
    int ID;
    int Row;
    int Col;
    int[,] grid;
    HashSet<HashSet<int>> islands;
    Dictionary<int, HashSet<int>> map;
    IList<int> ans;
    
    int getNewId() {
        return ++ID;
    }
    
    int getId(int i, int j)
    {
        if (i<0 || i>= Row || j<0 || j>= Col)
            return 0;
        return grid[i,j];
    }
    List<int> getNeighbors(int i, int j)
    {
        HashSet<int> s = new HashSet<int>();
        int n = 0;
        if ((n = getId(i-1,j)) != 0)
            s.Add(n);
        if ((n = getId(i+1,j)) != 0)
            s.Add(n);
        if ((n = getId(i,j-1)) != 0)
            s.Add(n);
        if ((n = getId(i,j+1)) != 0)
            s.Add(n);
        return s.ToList();
    }
    
    // merge set of i2 into set of i1
    void mergeIslands(int i1, int i2)
    {
        if (i1==i2) return;
        HashSet<int> s1 = map[i1];
        HashSet<int> s2 = map[i2];
        if (s1 == s2) return;

        // We could pick smaller to larger
        // merge set2 into set1
        foreach(var i in s2) {
            s1.Add(i);
            // Spoiler: update map in all elements
            map[i] = s1;
        }
        islands.Remove(s2);
    }
    
    void publishResult()
    {
        ans.Add(islands.Count);
    }
    
    void AddLands(int i, int j)
    {
        if (grid[i,j]!=0) {
            // no change
            publishResult();
            return;
        }
        
        var ns = getNeighbors(i, j);
        switch(ns.Count) {
            case 0: // create new island
                {
                    int id = getNewId();
                    HashSet<int> s = new HashSet<int>();
                    s.Add(id);
                    map[id] = s;
                    islands.Add(s);
                    grid[i,j] = id;
                    break;
                }
            case 1: // add to the exisintg island
                {
                    int id = ns[0];
                    grid[i,j] = id;
                    break;
                }
            default:
                {
                    int id = ns[0];
                    for(int k=1; k<ns.Count; k++)
                        mergeIslands(id, ns[k]);
                    grid[i,j] = id;
                    break;                    
                }
        }
        
        publishResult();
    }
    
    public IList<int> NumIslands2(int m, int n, int[,] positions) {
        // Initialize data
        Row = m;
        Col = n;
        grid = new int[m,n];
        islands = new HashSet<HashSet<int>>();
        map = new Dictionary<int, HashSet<int>>();
        ID = 0;
        ans = new List<int>();
        
        // main loop: add lands
        for(int i=0; i< positions.GetLength(0); i++)
            AddLands(positions[i,0], positions[i,1]);
        
        return ans;
    }
}
