/*

Given an array of integers, find out whether there are two distinct indices i and j in the array such that the absolute difference between nums[i] and nums[j] is at most t and the absolute difference between i and j is at most k.

Example 1:

Input: nums = [1,2,3,1], k = 3, t = 0
Output: true
Example 2:

Input: nums = [1,0,1,1], k = 1, t = 2
Output: true
Example 3:

Input: nums = [1,5,9,1,5,9], k = 2, t = 3
Output: false
*/
// Comment: There is no TreeSet (balanced BST) in C#.
// It's hard to maintain a sorted order while querying a neight value without it.
// Check upper/lower value (closet value) to see if their difference is less than t.
// O(n log (min n, k)) time and O(log (min n,k)) space
class Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        TreeSet<Integer> s = new TreeSet<Integer>();
        for(int i=0; i<nums.length; i++) {
            int n = nums[i];
            // check near-by number to see if it's close
            Integer upper = s.ceiling(n);
            if (upper != null && upper<=t+n) // spoiler: upper-n<=t might overflow
                return true;
            Integer lower = s.floor(n);
            if (lower != null && n<=t+lower) // spoilwer: n-lower<=t might overflow
                return true;
            s.add(n);
            if (s.size() > k) // maintain k elements/window
                s.remove(nums[i-k]); 
        }
        return false;
    }
}
