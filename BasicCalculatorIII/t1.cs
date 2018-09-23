/*
Implement a basic calculator to evaluate a simple expression string.
The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .
The expression string contains only non-negative integers, +, -, *, / operators , open ( and closing parentheses ) and empty spaces . The integer division should truncate toward zero.
You may assume that the given expression is always valid. All intermediate results will be in the range of [-2147483648, 2147483647].
Some examples:
"1 + 1" = 2
" 6-4 / 2 " = 4
"2*(5+5*2)/3+(6/2+8)" = 21
"(2+6* 3+5- (3*14/7+2)*5)+3"=-12
 
Note: Do not use the eval built-in library function.
*/
// Comment: Tricy to handle ()
// The below uses Rec() when to expect next number.
// Other logic about precedence of */ over +- is similar to BasicCalculatorII
// Basically we starts from reading one number pushed to stack
// For each iteration, try to read one op followed by another number.
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
    long getNextNum(Stack<long> ns)
    {
        var t = ins[idx++];
        long nextNum = 0;
        if (t=="(")
            nextNum = Rec();
        else nextNum = Convert.ToInt64(t);
        return nextNum;
    }
    
    char getNextOp()
    {
        return ins[idx++][0];
    }
    
    long Rec()
    {
        Stack<long> ns = new Stack<long>();
        Stack<char> os = new Stack<char>();
        // Init with the first number or () via Recursion
        ns.Push(getNextNum(ns));
        while(idx < len) {
            var op = getNextOp();
            if (op==')') { // close the recursion
                if(os.Count==0)
                    return ns.Count == 0? 0 /* () case ?*/ : ns.Pop();
                long r = ns.Pop();
                long l = ns.Pop();
                return os.Pop() == '+' ? l + r : l - r;                    
            }
            
            var num = getNextNum(ns);
            long left, res, right;
            switch(op) {
                case '*':
                case '/':
                    left = ns.Pop();
                    res = op=='*' ? left * num : left / num;
                    ns.Push(res);
                    break;
                case '+':
                case '-':
                    if (os.Count !=0) {
                        right = ns.Pop();
                        left = ns.Pop();
                        char p = os.Pop();
                        res = p=='+' ? left + right : left - right;
                        ns.Push(res);
                    }
                    ns.Push(num);
                    os.Push(op);
                    break;
            }
        }
        
        // FLush the last +/- operation if any
        if(os.Count==0)
            return ns.Pop();
        long r2 = ns.Pop();
        long l2 = ns.Pop();
        return os.Pop() == '+' ? l2 + r2 : l2 - r2;
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
    
        return (int)Rec();
    }
}