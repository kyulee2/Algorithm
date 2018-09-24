/*
Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.

Example 1:
Input: 5
Output: True
Explanation: 1 * 1 + 2 * 2 = 5
Example 2:
Input: 3
Output: False
*/
// Comment: Various ways. Either use two pointers or binary search.
// The blow just searches the interger using sqrt to see if the value is integer
public class Solution {
    public bool JudgeSquareSum(int c) {
        if (c==0) return true; // spoiler:
        for(int i=1; i<=Math.Sqrt(c); i++) {
            var b = Math.Sqrt(c - i*i);
            if ((int)b == b)
                return true;
        }
        return false;
    }
}
