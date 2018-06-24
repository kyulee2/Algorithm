/*
Given a non negative integer number num. For every numbers i in the range 0 = i = num calculate the number of 1's in their binary representation and return them as an array.

Example:
For num = 5 you should return [0,1,1,2,1,2].

Follow up:

It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
Space complexity should be O(n).
Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
Credits:
Special thanks to @ syedee for adding this problem and creating all test cases.
*/
// Comment: Striaghtfowrad but a bit interesting for O(n). Once 2^n found, the same bit pattern is repeated from 1st in addition to the top bit.
public class Solution {
    public int[] CountBits(int num) {
        int j = 1;
        int len = num;
        var t = new int[len+1];
        if (len==0) return t;
        t[1] = 1;
        if (len==1) return t;
        t[2] = 1;
        if (len==2) return t;
        
        // main loop
        for(int i = 3; i<=num; i++) {
            // check 2^n
            if ((i & (i-1)) == 0) {
                t[i] = 1;
                j = 1; // reset to 1st element
            } else {
                t[i] = 1 + t[j++];
            }
        }
        return t;
    }
}
