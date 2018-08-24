/*
Validate if a given string is numeric.

Some examples:
"0" => true
" 0.1 " => true
"abc" => false
"1 a" => false
"2e10" => true

Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one.

Update (2015-02-10):
The signature of the C++ function had been updated. If you still see your function signature accepts a const char * argument, please click the reload button to reset your code definition.

*/
// Comment: A few corner case. In particular, optional sign and at least one digit in real number
public class Solution {
    bool IsDigit(char c) { return c>='0' && c<='9';}
    bool IsSign(char c) {return c=='+' || c=='-';}
    bool IsNaturalNumber(string s) {
        int i= 0;
        int len = s.Length;
        if (len==i) return false;
        if (IsSign(s[i])) i++;
        if (len==i) return false;
        for(; i<len; i++)
            if (!IsDigit(s[i]))
                return false;
        return true;
    }
    bool IsNaturalNumberOrNull(string s) {
        int i= 0;
        int len = s.Length;
        if (len==i) return true;
        for(; i<len; i++)
            if (!IsDigit(s[i]))
                return false;
        return true;
    } 
    public bool IsNumber(string s) {
        // trim space front/back
        int i=0, j=s.Length-1;
        for(; i<s.Length;i++)
            if (s[i]!=' ') break;
        for(; j>=0; j--)
            if (s[j]!=' ') break;
        // Spoiler: check entire empty string
        if (i==s.Length) return false;
        s = s.Substring(i, j-i+1);
        
        // split on e/E
        var t = s.Split(new char[]{'e','E'});
        if (t.Length>2) return false;
        if (t.Length == 2) {
            // check exponent
            if (!IsNaturalNumber(t[1]))
                return false;
        }
        // Split on . if any
        var d = t[0].Split('.');
        if (d.Length>2) return false;
        // Treat sign first optionally
        s = d[0];
        if (s.Length>=1 && IsSign(s[0]))
            s = s.Substring(1);
        
        if (d.Length == 2) {
            if (d[1].Length==0 && s.Length==0)
                return false;
            if (!IsNaturalNumberOrNull(d[1]))
                return false;
        } else {
            if (s.Length==0)
                return false;
        }

        if (!IsNaturalNumberOrNull(s))
            return false;
        return true;
    }
}
