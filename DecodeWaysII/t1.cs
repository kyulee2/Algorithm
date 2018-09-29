/*
A message containing letters from A-Z is being encoded to numbers using the following mapping way: 
'A' -> 1
'B' -> 2
...
'Z' -> 26
Beyond that, now the encoded string can also contain the character '*', which can be treated as one of the numbers from 1 to 9. 
Given the encoded message containing digits and the character '*', return the total number of ways to decode it. 
Also, since the answer may be very large, you should return the output mod 109 + 7. 
Example 1:
Input: "*"
Output: 9
Explanation: The encoded message can be decoded to the string: "A", "B", "C", "D", "E", "F", "G", "H", "I".

Example 2:
Input: "1*"
Output: 9 + 9 = 18

Note:
The length of the input string will fit in range [1, 105].
The input string will only contain the character '*' and digits '0' - '9'.
*/
// Comment: A bit tricky. When input is '0', the result is 0. And also note '*' ranges 1 to 9 not including 0.
// The special care needs to be made on '10' or '20' where we can't encode with the last digit '0'.
// Use long instead of int to avoid overflow.
public class Solution {
    public int NumDecodings(string s) {
        int len = s.Length;
        if (len==0) return 0;
        // spoiler:
        if (s[0]=='0')
            return 0;
        
        long[] d = new long[len+1];
        d[0] = 1;
        if (s[0]=='*')
            d[1] = 9;
        else d[1] = 1;
        for(int i=1; i<len ;i++) {
            var c = s[i];
            var p = s[i-1];
            if (p=='2') {
                if (c=='0')
                    d[i+1] = d[i-1];
                else if (c>='1' && c<='6')
                    d[i+1] = d[i-1] + d[i];
                else if (c=='*')
                    d[i+1] = d[i-1] * 6+ d[i] * 9;
                else
                    d[i+1] = d[i];
            } else if (p=='1') {
                if (c=='*')
                    d[i+1] = d[i-1] * 9 + d[i]*9;
                else if (c=='0')
                    d[i+1] = d[i-1];
                else d[i+1] = d[i-1] + d[i];
            } else if (p=='*') {
                if (c=='*') { //
                    d[i+1] = d[i-1]* 15 + d[i]*9;
                } else {
                    if (c=='0')
                        d[i+1] = d[i-1] * 2 ;
                    else if (c>='1' && c<='6')
                        d[i+1] = d[i-1] * 2 + d[i];
                    else // 7,8,9
                        d[i+1] = d[i-1] * 1 + d[i];
                }
                
            } else { 
                if (c=='*')
                    d[i+1] = d[i] * 9;
                else if(c!='0') // p 3~9
                    d[i+1] = d[i];
            }
            d[i+1] = d[i+1]% 1000000007;
        }
        
        return (int)d[len];
    }
}