/*

Given a non-empty array of non-negative integers nums, the degree of this array is defined as the maximum frequency of any one of its elements.

Your task is to find the smallest possible length of a (contiguous) subarray of nums, that has the same degree as nums.

Example 1:
Input: [1, 2, 2, 3, 1]
Output: 2
Explanation: 
The input array has a degree of 2 because both elements 1 and 2 appear twice.
Of the subarrays that have the same degree:
[1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
The shortest length is 2. So return 2.
Example 2:
Input: [1,2,2,3,1,4,2]
Output: 6
Note:

nums.length will be between 1 and 50,000.
nums[i] will be an integer between 0 and 49,999.
*/
// Comment: Straightforward. Think about map from num to {cnt, start, index}
public class Solution {
    public int FindShortestSubArray(int[] nums) {
        int maxCnt = 1;
        int maxLen = 1;
        int len = nums.Length;
        if (len==0)
            return 0;
        var map = new Dictionary<int, int[]>(); // num : [cnt, start, end]
        for(int i=0; i<len; i++) {
            int n = nums[i];
            if (!map.ContainsKey(n)) {
                map[n] = new int[]{1, i, i};
                continue;
            }
            var v = map[n];
            v[0]++;
            v[2] = i;
            int dist = v[2] - v[1] + 1;
            if (v[0] > maxCnt) {
                maxCnt = v[0];
                maxLen = dist;
            } else if (v[0] == maxCnt) {
                maxLen = Math.Min(maxLen, dist);
            }            
        }
        
        return maxLen;
    }
}

