
// Comment: Use excpetion to search naively all possible cases, which are extremely slow.
class Solution {
public:
    vector<string> tokens;
    void parse(string s)
    {
        for(int i=0; i<s.length(); ) {
            char c = s[i];
            if (c==' ') {i++; continue;}
            if (c=='+' || c=='-' || c=='(' || c==')') {
                tokens.push_back(s.substr(i,1));
                i++; continue;
            }
            int j= i;
            while(j<s.length() && isdigit(s[j])) j++;
            tokens.push_back(s.substr(i, j-i));
            
            i=j;
        }
    }
    
    // LL(1) parser
    // expr = primary {+ primary}
    // primary = ( expr )
    // primary = number
    int expr() {
        int ans = primary();
        while(i<len && (tokens[i]=="+"|| tokens[i]=="-")) {
            if (tokens[i++]=="+")
                ans += primary();
            else
                ans -= primary();
        }
        return ans;
    }
    int primary()
    {
        int ans = 0;
        if (tokens[i]=="(") {
            i++; // (
            ans = expr();
            i++; // )
        } else 
            ans = stoi(tokens[i++]);
        return ans;
    }
    
    int i;
    int len;
    int calculate(string s) {
        parse(s);
        len = tokens.size();
        i = 0;
        return expr();
    }
};