/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]
*/
class Solution {
public:
    int len;
    vector<string> *ans;
    void Rec(int i, int status, string s)
    {
        if (i==len) {
            if (status==0)
              ans->push_back(s);
            return;
        }
        
        if (status>0) {
            Rec(i+1, status-1, s +")");
        }
        Rec(i+1, status+1, s + "(");
    }
    
    vector<string> generateParenthesis(int n) {
        vector<string> t;
        ans = &t;
        len = n * 2;
        Rec(0, 0, "");
        return t;
    }
};
