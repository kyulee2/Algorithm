/*
Given an encoded string, return it's decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

Examples:

s = "3[a]2[bc]", return "aaabcbc".
s = "3[a2[c]]", return "accaccacc".
s = "2[abc]3[cd]ef", return "abcabccdcdcdef".

*/
// Comment: checking lower/uppwer case both.
// Use two stacks (one for # and the other for string".
// Make sure the parsed string is either appended to the top of string stakc (if it's not empty), or simply appended to the output.
// There is no repeat of string api. Just use a loop. learn isalpha() and isdigit()
class Solution {
public:

    string decodeString(string s) {
        int len = s.length();
        string ans;
        stack<int> ns;
        stack<string> nc;
        
        for(int i=0; i<len; ) {
            auto c = s[i++];
            if (isalpha(c)) {
                if (nc.size()==0) ans+= c;
                else nc.top() += c;
            } else if (isdigit(c)) {
                int j = s.find('[', i);
                int n = stoi(s.substr(i-1,j-i+1));
                ns.push(n);
                nc.push("");
                i = j + 1;
            } else if (c==']') { // this could be just else with assertion
                auto str = nc.top(); nc.pop();
                auto m = ns.top(); ns.pop();
                for(int j=0; j<m; j++) {
                    if (nc.size()==0)
                        ans += str;
                    else nc.top() += str;
                }
            }
        }
        return ans;
    }
};
