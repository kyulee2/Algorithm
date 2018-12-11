/*
Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Example 1:

Input:
s = "aaabb", k = 3

Output:
3

The longest substring is "aaa", as 'a' is repeated 3 times.
Example 2:

Input:
s = "ababbc", k = 2

Output:
5

The longest substring is "ababb", as 'a' is repeated 2 times and 'b' is repeated 3 times.
*/
// Comment: A bit hard to think about two pointers.
// There are only 26 chars that can be repeated with k times.
// Slide window using two pointer i and j to see if unique char and repeated count is the same as h.
// O(n) space and time. Need to revisit
class Solution {
public:
    int longestSubstring(string s, int k) {
        int len = s.length();
        int ans = 0;
        for(int h=1; h<=26; h++) {
            vector<int> cnt(26, 0);
            int i =0, j=0, morek=0, unique= 0;
            while(j<len) {
                if (unique <= h) {
                    int idx = s[j]- 'a';
                    if (cnt[idx]==0)
                        unique++;
                    cnt[idx]++;
                    if (cnt[idx]==k)
                        morek++;
                    j++;
                } else {
                    int idx = s[i]-'a';
                    if (cnt[idx]==k)
                        morek--;
                    cnt[idx]--;
                    if (cnt[idx]==0)
                        unique--;
                    i++;
                }

                if (unique==h && morek==h)
                    ans = max(ans, j- i);
            }
        }
        
        return ans;
    }
};
