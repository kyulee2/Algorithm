/*
mplement a basic calculator to evaluate a simple expression string.
The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .
The expression string contains only non-negative integers, +, -, *, / operators , open ( and closing parentheses ) and empty spaces . The integer division should truncate toward zero.
You may assume that the given expression is always valid. All intermediate results will be in the range of [-2147483648, 2147483647].
Some examples:
"1 + 1" = 2
" 6-4 / 2 " = 4
"2*(5+5*2)/3+(6/2+8)" = 21
"(2+6* 3+5- (3*14/7+2)*5)+3"=-12
 
*/
// Use CFG and LL(1) grammar -- recursive decent parsing
class Solution {
public:
    vector<string> tokens;
    int i;
    int len;
    void parse(string s) {
        for(int i=0; i<s.size(); /* no inc*/) {
            char c = s[i];
            if (c==' ') {i++;continue;}
            if (!isdigit(c)) {
                tokens.push_back(s.substr(i++,1));
                continue;
            }
            int j = i;
            while(j<s.size() && isdigit(s[j])) j++;
            tokens.push_back(s.substr(i,j-i));
            i = j;
        }
    }
    // expr = factor { + factor}
    // factor = primary { * primary }
    // primary = ( expr )
    // primary = number
    long expr() {
        long ans = factor();
        string s;
        while(i<len && (((s=tokens[i])=="+")|| (s=="-"))) {
            i++;
            if (s=="+") ans += factor();
            else ans -= factor();
        }
        return ans;
    }
    long factor() {
        long ans = primary();
        string s;
        while(i<len && (((s=tokens[i])=="*")|| (s=="/"))) {
            i++;
            if (s=="*") ans *= primary();
            else ans /= primary();
        }
        return ans;
    }    
    long primary()
    {
        long ans = 0;
        string s = tokens[i++];
        if (s=="(") {
            ans = expr();
            i++; // )
        } else
            ans = stol(s);
        return ans;
    }
    int calculate(string s) {
        parse(s);
        i = 0;
        len = tokens.size();
        return (int)expr();
    }
};