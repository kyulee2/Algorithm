/*
Given an integer, write a function to determine if it is a power of three.
Example 1:
Input: 27
Output: true
Example 2:
Input: 0
Output: false
Example 3:
Input: 9
Output: true
Example 4:
Input: 45
Output: false
Follow up:
Could you do it without using any loop / recursion?
*/
// Comment: Cheat with max available number. It's questioning how to get such number without calculator.
// Other way is to check if log(n)/log(3) equals or close to an integer.
// 3^19 => max 3^n int = 1162261467
class Solution {
public:
    int max = pow(3, (int)(log(INT_MAX)/log(3)));
    bool isPowerOfThree(int n) {
        return n>0 && (max%n == 0);
        
    }
};
