/*
Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1. 
Examples: 
s = "leetcode"
return 0.

s = "loveleetcode",
return 2.

Note: You may assume the string contain only lowercase letters. 
*/
public class Solution {
    public int FirstUniqChar(string s) {
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(var c in s)
            if (!map.ContainsKey(c)) map[c] = 1;
            else  map[c] = -1;

        for(int i=0; i<s.Length; i++)
             if (map[s[i]] == 1) return i;

        return -1;
    }
}
