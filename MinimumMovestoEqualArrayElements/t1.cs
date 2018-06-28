/*
Given a non-empty integer array of size n, find the minimum number of moves required to make all array elements equal, where a move is incrementing n - 1 elements by 1.

Example:

Input:
[1,2,3]

Output:
3

Explanation:
Only three moves are needed (remember each move increments two elements):

[1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
*/
// Comment: Take time to understand the operation. This is a math problem.
// To reach the maximum value from the min value, how much we should climb. Once it's reached, 
// we also have the same problem with n-1 elements.
public class Solution {
    public int MinMoves(int[] nums) {
        if (nums.Length == 1) return 0;
        Array.Sort(nums);
        int ans = 0;
        int start = nums[0];
        for(int i=1; i<nums.Length; i++)
            ans += (nums[i] - start);
        return ans;
    }
}
