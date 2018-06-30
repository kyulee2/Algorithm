/*
Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.
Note: The input string may contain letters other than the parentheses ( and ).
Example 1:
Input: "()())()"
Output: ["()()()", "(())()"]
Example 2:
Input: "(a)())()"
Output: ["(a)()()", "(a())()"]
Example 3:
Input: ")("
Output: [""]
*/

// Comment: Key point was to retain two redundant Left, Right variables.
// Initially I thought about one status (amortized one), which is hard to detect "))((" case.
// See initialize redundant L, R parts.
public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {

        var ans = new HashSet<string>();
        int len = s.Length;
        
        void Rec(string str, int i, int L, int R, int open)
        {
            if (L<0 || R<0 || open<0)
                return;
            
            if (i==len) {
                if (open==0 && L==0 && R==0)
                    ans.Add(str);
                return;
            }

            char c = s[i];
            if (c=='(') {
                Rec(str , i+1, L-1, R, open); // remove
                Rec(str + c, i+1, L, R, open+1); // consume
            } else if (c==')') {
                Rec(str , i+1, L, R-1, open); // remove
                Rec(str + c, i+1, L, R, open-1); // consume         
            } else {
                Rec(str + c, i+1, L, R, open);
            }
        }
        
        // Initialize redundant L, R
        int tL = 0, tR = 0;
        for(int i=0; i<len ; i++) {
            char c = s[i];
            if (c=='(') tL++;
            else if (c==')') {
                if (tL>0) tL--;
                else tR++;
            }
        }
        
        Rec("", 0, tL, tR, 0);
        return ans.ToList();
    }
}