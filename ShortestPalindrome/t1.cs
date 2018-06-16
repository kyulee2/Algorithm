/*
Given a string s, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation.

Example 1:

Input: "aacecaaa"
Output: "aaacecaaa"
Example 2:

Input: "abcd"
Output: "dcbabcd"
*/ 
// Commnent: Hard tag, but seems not. But maybe a better one.
// The below is try to remove the end char, and to see if we can make palindrom from it.
// If so, prepend the removed char in the revese way to the original string
public class Solution {
    bool isPalindrome(int i, int j)
    {
        while(i<j) {
            if (str[i] != str[j])
                return false;
            i++; j--;
        }
        return true;
    }
    string str;
    public string ShortestPalindrome(string s) {
        str= s;
        int len = s.Length;
        int i= len - 1;
        for(; i>=0; i--) {
            if (isPalindrome(0, i))
                break;
        }
        string prefix = s.Substring(i+1);
        var p = prefix.ToCharArray();
        Array.Reverse(p);
        return new string(p) + s;
    }
}

