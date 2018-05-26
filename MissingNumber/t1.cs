/*
Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

Example 1:

Input: [3,0,1]
Output: 2
Example 2:

Input: [9,6,4,2,3,5,7,0,1]
Output: 8
Note:
Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?

*/

// Comment: The key point is to bookkeep start location for each iteration
// When the length (n) is found, should keep it at start index.
// Spoiler: when everything is already in place, the length/last element is the answer.
// See t2.cs which is slightly different, but may be easier to understand.
public class Solution {
    void Rec(int start, int i)
    {
        int iNext = n[i];
        if (i == iNext) return;
        // Even the start location is stored in place
        n[i] = i;
        
        if (iNext == len) {
            // when meet ending, restore it at start location
            n[start] = len;
            return;
        }
        
        Rec(start, iNext);
    }
    
    int len;
    int[] n;
    public int MissingNumber(int[] nums) {
        len = nums.Length;
        n = nums;
        for(int i=0; i<len; i++) {
            Rec(i, i);    
        }
        for(int i=0; i<len; i++)
            if (nums[i]==len)
                return i;
        return len; // the last element when everything is in place
    }
}
