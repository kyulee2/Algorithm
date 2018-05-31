/*
Given a string, find the length of the longest substring T that contains at most k distinct characters. 
For example, Given s = "eceba" and k = 2,
T is "ece" which its length is 3.
*/
// Comment: Be careful about typos
public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        int len = s.Length;
        Dictionary<char, int> map = new Dictionary<char, int>(); 
        // initialize map
        int i=0;
        for(; i<len; i++) {
            char c = s[i];
            if(map.ContainsKey(c)) {
                ++map[c];
                continue;
            }
            if (map.Count == k) break;
            map[c] = 1;
        }
        
        // main loop
        int max = i;
        int j= 0;
        for(; i<len; i++) {
            char c = s[i];
            if (map.ContainsKey(c)) {
                ++map[c];
                int l = i-j+1;
                if (l>max) max = l;
                continue;
            }
            map[c] = 1;
            while(j<len && map.Count >k) {
                char d = s[j++];
                --map[d];
                if (map[d] == 0) map.Remove(d);
            }
        }
        return max;
    }
}

