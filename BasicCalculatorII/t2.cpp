/*
Implement a basic calculator to evaluate a simple expression string.
The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.
Example 1:
Input: "3+2*2"
Output: 7
Example 2:
Input: " 3/2 "
Output: 1
Example 3:
Input: " 3+5 / 2 "
Output: 5
Note:
You may assume that the given expression is always valid.
Do not use the eval built-in library function.
*/
// Comment: Use LL(1) parser
class Solution {
public:
    vector<string> tokens;
    int i;
    int len;
    void parse(string s)
    {
        for(int i=0; i<s.length(); ) {
            char c = s[i];
            if (c==' ') {i++; continue;}
            if (!isdigit(s[i])) { // + - * /
                tokens.push_back(s.substr(i,1));
                i++; continue;
            }
            int j= i;
            while(j<s.length() && isdigit(s[j]))
              tokens.push_back(s.substr(i, ++j-i));
            
            i=j;
        }
    }
    
    int expr()
    {
        int ans = factor();
        string s;
        while(i<len && ((s=tokens[i])=="+"|| s=="-")) {
            i++; // consume +/-
            if (s=="+") ans += factor();
            else ans-= factor();
        }
        return ans;
    }
    int factor()
    {
        int ans = number();
        string s;
        while(i<len && ((s=tokens[i])=="*") || s=="/") {
            i++; // consume */
            if (s=="*") ans *= number();
            else ans /= number();
        }
        return ans;
    }
    int number() {
        return stoi(tokens[i++]);
    }
    // LL(1) parser
    // expr = factor {+ factor}
    // factor = primary {* primary}
    // primary = number
    
    int calculate(string s) {
        parse(s);
        i = 0;
        len = tokens.size();
        return expr();
    }
};