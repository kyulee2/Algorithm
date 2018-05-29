/*
Given two strings s and t , write a function to determine if t is an anagram of s.
Example 1:
Input: s = "anagram", t = "nagaram"
Output: true
Example 2:
Input: s = "rat", t = "car"
Output: false
Note:
You may assume the string contains only lowercase alphabets.
Follow up:
What if the inputs contain unicode characters? How would you adapt your solution to such case?
*/
// Comment: We could use array for the given lowercase only.
// Don't forget checking length early bail-out
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(var c in s)
            if (map.ContainsKey(c))
                ++map[c];
            else map[c] = 1;
        
        foreach(var c in t)
            if (!map.ContainsKey(c))
                return false;
            else if (map[c] == 0)
                return false;
            else --map[c];
        return true;
    }
}

