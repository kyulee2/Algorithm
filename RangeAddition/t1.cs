/*
Assume you have an array of length n initialized with all 0's and are given k update operations.
Each operation is represented as a triplet: [startIndex, endIndex, inc] which increments each element of subarray A[startIndex ... endIndex] (startIndex and endIndex inclusive) with inc.
Return the modified array after all k operations were executed.
Example: 
Given:

    length = 5,
    updates = [
        [1,  3,  2],
        [2,  4,  3],
        [0,  2, -2]
    ]

Output:

    [-2, 0, 3, 5, 3]

Explanation: 
Initial state:
[ 0, 0, 0, 0, 0 ]

After applying operation [1, 3, 2]:
[ 0, 2, 2, 2, 0 ]

After applying operation [2, 4, 3]:
[ 0, 2, 5, 5, 3 ]

After applying operation [0, 2, -2]:
[-2, 0, 3, 5, 3 ]
*/
// Comment: Use the map for start/end position +delta/-delta respectively.
// Check at each index and update the sum of delta, if any.
// O(n)  not O(k*n) where k is # of operations.
public class Solution {
    public int[] GetModifiedArray(int length, int[,] updates) {
        int len = updates.GetLength(0);
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        for(int i=0; i<len; i++) {
            int s= updates[i,0];
            int e = updates[i,1];
            int d = updates[i,2];
            if (!map.ContainsKey(s)) map[s] = new List<int>();
            if (!map.ContainsKey(e+1)) map[e+1] = new List<int>();
            map[s].Add(d);
            map[e+1].Add(-d);
        }
        
        int[] ans = new int[length];
        int delta = 0;
        for(int i=0; i<length; i++) {
            if (map.ContainsKey(i)) {
                foreach(var d in map[i])
                    delta += d;
            }
            ans[i] = delta;
        }
        return ans;
    }
}