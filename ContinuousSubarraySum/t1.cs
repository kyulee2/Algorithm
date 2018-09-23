/*
Given a list of non-negative numbers and a target integer k, write a function to check if the array has a continuous subarray of size at least 2 that sums up to the multiple of k, that is, sums up to n*k where n is also an integer. 
Example 1:
Input: [23, 2, 4, 6, 7],  k=6
Output: True
Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.

Example 2:
Input: [23, 2, 6, 4, 7],  k=6
Output: True
Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.

Note:
The length of the array won't exceed 10,000.
You may assume the sum of all the numbers is in the range of a signed 32-bit integer.
*/
// Comment:         // If use prefix sum with O(n) size, it's O(n^2)
        // The below is use map. When prefix sum remainder by k is found,
        // the range from the previous to current is the multiple of k
        // sum1 (%k = r) - sum0(%k =r) = n * k
// There are spoilers when k = 0. Map should be initialized with 0, -1
// We could separate routine for such k value, though.
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        int len = nums.Length;
        // spoiler:
        if (len==0) return false;

        // If use prefix sum with O(n) size, it's O(n^2)
        // The below is use map. When prefix sum remainder by k is found,
        // the range from the previous to current is the multiple of k
        // sum1 (%k = r) - sum0(%k =r) = n * k
        var map = new Dictionary<int, int>(); // sum remainder, index
        // Spoiler: E.g, [0,0] k= 0 is true
        map[0] = -1; // 0 sum starts from -1
        
        int sum = 0;
        // main loop
        for(int i=0; i<len; i++) {
            sum += nums[i];
            int r = sum ;
            if (k!=0)
                r = sum % k;
            if (map.ContainsKey(r)) {
                // check the distance > 1
                int dist = i - map[r];
                if (dist>1)
                    return true;
            } else {
                map[r] = i;
            }
        }
        
        return false;
    }
}
