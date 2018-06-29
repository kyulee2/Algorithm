/*
Given two binary strings, return their sum (also a binary string).

The input strings are both non-empty and contains only characters 1 or 0.

Example 1:

Input: a = "11", b = "1"
Output: "100"
Example 2:

Input: a = "1010", b = "1011"
Output: "10101"
*/
// Comment: Easy, reverse. Careful operations.
public class Solution {
    public string AddBinary(string a, string b) {
        var aa = a.ToCharArray();
        var bb = b.ToCharArray();
        Array.Reverse(aa);
        Array.Reverse(bb);
        StringBuilder sb = new StringBuilder();
        int i=0;
        int c = 0;
        while(i<aa.Length || i<bb.Length) {
            int l =0, r= 0;
            if (i<aa.Length) {
                l = (int)(aa[i] -'0');
            }
            if (i<bb.Length) {
                r = (int)(bb[i] - '0');
            }
            int s = l + r + c;
            c  = s / 2;
            int rem = s % 2;
            sb.Append((char)('0' + rem));
            i++;
        }
        while(c>0) {
            int r = c %2;
            c = c/ 2;
            sb.Append((char)('0' + r));
        }
        
        // reverse result
        var ans = sb.ToString().ToCharArray();
        Array.Reverse(ans);
        return new string(ans);
    }
}

