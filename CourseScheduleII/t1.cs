/*
There are a total of n courses you have to take, labeled from 0 to n-1.
Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
There may be multiple correct orders, you just need to return one of them. If it is impossible to finish all courses, return an empty array.
Example 1:
Input: 2, [[1,0]] 
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished   
             course 0. So the correct course order is [0,1] .
Example 2:
Input: 4, [[1,0],[2,0],[3,1],[3,2]]
Output: [0,1,2,3] or [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both     
             courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0. 
             So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3] .
Note:
The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.
You may assume that there are no duplicate edges in the input prerequisites.
*/
// Comment: Use topological sort
public class Solution {
    public int[] FindOrder(int numCourses, int[,] prerequisites) {
        var map = new Dictionary<int, List<int>>();
        var state = new Dictionary<int, int>(); // 0 white, 1 gray, 2 black
        var lans = new List<int>();

        // init data
        for(int i=0; i<numCourses; i++) {
            map[i] = new List<int>();
            state[i] = 0;
        }
        for(int i=0; i<prerequisites.GetLength(0); i++)
            map[prerequisites[i,0]].Add(prerequisites[i,1]);

        bool Rec(int n) {
            if (!state.ContainsKey(n)) return true;
            if (state[n] == 1) return false;
            state[n] = 1;

            foreach(var next in map[n]) {
                if (!Rec(next))
                    return false;
            }

            state.Remove(n);
            lans.Add(n);
            return true;
        }

        // Main loop starting from node with no incoming edge
        while(state.Count != 0) {
            foreach(var k in state.Keys) {
                if (!(Rec(k)))
                    return new int[0];
                break;
            }
        }

        return lans.ToArray();
    }
}
