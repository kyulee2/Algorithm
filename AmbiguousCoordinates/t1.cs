/*
We had some 2-dimensional coordinates, like "(1, 3)" or "(2, 0.5)".  Then, we removed all commas, decimal points, and spaces, and ended up with the string S.  Return a list of strings representing all possibilities for what our original coordinates could have been.
Our original representation never had extraneous zeroes, so we never started with numbers like "00", "0.0", "0.00", "1.0", "001", "00.01", or any other number that can be represented with less digits.  Also, a decimal point within a number never occurs without at least one digit occuring before it, so we never started with numbers like ".1".
The final answer list can be returned in any order.  Also note that all coordinates in the final answer have exactly one space between them (occurring after the comma.)
Example 1:
Input: "(123)"
Output: ["(1, 23)", "(12, 3)", "(1.2, 3)", "(1, 2.3)"]
Example 2:
Input: "(00011)"
Output:  ["(0.001, 1)", "(0, 0.011)"]
Explanation: 
0.0, 00, 0001 or 00.01 are not allowed.
Example 3:
Input: "(0123)"
Output: ["(0, 123)", "(0, 12.3)", "(0, 1.23)", "(0.1, 23)", "(0.1, 2.3)", "(0.12, 3)"]
Example 4:
Input: "(100)"
Output: [(10, 0)]
Explanation: 
1.0 is not allowed.
 
Note: 
4 <= S.length <= 12.
S[0] = "(", S[S.length - 1] = ")", and the other elements in S are digits.
 
*/
// Comment: Use a helper function, getValidStr() to produce list of valid string for the given string
// Aggregate all cases by splitting string into left and right

public class Solution
{
    public IList<string> AmbiguousCoordinates(string S)
    {
        List<string> getValidStr(string str)
        {
            var l = new List<string>();
            int len = str.Length;
            if (str[0] == '0' && len > 1 && str[len - 1] == '0')
                return l;
            if (str[0]=='0' && len > 1)
            {
                l.Add(str[0] + "."+str.Substring(1));
                return l;
            }
            if (len>=1 && str[len-1]=='0')
            {
                l.Add(str);
                return l;
            }
            l.Add(str);
            for(int i=1; i<len;i++)
            {
                l.Add(str.Substring(0, i) + "." + str.Substring(i, len - i));
            }
            return l;
        }

        int SLen = S.Length;
        List<string> ans = new List<string>();
        if (SLen == 3)
        {
            ans.Add(S.Substring(1,1));
            return ans;
        }

        for(int j=2; j<SLen-1; j++)
        {
            var left = getValidStr(S.Substring(1, j - 1));
            var right = getValidStr(S.Substring(j, SLen - j - 1));
            if (left.Count == 0 || right.Count == 0)
                continue;

            foreach(var x in left)
            {
                foreach(var y in right)
                {
                    ans.Add("(" + x + ", " + y + ")");
                }
            }
        }
        return ans;
    }
}

 
