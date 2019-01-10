/*

s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
Output:
[
  "cats and dog",
  "cat sand dog"
]
Example 2:
Input:
s = "pineapplepenapple"
wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
Output:
[
  "pine apple pen apple",
  "pineapple pen apple",
  "pine applepen apple"
]
Explanation: Note that you are allowed to reuse a dictionary word.
Example 3:
Input:
s = "catsandog"
wordDict = ["cats", "dog", "sand", "and", "cat"]
Output:
[]
*/
// Comment: Naive one is TLE below. Use backtracking instead
// Backtracking
class Solution {
public:
    vector<string> ans;
    int len;
    map<int, vector<int>> m; // i+1 (ending idx + 1) to list of j(starting index = the prior ending index + 1)
    string str;
    
    vector<string> wordBreak(string s, vector<string>& wordDict) {
        str = s;
        len = s.size();
        m[0].push_back(-1); // ensure the first char at -1 always hits
        
        set<string> dict;
        for(auto w : wordDict) dict.insert(w);
        for(int i=0; i<len; i++) {
            for(int j=0; j<=i; j++) {
                if (!m[j].empty()) {
                    auto w2 = s.substr(j, i-j+1);
                    if (dict.find(w2)==dict.end()) continue;
                    m[i+1].push_back(j); //  i+1 to parent j
                }
            }
        }
        Rec2(len, "");
        return ans;
    }
    
    void Rec2(int idx, string curr) {
        if (idx==0) {
            ans.push_back(curr);
            return;
        }
        if (!curr.empty()) curr = " " + curr;
        for(auto j : m[idx]) {
            auto nt = str.substr(j, idx-j) + curr; // appending current
            Rec2(j, nt);
        }
    }
};


// TLE
class Solution {
public:
    string str;
    vector<string> words;
    vector<string> t;
    vector<string> ans;
    int len;
    void Rec(int i) {
        if (i==len) {
            string l = "";
            for(auto s : t)
                l += s + " ";
            l.pop_back();
            ans.push_back(l);
            return;
        }
        
        for(auto w : words) {
            if (w.size()+i>len) continue;
            if (str.substr(i, w.size())!= w) continue;
            t.push_back(w);
            Rec(i + w.size());
            t.pop_back();
        }
    }
    
    vector<string> wordBreak(string s, vector<string>& wordDict) {
        str = s;
        len = s.size();
        words = wordDict;
        Rec(0);
        return ans;
    }
};
