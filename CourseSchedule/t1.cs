/*
There are a total of n courses you have to take, labeled from 0 to n-1.
Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
Example 1:
Input: 2, [[1,0]] 
Output: true
Explanation: There are a total of 2 courses to take. 
             To take course 1 you should have finished course 0. So it is possible.
Example 2:
Input: 2, [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
             To take course 1 you should have finished course 0, and to take course 0 you should
             also have finished course 1. So it is impossible.
Note:
The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.
You may assume that there are no duplicate edges in the input prerequisites.

*/
// Comment: Cycle detection using a topoligical sort

public class Solution {
    public bool CanFinish(int numCourses, int[,] prerequisites) {
        var map= new Dictionary<int, List<int>>();
        var smap = new Dictionary<int, int>();
        for(int i=0; i<numCourses; i++) {
            map[i] = new List<int>();
            smap[i] = 0; //0 unvisited, 1 gray, 2 final/black
        }
        for(int i=0; i<prerequisites.GetLength(0); i++)
            map[prerequisites[i,0]].Add(prerequisites[i,1]);
        
        bool Rec(int n) {
            if (!smap.ContainsKey(n)) return true;
            if (smap[n]==1) return false;
            smap[n] = 1;
            foreach(var next in map[n]) {
                if (!Rec(next))
                    return false;                    
            }
            smap.Remove(n); // In toplogical sort, turn it into black and put it to the list.
            return true;
        }
        
        while(smap.Count != 0) {
            foreach(var k in smap.Keys) {
                if (!Rec(k))
                    return false;
                break;
            }
        }
        
        return true;
        
    }
}
