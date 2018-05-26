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
class Solution {
    void Rec(int start, int i)
    {
        if (i == len) {
            // when meet ending, restore it at start location
            n[start] = len;
            return;
        }
        
        int iNext = n[i];
        // Need to check bail-out the one already in place
        // otherwise, foreaver recursion
        if (iNext == i) return;
        n[i] = i;
        Rec(start, iNext);
    }
    
    int len;
    int[] n;
    public int MissingNumber(int[] nums) {
        len = nums.Length;
        n = nums;
        for(int i=0; i<len; i++) {
            if (i == n[i]) continue;
            Rec(i, n[i]);    
        }
        for(int i=0; i<len; i++)
            if (n[i]==len)
                return i;
        return len; // the last element when everything is in place
    }
}

