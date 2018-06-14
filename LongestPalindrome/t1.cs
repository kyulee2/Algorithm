/*
Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

This is case sensitive, for example "Aa" is not considered a palindrome here.

Note:
Assume the length of given string will not exceed 1,010.

Example:

Input:
"abccccdd"

Output:
7

Explanation:
One longest palindrome that can be built is "dccaccd", whose length is 7.
*/
// Comment: Just do it using a map
public class Solution {
    public int LongestPalindrome(string s) {
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(var c in s)
            if (map.ContainsKey(c)) ++map[c];
            else map[c] = 1;
        bool hasOdd = false;
        int len = 0;
        foreach(var v in map.Values) {
            if (v%2==1) hasOdd = true;
            len += ((int)v/2 ) * 2; 
        }
        if (hasOdd) ++len;
        return len;
    }
}



