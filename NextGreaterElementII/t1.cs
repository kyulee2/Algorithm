/*
Given a circular array (the next element of the last element is the first element of the array), print the Next Greater Number for every element. The Next Greater Number of a number x is the first greater number to its traversing-order next in the array, which means you could search circularly to find its next greater number. If it doesn't exist, output -1 for this number.

Example 1:
Input: [1,2,1]
Output: [2,-1,2]
Explanation: The first 1's next greater number is 2; 
The number 2 can't find next greater number; 
The second 1's next greater number needs to search circularly, which is also 2.
Note: The length of given array won't exceed 10000.
*/
// Comment: This is similar to daily temperatures and trapping water problem.
// Only difference is to start with max index to cover circular queue.
public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        // Init data
        int len = nums.Length;
        int[] ans = new int[len];
        // spoiler: null input
        if (len==0) return ans;
        int max = Int32.MinValue;
        int maxi = 0;
        int i=0;
        
        // find max
        for(; i<len; i++) {
            int n = nums[i];
            if (n>max) {max = n; maxi = i;}
        }
        
        // start with maxi + 1
        Stack<int[]> s = new Stack<int[]>();
        s.Push(new int[]{max, maxi});
        for(i = maxi+1; i<len; i++) {
            while(s.Count>0 && s.Peek()[0] < nums[i]) {
                int[] v = s.Pop();
                ans[v[1]] = nums[i];
            }
            s.Push(new int[]{nums[i], i});
        }
        
        // 0 - max indx
        for(i=0; i<= maxi; i++) {
            while(s.Count>0 && s.Peek()[0] < nums[i]) {
                int[] v = s.Pop();
                ans[v[1]] = nums[i];
            }
            if (i!=maxi) // maxi is already inserted before
                s.Push(new int[]{nums[i], i});
        }
        
        // all max entry with -1
        while(s.Count>0) {
            int[] v = s.Pop();
            ans[v[1]] = -1;
        }
        return ans;
    }
}

