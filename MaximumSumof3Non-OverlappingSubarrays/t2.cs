/*
In a given array nums of positive integers, find three non-overlapping subarrays with maximum sum.

Each subarray will be of size k, and we want to maximize the sum of all 3*k entries.

Return the result as a list of indices representing the starting position of each interval (0-indexed). If there are multiple answers, return the lexicographically smallest one.

Example:
Input: [1,2,1,2,6,7,5,1], 2
Output: [0, 3, 5]
Explanation: Subarrays [1, 2], [2, 6], [7, 5] correspond to the starting indices [0, 3, 5].
We could have also taken [2, 1], but an answer of [1, 3, 5] would be lexicographically larger.
Note:
nums.length will be between 1 and 20000.
nums[i] will be between 1 and 65535.
k will be between 1 and floor(nums.length / 3).
*/
// Comment: as opposed to t1.cs, this is optimial, which all pass
public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        int len = nums.Length;
        var sums = new int[len];
        int sum = 0;
        for(int i=0; i<len; i++) {
            sum += nums[i];
            sums[i] = sum;
        }
        // return sum i ~ <i+k
        int getSum(int i) {
            return i==0? sums[i+k-1] : sums[i+k-1] - sums[i-1];
        }
        // left max sum
        var left = new int[len,2];
        for(int i=0; i<=len-2*k; i++) {
            int s= getSum(i);
            if (i==0 || s > left[i-1,0]) {
                left[i,0] = s;
                left[i,1] = i;
            } else {
                left[i,0] = left[i-1,0];
                left[i,1] = left[i-1,1];
            }
        }
        
        var right = new int[len,2];
        for(int i=len-k; i>=2*k; i--) {
            int s= getSum(i);
            if (i==len-k || s > right[i+1,0]) {
                right[i,0] = s;
                right[i,1] = i;
            } else {
                right[i,0] = right[i+1,0];
                right[i,1] = right[i+1,1];
            }
        }
        
        // main loop
        var ans = new int[]{-1,-1,-1};
        int max = 0;
        for(int i=k; i<=len-2*k; i++) {
            int s = left[i-k,0] + getSum(i) + right[i+k,0];
            if (s>max) {
                max = s;
                ans[0] = left[i-k,1];
                ans[1] = i;
                ans[2] = right[i+k,1];
            }
        }
        return ans;
    }
}
