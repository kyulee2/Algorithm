/*
Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether this string is valid. We define the validity of a string by these rules:

Any left parenthesis '(' must have a corresponding right parenthesis ')'.
Any right parenthesis ')' must have a corresponding left parenthesis '('.
Left parenthesis '(' must go before the corresponding right parenthesis ')'.
'*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
An empty string is also valid.
Example 1:
Input: "()"
Output: True
Example 2:
Input: "(*)"
Output: True
Example 3:
Input: "(*))"
Output: True
Note:
The string size will be in the range [1, 100].

*/
// Comment: Without memoization, O(3^n) worst case.
// The below becomes O(n^2) space/time.
public class Solution {
    public bool CheckValidString(string s) {
        int len = s.Length;
        var map = new int[len+1, len+1];
        bool Rec(int i, int count)
        { 
            if (count<0)
                return false;
            
            if (map[i,count] != 0)
                return map[i,count] == 1;
            bool ans = false;
            if (i==len) {
                ans = count == 0;
                map[i,count] = ans ? 1 : -1;
                return ans;
            }
            
            char c= s[i];
            if (c=='(')
                ans |= Rec(i+1, count+1);
            else if (c==')')
                ans |= Rec(i+1, count-1);
            else {
                ans |= Rec(i+1, count+1);
                ans |= Rec(i+1, count-1);
                ans |= Rec(i+1, count);
            }
            
            map[i,count] = ans ? 1 : -1;
            return ans;
        }
        
        return Rec(0, 0);
    }
}
