/*
Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

Note: For the purpose of this problem, we define empty string as valid palindrome.

Example 1:

Input: "A man, a plan, a canal: Panama"
Output: true
Example 2:

Input: "race a car"
Output: false
*/
// Comment: Should be easy, but a bit tricky with invalid chars.
// Ensure using Char.ToLower(c).  Ensure l,r is intialized. Whe bailing out invalid char, ensure the index is within the range i<len or j>=0;
public class Solution {
    public bool IsPalindrome(string s) {
        int len = s.Length;
        if (len==0)
            return true;
        int i=0, j=len-1;
        char getToken(int k)
        {
            char c = s[k];
            if (c>='0' && c<='9')
                return c;
            if (c>='A' && c<='Z')
                return Char.ToLower(c);
            if (c>='a' && c<='z')
                return c;
            return '.';// invalid
        }
        
        while(i<j) {
            char l='.', r='.';
            while(i<len && (l=getToken(i))=='.')
                i++;
            while(j>=0 && (r=getToken(j))=='.')
                j--;
            if (i>=j) break;
            if (l != r)
                return false;
            i++;
            j--;
        }
        
        return true;
    }
}
