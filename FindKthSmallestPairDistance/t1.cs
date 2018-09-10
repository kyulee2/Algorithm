/*
Given an integer array, return the k-th smallest distance among all the pairs. The distance of a pair (A, B) is defined as the absolute difference between A and B.

Example 1:
Input:
nums = [1,3,1]
k = 1
Output: 0 
Explanation:
Here are all the pairs:
(1,3) -> 2
(1,1) -> 0
(3,1) -> 2
Then the 1st smallest distance pair is (1,1), and its distance is 0.
Note:
2 <= len(nums) <= 10000.
0 <= nums[i] < 1000000.
1 <= k <= len(nums) * (len(nums) - 1) / 2.
*/
// Comment: Hard. Sort array O(nlogn).
// Can use heap initialized with i,i+1 adjacent elements.
// While poping out, add back i, y+i.
// This is TLE. The following is different approach with window + binary search.

public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        Array.Sort(nums); // O(nlogn)
        int len = nums.Length;
        
        int lo = 0;
        int hi = nums[len-1]-nums[0];
        while(lo<hi) { // O(logW) where W is hi-lo
            int mid = (lo+hi) / 2;
            int left = 0; 
            int count = 0; // count for dist <= mid
            // O(n) two pointers left, right
            for(int right = 0; right<len; right++) {
                while(nums[right]-nums[left]>mid) left++;
                count += right - left;
            }
            if (count >= k)
                hi = mid;
            else lo = mid + 1;
        }
        return lo;
    }
}
