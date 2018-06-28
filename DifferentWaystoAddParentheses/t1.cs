/*
Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators. The valid operators are +, - and *.

Example 1:

Input: "2-1-1"
Output: [0, 2]
Explanation: 
((2-1)-1) = 0 
(2-(1-1)) = 2
Example 2:

Input: "2*3-4*5"
Output: [-34, -14, -10, -10, 10]
Explanation: 
(2*(3-(4*5))) = -34 
((2*3)-(4*5)) = -14 
((2*(3-4))*5) = -10 
(2*((3-4)*5)) = -10 
(((2*3)-4)*5) = 10
*/
// Comment: This is quite interesting problem. Initially tried to naively recursion, which failed. 
// Need to use Divide and Conquer.
public class Solution {
    public IList<int> DiffWaysToCompute(string input) {
        var ans = new List<int>();
        for(int i=0; i<input.Length; i++) {
            char c = input[i];
            if (c=='+' || c=='-' || c=='*') {
                var ls = DiffWaysToCompute(input.Substring(0,i));
                var rs = DiffWaysToCompute(input.Substring(i+1));
                
                foreach(var l in ls)
                    foreach(var r in rs) {
                        switch(c) {
                            case '+':ans.Add(l+r); break;
                            case '-':ans.Add(l-r); break;
                            case '*':ans.Add(l*r); break;                                
                        }                  
                    }
            }
        }
        if (ans.Count==0) {
            ans.Add(Convert.ToInt32(input));
        }
        return ans;
    }
}
