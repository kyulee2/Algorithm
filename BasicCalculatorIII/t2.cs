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
// Way simpler than t1.cs which uses nested stack in a hacky way.
public class Solution {
    bool IsOp(Char c)
    {
        switch(c) {
            case '+':
            case '-':
            case '*':
            case '/':
            case '(':
            case ')':
                return true;
        }
        return false;
    }

    // private values
    int idx;
    int len;
    List<string> ins;

    // expr = factor { addop factor }
    // factor = primary { mulop primary }
    // primary = num
    // primary = ( expr )
    string PeekNext()
    {
        if (idx>=len) return null;
        return ins[idx];
    }
    string GetNext()
    {
        if (idx>=len) return null;
        return ins[idx++];
    }
    
    long expr()
    {
        long l = factor();
        for(var t = PeekNext(); t != null && (t=="+"||t=="-") ; t = PeekNext()) {
            GetNext(); // consume +/-
            long r = factor();
            l = t == "+" ? l + r : l - r;
        }
        return l;
    }
    long factor()
    {
        long l = primary();
        for(var t = PeekNext(); t != null && (t=="*"||t=="/") ; t = PeekNext()) {
            GetNext(); // consume *//
            long r = primary();
            l = t == "*" ? l * r : l / r;
        }
        return l;
    }
    long primary()
    {
        var t = PeekNext();
        long l = 0;
        if (t=="(") {
            GetNext(); // (
            l = expr();
            GetNext(); // )
        } else {
            l = Convert.ToInt64(GetNext());
        }
        return l;
    }

    public int Calculate(string s) {
        // tokenize
        ins = new List<String>();
        len = s.Length;
        for(int i=0; i<len; i++) {
            var c = s[i];
            if (c==' ') continue;
            if (IsOp(c)) {
                ins.Add(c.ToString());
                continue;
            }
            int j= i;
            while(j<len && s[j]>='0' && s[j]<='9') j++;
            ins.Add(s.Substring(i,j-i));
            i = j-1;
        }

        // Set private valus
        idx = 0;
        len = ins.Count;
    
        return (int)expr();
    }
}