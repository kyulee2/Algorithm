/*
Given a string, determine if a permutation of the string could form a palindrome.

Example 1:

Input: "code"
Output: false
Example 2:

Input: "aab"
Output: true
Example 3:

Input: "carerac"
Output: true
*/
// Comment: Easy. Use char:int. Check even/odd case.
public class Solution {
    public bool CanPermutePalindrome(string s) {
        int len = s.Length;
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(var c in s)
            if (map.ContainsKey(c))
                ++map[c];
            else 
                map[c] = 1;
        
        // Count odd values
        int cnt = 0;
        foreach(var v in map.Values)
            if (v%2 != 0) cnt++;

        if (len%2 == 0) {
            return cnt == 0;
        }
        // odd case
        return cnt == 1;
    }
}

