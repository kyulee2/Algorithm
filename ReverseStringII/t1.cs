/*
Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start of the string. If there are less than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and left the other as original. 

Example:
Input: s = "abcdefg", k = 2
Output: "bacdfeg"

Restrictions: 
The string consists of lower English letters only.
Length of the given string and k will in the range [1, 10000]
*/
// Comment: Easy, but be careful about indexing operation.
public class Solution {
    public string ReverseStr(string s, int k) {
        int len = s.Length;
        char[] str = s.ToCharArray();
        
        void Reverse(int i, int j)
        {
            while(i<j){
                char t = str[i];
                str[i] = str[j];
                str[j] = t;
                i++;j--;
            }
        }        

        int x = 0;
        while(x < len) {
            int cnt = len - x;
            if (cnt >= 2 * k) {
                Reverse(x, x + k - 1);
                x += 2 * k;
                continue;
            }
            if (cnt <= k) {
                Reverse(x, x + cnt - 1);
                break;
            }
            Reverse(x, x + k - 1);
            break;
        }
        
        return new String(str);
    }
}

