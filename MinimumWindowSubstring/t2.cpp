/*
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
Note:

If there is no such window in S that covers all characters in T, return the empty string "".
If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
*/
// Comment: Use (1)queue or (2)two pointers, and map. Remove redundant head in queue.
// Allow negative count on map to identify redundancy
// Use a queue on the valid char only.
class Solution {
public:
    string minWindow(string s, string t) {
        int i=0;
        int slen = s.length();
        int tlen = t.length();
        map<char, int> m;
        queue<int> q;
        for(auto c : t)
            ++m[c];
        
        int minlen = INT_MAX;
        string ans;

        int cnt = 0;
        for(int j= 0;j<slen; j++) {
            char c = s[j];
            if (m.find(c)==m.end())
                continue;
            if (m[c]>0) // only when positive, add cnt
                cnt++;
            --m[c];
            q.push(j);
            // check not found
            if (cnt<tlen)
              continue;
            
            // search min instance
            while(q.size()>0 && m[s[(i=q.front())]] < 0) {
                m[s[i]]++;
                q.pop();
            }

            i = q.front();
            int dist = j - i + 1;
            
            if (dist<minlen) {
                minlen = dist;
                ans = s.substr(i, dist);
            }
        }
        
        return ans;
    }
};

// Use two pointers
class Solution {
public:
    string minWindow(string s, string t) {
        int i=0;
        int slen = s.length();
        int tlen = t.length();
        map<char, int> m;
        for(auto c : t)
            ++m[c];
        int mini, minj;
        int minlen = INT_MAX;

        int cnt = 0;
        for(int j= 0;j<slen; j++) {
            char c = s[j];
            if (m.find(c)==m.end())
                continue;
            if (m[c]>0) // only when positive, add cnt
                cnt++;
            --m[c];
            // check not found
            if (cnt<tlen)
              continue;
            
            // search min instance
            char d;
            while(i<j && (m.find(d=s[i])==m.end() || m[d]<0))  {
                if (m.find(d)!=m.end()) {
                    m[d]++;
                }
                i++;
            }

            if (j-i+1<minlen) {
                mini = i;
                minj = j;
                minlen = j-i+1;
            }
        }
        
        return minlen == INT_MAX ? "" : s.substr(mini,minlen);
    }
};
