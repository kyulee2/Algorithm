/*
Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.
Example 1:
Input: a = 1, b = 2
Output: 3
Example 2:
Input: a = -2, b = 3
Output: 1
*/
// Comment: Revisit. Use xor and and to get sum and carry until carry is 0.
public class Solution {
    public int GetSum(int a, int b) {
        int c = (a&b) << 1;
        int s = a ^ b;
        while(c!=0) {
            int next = s ^ c;
            c = (s & c) <<1;
            s = next;
        }
        return s;
    }
}