/*
You are given a list of non-negative integers, a1, a2, ..., an, and a target, S. Now you have 2 symbols + and -. For each integer, you should choose one from + and - as its new symbol.

Find out how many ways to assign symbols to make sum of integers equal to target S.

Example 1:
Input: nums is [1, 1, 1, 1, 1], S is 3. 
Output: 5
Explanation: 

-1+1+1+1+1 = 3
+1-1+1+1+1 = 3
+1+1-1+1+1 = 3
+1+1+1-1+1 = 3
+1+1+1+1-1 = 3

There are 5 ways to assign symbols to make the sum of nums be target 3.
Note:
The length of the given array is positive and will not exceed 20.
The sum of elements in the given array will not exceed 1000.
Your output answer is guaranteed to be fitted in a 32-bit integer.
*/
// Comment: Solved with Rec + cache. It should be doable with DP, though.
// The intput to cache is to row(index), current sum to count.
public class Solution {
    
    Dictionary<int, int>[] map; // S to cnt for each row
    int len;
    int[] n;
    
    int Rec(int i, int curr)
    {
        if (i==len) {
            if (curr==0)
                return 1;
            return 0;
        }
        // check cache
        if (map[i].ContainsKey(curr))
            return map[i][curr];
        
        // + or -
        int s1 = Rec(i+1, curr - n[i]);
        int s2 = Rec(i+1, curr + n[i]);
        int s = s1 + s2;
        map[i][curr] = s;
        return s;
    }
    
    public int FindTargetSumWays(int[] nums, int S) {
        len = nums.Length;
        // Init data
        n = nums;
        map = new Dictionary<int,int>[len];
        for(int i=0; i<len;i++)
            map[i] = new Dictionary<int, int>();
        
        return Rec(0, S);
    }
}

