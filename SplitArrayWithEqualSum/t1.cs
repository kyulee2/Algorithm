/*
Given an array with n integers, you need to find if there are triplets (i, j, k) which satisfies following conditions: 
0 < i, i + 1 < j, j + 1 < k < n - 1 
Sum of subarrays (0, i - 1), (i + 1, j - 1), (j + 1, k - 1) and (k + 1, n - 1) should be equal. 
where we define that subarray (L, R) represents a slice of the original array starting from the element indexed L to the element indexed R. 

Example:
Input: [1,2,1,2,1,2,1]
Output: True
Explanation:
i = 1, j = 3, k = 5. 
sum(0, i - 1) = sum(0, 0) = 1
sum(i + 1, j - 1) = sum(2, 2) = 1
sum(j + 1, k - 1) = sum(4, 4) = 1
sum(k + 1, n - 1) = sum(6, 6) = 1

Note: 
1 <= n <= 2000. 
Elements in the given array will be in range [-1,000,000, 1,000,000]. 
*/
// Comment: Appears a bit tricky since the split point is not included as sum.
// The key idea is to split half at any point, and to split the first half to record all sum that splits the first half, and then check the second half can be splitted with any sum reocrded above.
// complexity O(n^2). O(n) space overhead
public class Solution {
    public bool SplitArray(int[] nums) {
        int len = nums.Length;
        int[] s = new int[len];
        int sum(int i, int j)
        {
            if (i==0) return s[j];
            return s[j] - s[i-1];
        }
        
        HashSet<int> set;
        bool CanSplit(int i, int j, bool IsSecond)
        {
            for(int k=i+1; k<=j-1; k++) {
                if (sum(i,k-1) == sum(k+1,j)) {
                    if (!IsSecond)
                        set.Add(sum(i,k-1));
                    else if (set.Contains(sum(i,k-1)))
                        return true;
                }   
            }
            return false;
        }
        

        int t = 0;
        for(int i=0; i<len; i++) {
            t+= nums[i];
            s[i] = t;
        }
            
        // main loop
        if (len<7) return false;
        for(int i=3; i<len-3; i++) {
            set = new HashSet<int>();
            // Record all sum that splits the first half
            CanSplit(0,i-1, false);
            // Check if the second half also can be splitted with any sum reocrded above.
            if (CanSplit(i+1,len-1, true))
                return true;
        }

        return false;
    }
}