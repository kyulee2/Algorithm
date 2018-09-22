/*
Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.
The order of output does not matter.
Example 1: 
Input:
s: "cbaebabacd" p: "abc"

Output:
[0, 6]

Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".

Example 2: 
Input:
s: "abab" p: "ab"

Output:
[0, 1, 2]

Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".
*/
// Comment: Straightforward. O(n) time/space. anagram problem think about map.
public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var ans = new List<int>();
        int slen = s.Length;
        int plen = p.Length;
        var map = new Dictionary<char, int>();
        if (slen==0 || slen < plen)
            return ans;
        // init map
        foreach(var pc in p)
            if (!map.ContainsKey(pc))
                map[pc] = 1;
            else map[pc]++;
        
        // set first p window
        for(int i=0; i<plen; i++) {
            var sc = s[i];
            if (map.ContainsKey(sc)) {
                map[sc]--;
                if (map[sc]==0)
                    map.Remove(sc);
            } else
                map[sc] = -1;
            
        }
        
        if (map.Count == 0)
            ans.Add(0);
        for(int i = plen; i<slen; i++) {
            var prev = s[i-plen];
            var curr = s[i];
            // Remove prve via +
            if (map.ContainsKey(prev)) {
                ++map[prev];
                if (map[prev] ==0)
                    map.Remove(prev);
            } else map[prev] = 1;
            // Add curr via -
            if (map.ContainsKey(curr)) {
                --map[curr];
                if (map[curr] ==0)
                    map.Remove(curr);
            } else map[curr] = -1;
            
            if (map.Count == 0)
                ans.Add(i-plen+1);
        }
        
        return ans;
    }
}