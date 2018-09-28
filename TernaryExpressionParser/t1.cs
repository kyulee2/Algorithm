/*
Given a string representing arbitrarily nested ternary expressions, calculate the result of the expression. You can always assume that the given expression is valid and only consists of digits 0-9, ?, :, T and F (T and F represent True and False respectively). 
Note: 
The length of the given string is = 10000.
Each number will contain only one digit.
The conditional expressions group right-to-left (as usual in most languages).
The condition will always be either T or F. That is, the condition will never be a digit.
The result of the expression will always evaluate to either a digit 0-9, T or F.

Example 1: 
Input: "T?2:3"

Output: "2"

Explanation: If true, then result is 2; otherwise result is 3.

Example 2: 
Input: "F?1:T?4:5"

Output: "4"

Explanation: The conditional expressions group right-to-left. Using parenthesis, it is read/evaluated as:

             "(F ? 1 : (T ? 4 : 5))"                   "(F ? 1 : (T ? 4 : 5))"
          -> "(F ? 1 : 4)"                 or       -> "(T ? 4 : 5)"
          -> "4"                                    -> "4"

Example 3: 
Input: "T?T?F:5:3"

Output: "F"

Explanation: The conditional expressions group right-to-left. Using parenthesis, it is read/evaluated as:

             "(T ? (T ? F : 5) : 3)"                   "(T ? (T ? F : 5) : 3)"
          -> "(T ? F : 3)"                 or       -> "(T ? F : 5)"
          -> "F"                                    -> "F"
*/
// Comment: Use recursive decent parsing. Looking ahead 2.
    // expr - cond ? expr : expr
    // expr - num
    // expr - T
    // expr - F
    // cond - T
    // cond - F
public class Solution {
    List<string> data;
    int i;
    string next() {
        if (i==data.Count) return "";
        return data[i];
    }
    string next2() {
        if (i+1>=data.Count) return "";
        return data[i+1];
    }
    
    string consume()
    {
        if (i==data.Count) return "";
        return data[i++];
    }

    bool cond() {
        return consume()== "T";
    }
    bool isCond(string s) {
        return s == "T" || s == "F";
    }
    string expr() {
        var t = next();
        if (t=="") return "";
        if (isCond(t) && next2()=="?") {// ternary expr
            bool flag = cond();
            consume(); // match "?"
            var l = expr();
            consume(); // match ":"
            var r = expr();
            return flag ? l : r;
        } else {// just single expr
            return consume();
        }
    }
    
    public string ParseTernary(string expression) {
        // init parse.
        data = new List<string>();
        int i=0;
        int len = expression.Length;
        int j = 0;
        while(j<len) {
            var k1 = expression.IndexOf("?",j);
            var k2 = expression.IndexOf(":",j);
            if (k1>0 && (k1<k2 || k2<0)) {
                data.Add(expression.Substring(j, k1-j));
                data.Add("?");
                j= k1 + 1;
            } else if (k2>0 && (k2<k1 || k1<0)) {
                data.Add(expression.Substring(j, k2-j));
                data.Add(":");
                j= k2 + 1;                
            } else {
                data.Add(expression.Substring(j));
                break;
            }
        }
        
        return expr();
    }
}