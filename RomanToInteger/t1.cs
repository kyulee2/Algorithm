/*
Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.
Example 1:
Input: "III"
Output: 3
Example 2:
Input: "IV"
Output: 4
Example 3:
Input: "IX"
Output: 9
Example 4:
Input: "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.
Example 5:
Input: "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
*/
// Comment: Look ahead 1 char to match two letters first, CM/CD/XC/XL/IX/IV
public class Solution {
    char[] str;
    int len;
    int i;
    public int RomanToInt(string s) {
        // 900 CM, 400 CD, 90 XC, 40  XL, 9 IX, 4
        // restIV, I, V, X, L, C, D, M
        str = s.ToCharArray();
        len = s.Length;
        i = 0;
        int ans = 0;
        while(i<len) {
            // check two chars
            var c = s[i];
            if (i+1<len) {
                var d = s[i+1];
                if (c=='C' && d=='M') {
                    ans += 900;
                    i+= 2;
                    continue;
                } else if (c=='C' && d=='D') {
                    ans += 400;
                    i+= 2;
                    continue;
                } else if (c=='X' && d=='C') {
                    ans += 90;
                    i+= 2;
                    continue;
                } else if (c=='X' && d=='L') {
                    ans += 40;
                    i+=2;
                    continue;
                } else if (c=='I' && d=='X') {
                    ans += 9;
                    i+= 2;
                    continue;
                } else if (c=='I' && d=='V') {
                    ans += 4;
                    i+=2;
                    continue;
                }
            }
            switch(c) {
                case 'M': ans+= 1000; break;
                case 'D': ans+= 500; break;
                case 'C': ans+= 100; break;
                case 'L': ans+= 50; break;
                case 'X': ans+= 10; break;                    
                case 'V': ans+= 5; break;
                case 'I': ans+= 1; break;
            }
            i++;
        }
        return ans;
    }
}