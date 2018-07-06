/*
Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array. 
Formally the function should:
Return true if there exists i, j, k 
such that a[i] < a[j] < a[k] given 0<= i<j<k<=n-1
else return false

Your algorithm should run in O(n) time complexity and O(1) space complexity. 
Examples:
Given [1, 2, 3, 4, 5],
return true. 
Given [5, 4, 3, 2, 1],
return false. 

// Comment: This is simple but quite interesting
// Try to look two increasing pattern prev < curr.
// Only when we meet another pattern where prev < prev2 || curr < curr2
// We could choose prev, prev2, curr or prev, cur, curr2 in order.
// Initialize min(bottom) and max(up) with max value.
public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int len = nums.Length;
        int max = Int32.MaxValue;
        int min = Int32.MaxValue;
        for(int i=1; i<len; i++) {
            int prev = nums[i-1];
            int curr = nums[i];
            if (prev<curr) {
                if (curr>max)
                    return true;
                if (prev>min)
                    return true;
                max = curr;
                min = prev;
            }
        }

        return false;
    }
}
