/*
Given an integer array with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target.

Example:

nums = [1, 2, 3]
target = 4

The possible combination ways are:
(1, 1, 1, 1)
(1, 1, 2)
(1, 2, 1)
(1, 3)
(2, 1, 1)
(2, 2)
(3, 1)

Note that different sequences are counted as different combinations.

Therefore the output is 7.
Follow up:
What if negative numbers are allowed in the given array?
How does it change the problem?
What limitation we need to add to the question to allow negative numbers?
*/
// Comment: Interesting. This is a bit different than typicaly combination problem.
// Two ways: (1) top-down. Use a memoization, and recursion to search target - num[i]
// (2) bottom-up.
public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        // this works for positive numbers only
        var map = new Dictionary<int, int>();
        int Rec(int t)
        {
            if (t==0)
                return 1; // base case
            if (map.ContainsKey(t))
                return map[t];
            int ans = 0;
            for(int i=0; i<nums.Length; i++) {
                var n = nums[i];
                if (n<=t)
                    ans += Rec(t - n);
            }
            map[t] = ans;
            return ans;
        }
        
        return Rec(target);
        
    }
}
// (2) O(n * t + nlogn) where n is # of nums and t is target value. O(t) space
class Solution {
    public int CombinationSum4(int[] nums, int target) {
        Array.Sort(nums);
        var sums = new int[target+1];
        for(int i=1; i<=target; i++)
            foreach(var n in nums) {
                if (n > i) continue;
                else if (n==i)
                    sums[i]++;
                else  // i >n
                    sums[i] += sums[i-n];
            }
            
        return sums[target];
        
    }
}

