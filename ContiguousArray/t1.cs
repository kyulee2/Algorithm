/*
Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

Example 1:
Input: [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
Example 2:
Input: [0,1,0]
Output: 2
Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
Note: The length of the given binary array will not exceed 50,000.
*/
// Comment: This is quite interesting.
// Use prefix sum with map. The key point is to consider 0 value as -1.
// When searching currnet sum, effectively we're looking for the prior index at whose sum is same by cancelling out +1/-1.
// +1 -1 -1 +1 +1
// 0   1  2  3  4
// Sum = 1 at 0 and 4. When query the index for sum= 1 at 4 index, we could find 0 from the map which was recorded
// in the prior iteration at 0 index. So the max distance is 4 - 0 = 4 at such index.
// By sliding window, update such max value.
// O(n) time and space
public class Solution {
    public int FindMaxLength(int[] nums) {
        int len = nums.Length;
        int s = 0;
        var map = new Dictionary<int, int>(); // sum to index
        map[0] = -1;
        int ans = 0;
        for(int i=0; i<len; i++) {
            s += (nums[i] == 0 ? -1 : 1);
            if (map.ContainsKey(s)) {
                ans = Math.Max(ans, i - map[s]);
            } else
                map[s] = i;
        }
        
        return ans;
    }
}
