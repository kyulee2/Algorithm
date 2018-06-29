/*
Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.

Example 1:
Input: "aba"
Output: True
Example 2:
Input: "abca"
Output: True
Explanation: You could delete the character 'c'.
Note:
The string will only contain lowercase characters a-z. The maximum length of the string is 50000.
*/
// Comment: Should be straighforward. Using recursion to handle either of deletion.
public class Solution {
    public bool ValidPalindrome(string s) {
        bool Rec(int i, int j, bool delete) {
            if (i>=j)
                return true;
            if (s[i] == s[j])
                return Rec(i+1, j-1, delete);
            if (delete)
                return false;
            return Rec(i+1, j, true) || Rec(i, j-1, true);
        }
        
        return Rec(0, s.Length-1, false);
    }
}

