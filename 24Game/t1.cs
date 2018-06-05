/*
You have 4 cards each containing a number from 1 to 9. You need to judge whether they could operated through *, /, +, -, (, ) to get the value of 24.

Example 1:
Input: [4, 1, 8, 7]
Output: True
Explanation: (8-4) * (7-1) = 24
Example 2:
Input: [1, 2, 1, 2]
Output: False
Note:
The division operator / represents real division, not integer division. For example, 4 / (1 - 2/3) = 12.
Every operation done is between two numbers. In particular, we cannot use - as a unary operator. For example, with [1, 1, 1, 1] as input, the expression -1 - 1 - 1 - 1 is not allowed.
You cannot concatenate numbers together. For example, if the input is [1, 2, 1, 2], we cannot write this as 12 + 12.
*/
// Comment: The below is naively recursion for all cases, but pass.
// Shuffle cards/numbers (no duplication), and allow duplication for operation.
// Check 5 patterns for operation order.

public class Solution {
    bool[] usedN;

    int LenN;
    int[] tn;
    int LenO;
    char[] to;
    
    int[] n;
    char[] o;
    
    double perform(char op, double a, double b)
    {
        switch(op) {
            case '+':  return a+ b;
            case '-': return a- b;
            case '*': return a * b;
            case '/': return a/ b;
        }
        return 0;
    }
    bool check(double s)
    {
        return Math.Abs((double)24 - s) < 0.0001;
    }
    
    bool Pat1()
    {
        // ab -> abc -> abcd
        double s = perform(to[0], tn[0], tn[1]);
        s = perform(to[1], s, tn[2]);
        s = perform(to[2], s, tn[3]);
        return check(s);
    }
    bool Pat2()
    {
        // bc -> abc -> abcd
        double s = perform(to[1], tn[1], tn[2]);
        s = perform(to[0], tn[0], s);
        s = perform(to[2], s, tn[3]);
        return check(s);
    }
    bool Pat3()
    {
        // bc -> bcd -> abcd
        double s = perform(to[1], tn[1], tn[2]);
        s = perform(to[2], s, tn[3]);
        s = perform(to[0], tn[0], s);
        return check(s);
    }    
    bool Pat4()
    {
        // ab -> cd -> abcd
        double s1 = perform(to[0], tn[0], tn[1]);
        double s2 = perform(to[2], tn[2], tn[3]);
        double s = perform(to[1], s1, s2);
        return check(s);
    }
    bool Pat5()
    {
        // cd-> bcd -> abcd
        double s = perform(to[2], tn[2], tn[3]);
        s = perform(to[1], tn[1], s);
        s = perform(to[0], tn[0], s);
        return check(s);
    }
                   
    bool Rec2(int j)
    {
        if (j==LenO) {
            return Pat1() || Pat2() || Pat3() || Pat4() || Pat5();            
        }
        
        bool ans = false;
        for(int i=0; i< LenO; i++) {
            char op = o[i];
            to[j] = op;
            ans |= Rec2(j+1);
        }
        
        return ans;            
    }
    
    // Recursion different number
    bool Rec1(int j)
    {
        if (j==LenN) {
            return Rec2(0);
        }
        
        bool ans = false;
        
        for(int i=0; i< LenN; i++) {
            if (usedN[i]) continue;
            int num = n[i];
            tn[j] = num;
            usedN[i] = true;
            ans |= Rec1(j+1);
            usedN[i] = false;
        }
        
        return ans;         
    }
        
    public bool JudgePoint24(int[] nums) {
        // Intialize data
        n = nums;
        LenN = n.Length;
        o = new char[]{'+','-','*','/'};
        LenO = o.Length;
        
        usedN = new bool[LenN];
        tn = new int[LenN];
        to = new char[LenO];

        return Rec1(0);
    }
}

