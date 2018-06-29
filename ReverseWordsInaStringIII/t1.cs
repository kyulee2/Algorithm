/*
Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:
Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
Note: In the string, each word is separated by single space and there will not be any extra space in the string.

*/
// Comment: Easy. Not worth
public class Solution {
    public string ReverseWords(string s) {
        void Reverse(char[] n, int i, int j)
        {
            while(i<j) {
                char t = n[j];
                n[j] = n[i];
                n[i] = t;
                i++;j--;
            }
        }
        var str = s.ToCharArray();
        int start = 0;
        for(int i=0; i<str.Length; i++) {
            char c = str[i];
            if (c==' ') {
                Reverse(str, start, i-1);
                start = i + 1;
            }
        }
        Reverse(str, start, str.Length-1);
        
        return new String(str);
    }
}

