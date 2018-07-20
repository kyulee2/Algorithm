/*
Implement a basic calculator to evaluate a simple expression string.
The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.
Example 1:
Input: "3+2*2"
Output: 7
Example 2:
Input: " 3/2 "
Output: 1
Example 3:
Input: " 3+5 / 2 "
Output: 5
Note:
You may assume that the given expression is always valid.
Do not use the eval built-in library function.
*/
// Comment: Use two stacks. 
public class Solution {
    string trimSpace(string s)
    {
        var b = new StringBuilder();
        for(int i=0; i<s.Length; i++)
            if (s[i] != ' ')
                b.Append(s[i]);
        return b.ToString();
    }
    public int Calculate(string s) {
        s = trimSpace(s);
        int len = s.Length;
        int i=0;
        char getNextOp()
        {
            return s[i++];
        }
        int getNextNum()
        {
            int j= i;
            while(i<len && s[i]>='0' && s[i]<='9')
                i++;
            return Convert.ToInt32(s.Substring(j,i-j));
        }
        
        var sn = new Stack<int>();
        var so = new Stack<char>();
        sn.Push(getNextNum());
        while(i<len) {
            char op = getNextOp();
            int num = getNextNum();
            int pnum = 0;
            switch(op) {
                case '*':
                case '/':
                    pnum = sn.Pop();
                    pnum = op=='*' ? pnum *num : pnum/num;
                    sn.Push(pnum);
                    break;
                case '+':
                case '-':
                    if (so.Count != 0) {
                        pnum = sn.Pop();
                        int ppnum = sn.Pop();
                        char pop = so.Pop();
                        pnum = pop=='+' ? ppnum+pnum : ppnum-pnum;
                        sn.Push(pnum);
                    }
                    sn.Push(num);
                    so.Push(op);
                    break;
            }
        }
        
        if(so.Count==0)
            return sn.Pop();
        int right = sn.Pop();
        int left = sn.Pop();
        return so.Pop() == '+' ? left + right : left-right;
    }
}