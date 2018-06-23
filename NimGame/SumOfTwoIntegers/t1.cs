/*
Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

Example:
Given a = 1 and b = 2, return 3.
*/
// Comment: Use xor and and/shift for carry
public class Solution {
    public int GetSum(int a, int b) {
        int s = a ^ b;
        int c = (a&b) << 1;
        while(c!=0) {
            int next = s ^ c;
            c = (s & c) <<1;
            s = next;
        }
        return s;
    }
}
