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
// Comment: The below fails due to TLE -- 33/37 passed even though the logically works.
// Be careful about <= condition for j when subtracting window's width.
// Other approach (from solution) is to bookkeep the best/max sum from either left, right side --
// see the below getMax1() is only right in this sense. We could do similar thing for left.
// Then max sum of sub array is left + middle + right where we iterate middle in the main loop only.
public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        int len = nums.Length;
        // init data
        var t = new int[len];
        int s = 0;
        for(int j=0; j<len; j++) {
            s+= nums[j];
            t[j] = s;
        }
        
        // Sum from i to i+k-1
        int getSum(int i) {
            return i==0 ? t[i+k-1] : t[i+k-1]-t[i-1];
        }
        
        var map1 = new Dictionary<int, int[]>();
        int[] getMax1(int i) // return maxSum, index1 starting from i to end
        {
            if (map1.ContainsKey(i))
                return map1[i];
            int ms = 0;
            int mj = 0;
            for(int j=i; j<=len-k; j++) {
                int ts = getSum(j);
                if (ts > ms) {
                    mj = j;
                    ms = ts;
                }
            }
            var ans = new int[]{ms, mj};
            map1[i] = ans;
            return ans;
        }
        
        
        var map2 = new Dictionary<int, int[]>();
        int[] getMax2(int i) // return maxSum, index1, index2
        {
            if (map2.ContainsKey(i))
                return map2[i];
            int ms = 0;
            int mj =0;
            int mk = 0;
            for(int j=i; j<=len - 2*k; j++) {
                var max1 = getMax1(j+k);
                int sum = getSum(j) + max1[0];
                if (sum>ms) {
                    ms = sum;
                    mj = j;
                    mk = max1[1];
                }
            }
            var ans = new int[]{ms, mj, mk};
            map2[i] = ans;
            return ans;
        }
        
        // getMax3
        int maxSum = 0;
        var max = new int[] {0,0,0};
        for(int i=0; i<=len-k*3; i++) {
            var max2 = getMax2(i+k);
            int sum = getSum(i) + max2[0];  
            //Console.WriteLine(" chk {0} {1} {2} {3} {4}", i, sum, max2[0], max2[1], max2[2]);
            if (sum > maxSum) {
                max = new int[]{i, max2[1], max2[2]};
                maxSum = sum;
            }
        }
        
        return max;
    }
}
