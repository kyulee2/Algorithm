/*
Solve a given equation and return the value of x in the form of string "x=#value". The equation contains only '+', '-' operation, the variable x and its coefficient.

If there is no solution for the equation, return "No solution".

If there are infinite solutions for the equation, return "Infinite solutions".

If there is exactly one solution for the equation, we ensure that the value of x is an integer.

Example 1:
Input: "x+5-3+x=6+x-2"
Output: "x=2"
Example 2:
Input: "x=x"
Output: "Infinite solutions"
Example 3:
Input: "2x=x"
Output: "x=0"
Example 4:
Input: "2x+3x-6x=x+2"
Output: "x=-1"
Example 5:
Input: "x=x+2"
Output: "No solution"
*/
// Comment: A bit tedious. Corner cases.
public class Solution {
    public string SolveEquation(string equation) {
        int a = 0, b =0; // coefficient (left), constant (right)
        bool isFlip = false;
        int len = equation.Length;
        bool isPlus = true;
        for(int i=0; i<len; i++) {
            int j = i;
            if (equation[i]=='+') {
                isPlus = true;
                continue;
            }
            else if (equation[i]=='-') {
                isPlus = false;
                continue;
            }
            else if (equation[i]=='=')  {
                isFlip = true;
                isPlus = true;
                continue;
            }

            while(j<len && equation[j]!='+' && equation[j]!='-' && equation[j]!='=')
                j++;

            var s = equation.Substring(i, j-i);
            int n = 0;
            if (s[s.Length-1] == 'x') {
                if (j-i>1) {
                    int.TryParse(s.Substring(0, s.Length-1), out n);
                } else n = 1;
                a += (isFlip ^isPlus? n : -n);
                
            } else {
                int.TryParse(s, out n);
                b += (isFlip ^ isPlus?-n : n);
            }
            i = j - 1;
        }
        
        if (a==0 && b==0)
            return "Infinite solutions";
        if (a==0 && b!=0)
            return "No solution";
        int res = b / a;
        return "x="+ res;
    }
}
