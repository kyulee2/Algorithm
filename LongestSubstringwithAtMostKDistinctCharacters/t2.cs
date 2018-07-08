/*
Given a string, find the length of the longest substring T that contains at most k distinct characters. 
For example, Given s = "eceba" and k = 2,
T is "ece" which its length is 3.
*/
// Comment: Use two pointers to track substring meeting condition
public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        int len = s.Length;
        if (len==0 || k<=0) return 0;
        int max = 1;
        var map = new Dictionary<char, int>();
        int j = 0;
        map[s[0]] = 1;
        for(int i=1; i<len; i++) {
            char c = s[i];
            if(!map.ContainsKey(c)) map[c] = 1;
            else ++map[c];    
            while(map.Count>k) {
                char d = s[j++];
                map[d]--;
                if (map[d]==0)
                    map.Remove(d);
            }
            max = Math.Max(max, i-j+1);
        }
        return max;
    }
}
