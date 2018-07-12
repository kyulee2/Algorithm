/*
Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

Example 1:

Input: pattern = "abba", str = "dog cat cat dog"
Output: true
Example 2:

Input:pattern = "abba", str = "dog cat cat fish"
Output: false
Example 3:

Input: pattern = "aaaa", str = "dog cat cat dog"
Output: false
Example 4:

Input: pattern = "abba", str = "dog dog dog dog"
Output: false
Notes:
You may assume pattern contains only lowercase letters, and str contains lowercase letters separated by a single space.

*/
// Comment: Use two maps and Split which takes char.
public class Solution {
    public bool WordPattern(string pattern, string str) {
        var word = str.Split(' ');
        if (pattern.Length != word.Length)
            return false;
        var map1 = new Dictionary<char, string>();
        var map2 = new Dictionary<string, char>();
        for(int i=0; i<word.Length; i++) {
            char c = pattern[i];
            string w = word[i];
            if (!map1.ContainsKey(c))
                map1[c] = w;
            if (!map2.ContainsKey(w))
                map2[w] = c;
            if (map1[c] != w || map2[w]!=c)
                return false;
        }
        return true;
    }
}
