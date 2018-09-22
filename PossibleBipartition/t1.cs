/*
Pick One

Given a set of N people (numbered 1, 2, ..., N), we would like to split everyone into two groups of any size.
Each person may dislike some other people, and they should not go into the same group. 
Formally, if dislikes[i] = [a, b], it means it is not allowed to put the people numbered a and b into the same group.
Return true if and only if it is possible to split everyone into two groups in this way.
 

Example 1:
Input: N = 4, dislikes = [[1,2],[1,3],[2,4]]
Output: true
Explanation: group1 [1,4], group2 [2,3]
Example 2:
Input: N = 3, dislikes = [[1,2],[1,3],[2,3]]
Output: false
Example 3:
Input: N = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
Output: false
 
Note:
1 <= N <= 2000
0 <= dislikes.length <= 10000
1 <= dislikes[i][j] <= N
dislikes[i][0] < dislikes[i][1]
There does not exist i != j for which dislikes[i] == dislikes[j].
*/
// Comment: It's two coloring problem. Need to build graph first to detect conflicts.
public class Solution {
    public bool PossibleBipartition(int N, int[][] dislikes) {
        var map = new HashSet<int>[N+1];
        int len = dislikes.Length;
        // spoiler:
        if (len==0)
            return true;
        
        // build undirected map/graph
        // spoiler: build node regardless
        for(int i=1; i<=N; i++)
            map[i] = new HashSet<int>();
        for(int i=0; i<len; i++) {
            var d= dislikes[i];
            int src = d[0], dst = d[1];
            map[src].Add(dst);
            map[dst].Add(src);
        }
        
        var status = new int[N+1];
        bool Rec(int n, int s)
        {
            if (status[n] != 0) {
                if (status[n] != s)    
                    return false;
                return true;
            }
            status[n] = s;
            foreach(var next in map[n])
                if (!Rec(next, s==1 ? 2 : 1))
                    return false;
            return true;
        }
        
        for(int i=1; i<= N; i++) {
            if (status[i] == 0) { // unvisited one only
                if (!Rec(i,1))
                    return false;
            }
        }
        
        return true;
    }
}