/*
Pick One

Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1. In other words, one of the first string's permutations is the substring of the second string. 
Example 1:
Input:s1 = "ab" s2 = "eidbaooo"
Output:True
Explanation: s2 contains one permutation of s1 ("ba").

Example 2:
Input:s1= "ab" s2 = "eidboaoo"
Output: False

Note:
The input strings only contain lower case letters.
The length of both given strings is in range [1, 10,000].
*/
// Comment: Similar to check anagram substring. In this case, a bit simpler since we only need to check instead of reporting the index.
// Use a map to count char.
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int s1len = s1.Length;
        if (s1len==0)
            return true;
        int s2len = s2.Length;
        if (s1len>s2len)
            return false;
        
        var map = new Dictionary<char, int>();
        // build map for s1 
        foreach(var c in s1)
            if (!map.ContainsKey(c))
                map[c] = 1;
            else map[c]++;

        // main loop starting from s1len
        for(int i= 0; i<s2len; i++) {
            if (i>=s1len) {
                // Remove i-silen char +1..
                var c = s2[i-s1len];
                if (!map.ContainsKey(c))
                    map[c] = 1;
                else {
                    map[c]++;
                    if (map[c] == 0)
                        map.Remove(c);
                }
            }
            
            var d= s2[i];
            if (!map.ContainsKey(d))
                map[d] = -1;
            else {
                map[d]--;
                if (map[d]==0)
                    map.Remove(d);
            }
            if (map.Count ==0)
                return true;
        }
        
        return false;
    }
}