/*
The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Given two integers x and y, calculate the Hamming distance.

Note:
0 ≤ x, y < 231.

Example:

Input: x = 1, y = 4

Output: 2

Explanation:
1   (0 0 0 1)
4   (0 1 0 0)
       ↑   ↑

The above arrows point to positions where the corresponding bits are different.
*/
// Comment: Exclusive or and count # of 1.
public class Solution {
    public int HammingDistance(int x, int y) {
        int c = x ^ y;
        int n= 0;
        while(c != 0) {
            n++;
            c = (c & (c-1));
        }
        return n;
    }
}


