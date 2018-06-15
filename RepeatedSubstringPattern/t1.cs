/*
Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together. You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.
Example 1:
Input: "abab"

Output: True

Explanation: It's the substring "ab" twice.
Example 2:
Input: "aba"

Output: False
Example 3:
Input: "abcabcabcabc"

Output: True

Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)
*/
// Comment: Let s2 = s + s
// Remove both end character. Determine if we can find a match of s within such string.
public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        string s2 = s + s;
        string sd = s2.Substring(1, 2*s.Length-2);
        return sd.IndexOf(s) != -1;
    }
}

