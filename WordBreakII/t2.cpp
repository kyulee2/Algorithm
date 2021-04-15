
#include <vector>
#include <set>
#include <string>
#include <iostream>

using namespace std;

class Solution {
public:
    vector<string> ans;
    set<string> words;
    vector<string> wordBreak(string s, vector<string>& wordDict) {
        ans.clear();
        words.clear();
        for(auto w : wordDict)
            words.insert(w);
        find(s, "");
        return ans;
    }
    void find(string r, string curr) {
        if (r.empty()) {
            if (!curr.empty())
                ans.push_back(curr);
            return;
        }


        for (int l = 1; l <= r.length(); ++l) {
            auto sub = r.substr(0, l);
            if (words.count(sub)) {
                auto nextStr = r.substr(l);
                string nextCurr = curr;
                if (!nextCurr.empty())
                     nextCurr.append(" ");
                nextCurr.append(sub);
                find(nextStr, nextCurr);
            }
        }
    }
};

// c++20, starts_with, -std=c++2a
class Solution2 {
public:
    vector<string> ans;
    vector<string> wordBreak(string s, vector<string>& wordDict) {
        ans.clear();
        find(s, "", wordDict);
        return ans;
    }
    void find(string r, string curr, vector<string>& wordDict) {
        if (r.empty()) {
            if (!curr.empty())
                ans.push_back(curr);
            return;
        }

        for (auto w : wordDict) {
            if (r.starts_with(w)) {
                auto nextStr = r.substr(w.length());
                string nextCurr = curr;
                if (!nextCurr.empty())
                     nextCurr.append(" ");
                nextCurr.append(w);
                find(nextStr, nextCurr, wordDict);
            }
        }
    }
};

int main() {
    Solution2 s;
    vector<string> words = {"cat","cats","and","sand","dog"};
    auto ans  = s.wordBreak("catsanddog", words);
    for(auto t : ans) {
        cout << t << "\n";
    }
}
