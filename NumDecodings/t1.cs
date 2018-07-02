/*
A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Given a non-empty string containing only digits, determine the total number of ways to decode it.

Example 1:

Input: "12"
Output: 2
Explanation: It could be decoded as "AB" (1 2) or "L" (12).
Example 2:

Input: "226"
Output: 3
Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

*/
// Comment: Corner case with '0'.
public class Solution {
    public int NumDecodings(string s) {
        int len = s.Length;
        if (len==0) return 0;
        
        var d = new int[len+1];
        d[0] = 1;
        d[1] = s[0] == '0' ? 0 : 1;
        for(int i=1; i<len; i++) {
            char c = s[i];
            char p = s[i-1];
            // Check one digit
            int sum = c=='0' ? 0 : d[i];
            
            // Check two digits
            if (p=='1' || (p=='2' && (c>='0' && c<='6')))
                sum += d[i-1];
            d[i+1] = sum;
        }
        
        return d[len];
    }
}

