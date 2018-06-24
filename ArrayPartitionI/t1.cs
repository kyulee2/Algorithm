/*
Given an array of 2n integers, your task is to group these integers into n pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.

Example 1:
Input: [1,4,3,2]

Output: 4
Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3, 4).
Note:
n is a positive integer, which is in the range of [1, 10000].
All the integers in the array will be in the range of [-10000, 10000].
*/
// Comment: With O(nlog(n), should be easy as t2.cs. The below is O(n).
public class Solution {
    public int ArrayPairSum(int[] nums) {
        int[] map = new int[20001];
        int min = 10000;
        int max = -10000;
        foreach(var v in nums) {
            if (v<min) min= v;
            if (v>max) max = v;
            
            int i = v + 10000;
            ++map[i];
        }
        
        bool status = false;
        int sum = 0;
        for(int v=min; v<=max; ) {
            int i = v + 10000;
            if (map[i]== 0) {
                v++; continue;
            }
            
            --map[i];
            if (!status)
                sum +=v;
            status = !status;
        }

        return sum;
    }
}

