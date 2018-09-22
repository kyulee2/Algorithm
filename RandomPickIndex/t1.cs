/*
Given an array of integers with possible duplicates, randomly output the index of a given target number. You can assume that the given target number must exist in the array.
Note:
The array size can be very large. Solution that uses too much extra space will not pass the judge.
Example:
int[] nums = new int[] {1,2,3,3,3};
Solution solution = new Solution(nums);

// pick(3) should return either index 2, 3, or 4 randomly. Each index should have equal probability of returning.
solution.pick(3);

// pick(1) should return 0. Since in the array only nums[0] is equal to 1.
solution.pick(1);
*/
// Comment: The below is O(1) space and O(n) solution using Reservoir Sampling
public class Solution {

    int[] n;
    Random r;
    public Solution(int[] nums) {
        n = nums;
        r = new Random();
    }
    
    public int Pick(int target) {
        int result = -1;
        int cnt = 0;
        for(int i=0; i<n.Length; i++) {
            if (n[i] != target)
                continue;

            // Reservoir Sampling: 
            // On repeated char in the stream (N)
            // pick such index with 1/N probability
            if (r.Next(++cnt) == 0)
                result = i;
        }
        
        return result;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */