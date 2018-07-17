/*
uppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. Write an algorithm to reconstruct the queue. 
Note:
The number of people is less than 1,100. 

Example 
Input:
[[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]

Output:
[[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]
*/
// Comment: Place smallest height with largest k person first. Greedy.
public class Solution {
    public int[,] ReconstructQueue(int[,] people) {
        int len = people.GetLength(0);
        var t = new int[len][];
        for(int i=0; i<len; i++)
            t[i] = new int[2]{people[i,0], people[i,1]};
        Array.Sort(t, (x,y)=>{
            if (x[0]!=y[0]) return x[0]-y[0];
            return y[1]-x[1];});
        
        var ans = new int[len, 2];
        // Spoiler: Init ans with -1 since height can be 0
        for(int i=0; i<len; i++)
            ans[i,0] = -1;
        
        foreach(var n in t) {
            int h = n[0];
            int k = n[1];
            // Find an empty slot on k'th empty slot
            int j = 0;
            int cnt = 0;
            for(; j<len; j++)
                if (ans[j,0] == -1) {
                    if (cnt++ == k)
                        break;
                }
            
            ans[j,0] = h;
            ans[j,1] = k;
        }
        
        return ans;
    }
}
