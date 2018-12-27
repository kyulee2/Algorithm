/*
You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.

Example 1:

Input:
  s = "barfoothefoobarman",
  words = ["foo","bar"]
Output: [0,9]
Explanation: Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.
The output order does not matter, returning [9,0] is fine too.
Example 2:

Input:
  s = "wordgoodgoodgoodbestword",
  words = ["word","good","best","word"]
Output: []

*/
// Comment: Rabin? Use hash sum to filter out string matches.
// Note string can starts with any pos (not necessarily multiple of wlen)
// Need to cache string (word) hash for each position with the given string length. Any prime number should work for base and modulo operation.
class Solution {
public:
    int wlen;
    int len;
    int hash(string& s, int i) {
        int h = 0;
        for(int j=i; j<i+len; j++) {
            h *= 26; h %= 157;
            h += s[j]; h%=157;
        }
        return h;
    }
    vector<int> findSubstring(string s, vector<string>& words) {
        wlen = words.size();
        if (wlen==0) return vector<int>();
        len = words[0].size();
        if (s.length() < wlen*len)
            return vector<int>();
        
        // init pattern
        int pat  = 0;
        for(auto w : words) {
            pat += hash(w, 0);
            pat %= 157;
        }
        // cache every word hash (length len)
        vector<int> ca(s.length(),0);
        int curr = hash(s,0);
        ca[0] = curr;
        // compute height base (26^n-1)
        int hb = 1;
        for(int i=0; i<len-1; i++)
            hb = (hb * 26 % 157);

        for(int i=0; i<s.length()-len; i++) {
            curr -= hb*s[i] %157; curr+= 157;
            curr *= 26; curr %= 157;
            curr += s[i+len]; curr %= 157;
            ca[i+1] = curr;
        }

        // word count
        map<string,int> st;
        for(auto w : words)
            st[w]++;
        
        vector<int> ans;
        for(int i=0; i<=s.size()-wlen*len; i++) {
            // get sum of has for the wlen string starting from i
            curr = 0;
            for(int j=i; j<i+wlen*len; j+=len)
                curr += ca[j];
            curr %= 157;
            if (curr!=pat) continue;
            
            // Check string count
            map<string, int> m;
            bool success = true;
            for(int j=i; j<i+wlen*len; j+=len) {
                 auto w = s.substr(j, len);
                 m[w]++;
            }
            // Ensure if the map is identical
            for(auto t : st)
                if (m[t.first] != t.second) {
                    success= false;
                    break;
                }
            if (success)
                ans.push_back(i);
        }
        
        return ans;
    }
};
