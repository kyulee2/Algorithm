/*
Maximum XOR of Two Numbers in an Array
Given a non-empty array of numbers, a0, a1, a2, ..  an-1, where 0<= ai < 231.
Find the maximum result of ai XOR aj, where 0 <=i, j < n.
Could you do this in O(n) runtime?
Example: 
Input: [3, 10, 5, 25, 2, 8]

Output: 28

Explanation: The maximum result is 5 ^ 25 = 28.
*/
// Comment: Key point is to n ^ m = max <=> n ^ max = m
// Using a set to track from the upper to lower bits, check if each bit can be set via xor.
public class Solution {
    public int FindMaximumXOR(int[] nums) {
        int ans = 0;
        int mask = 0;
        for(int i=31; i>=0; i--) {
            var set = new HashSet<int>();
            mask |= (1 << i);
            foreach(var n in nums)
                set.Add(n & mask);
            
            int tmp = ans | (1<<i);
            foreach(var s in set)
                if (set.Contains(s ^ tmp))
                    ans = tmp;
        }
        return ans;
    }
}

