/*
Given a string s , find the length of the longest substring t  that contains at most 2 distinct characters.
Example 1:
Input: "eceba"
Output: 3
Explanation: t is "ece" which its length is 3.
Example 2:
Input: "ccaabbb"
Output: 5
Explanation: t is "aabbb" which its length is 5.
*/
// Comment: Interesting. Similar to LongestSubstring with K distinct chars
// Use two pointers with map which contains only two distinct chars
class Solution {
public:
    int lengthOfLongestSubstringTwoDistinct(string s) {
        map<char, int> m;
        int len = s.length();
        int ans = 0;
        int i=0;
        for(int j=0; j<len; j++) {
            char c= s[j];
            ++m[c];
            // keep map size <=2 unique chars
            while(m.size()>2) {
                char d= s[i++];
                --m[d];
                if (m[d]==0) m.erase(d);
            }
            ans = max(ans, j-i+1);
        }
        return ans;
    }
};