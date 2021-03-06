/*
Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.
Example 1:
Input: num = "123", target = 6
Output: ["1+2+3", "1*2*3"] 
Example 2:
Input: num = "232", target = 8
Output: ["2*3+2", "2+3*2"]
Example 3:
Input: num = "105", target = 5
Output: ["1*0+5","10-5"]
Example 4:
Input: num = "00", target = 0
Output: ["0+0", "0-0", "0*0"]
Example 5:
Input: num = "3456237490", target = 9191
Output: []
*/
// Comment: Divide and Conquer. A bit triaky for minus case.
// passing two intermediate value, curr/tgt where the former represents
// multiplier while tgt is actualy target which is reduced/reflected by +/-
// O(N^2 3^N) for time and space.
class Solution {
public:
    vector<string> *ans;
    void Rec(string n, string input, long curr, long tgt) {
        for(int i=1; i<= n.length(); i++) {
            auto l = n.substr(0, i);
            // spoiler: not consider 0 leading number
            if (l[0]=='0' && i>1)
                break;
            auto r = n.substr(i);
            auto ln = stol(l) * curr;
            auto nextinput = input + l;
            
            if (r.empty()) {
                if (ln == tgt)
                    ans->push_back(nextinput);
                break;
            }
            
            Rec(r, nextinput + "+", 1, tgt -ln);
            Rec(r, nextinput + "-", -1, tgt -ln); // not 1, ln -tgt
            Rec(r, nextinput + "*", ln, tgt);
        }
    }
    vector<string> addOperators(string num, int target) {
        vector<string> t;
        ans = &t;
        Rec(num, "", 1, target);
        
        return t;
    }
};
