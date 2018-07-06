/*
Given a sorted array consisting of only integers where every element appears twice except for one element which appears once. Find this single element that appears only once. 
Example 1:
Input: [1,1,2,3,3,4,4,8,8]
Output: 2

Example 2:
Input: [3,3,7,7,10,11,11]
Output: 10

Note: Your solution should run in O(log n) time and O(1) space. 
*/
// Comment: Both work below, but the second one is ugly even though it's intuitive.
// More concise one is the first one below. Try to find the first even idnex element
// which is not followed by odd index value.
public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        int len = nums.Length;
        int i =0, j = len-1;
        while(i<j) {
            int m = i + (j-i)/2;
            int Even=0, Odd = 0;
            // Find the first even index not same as the following odd index.
            if (m%2 == 0) {
                Even = nums[m];
                Odd = nums[m+1];
                if (Even == Odd)
                    i = m + 2;
                else
                    j = m;
            } else {
                Even = nums[m-1];
                Odd = nums[m];
                if (Even == Odd)
                    i = m + 1;
                else
                    j = m;                
            }
        }
        
        return nums[i];
    }
    
    /*
    public int SingleNonDuplicate(int[] nums) {
        int len = nums.Length;
        int i =0, j = len-1;
        while(i<j) {
            int m = i + (j-i)/2;
            if ((m-1>=i) && nums[m-1] < nums[m] && (m+1<=j) && nums[m] < nums[m+1])
                return nums[m];
            if (m-1==i && m+1==j)
                return nums[m-1] == nums[m] ? nums[m+1] : nums[m-1];
            
            if ((m-i) % 2 == 0) {
                if (nums[m] < nums[m+1])
                    j= m;
                else
                    i = m;
            } else { // odd
                if (nums[m] < nums[m+1])                
                    i= m+1;
                else
                    j= m-1;
            }
        }
        
        return i;
    }
    */
}
