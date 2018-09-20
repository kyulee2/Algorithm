/*
There is a box protected by a password. The password is n digits, where each letter can be one of the first k digits 0, 1, ..., k-1.

You can keep inputting the password, the password will automatically be matched against the last n digits entered.

For example, assuming the password is "345", I can open it when I type "012345", but I enter a total of 6 digits.

Please return any string of minimum length that is guaranteed to open the box after the entire string is inputted.

Example 1:
Input: n = 1, k = 2
Output: "01"
Note: "10" will be accepted too.
Example 2:
Input: n = 2, k = 2
Output: "00110"
Note: "01100", "10011", "11001" will be accepted too.
Note:
n will be in the range [1, 4].
k will be in the range [1, 10].
k^n will be at most 4096.
*/
// Comment: DFS with visited. Outputing while it's going out.
// Greedy. Euler walk until stuck. It's post order recording
public class Solution {
    public string CrackSafe(int n, int k) {
        if (n==1 && k==1)
            return "0";
        
        // DFS + output at the end
        // O(n * k^n)?
        var ans = new StringBuilder();
        // n-1 times "0"
        var start = new string('0', n-1);
        var visited = new HashSet<string>();
        
        void Rec(string s)
        {
            for(int j=0; j<k; j++) {
                string t = s + j;
                if (!visited.Contains(t)) {
                    visited.Add(t);
                    Rec(t.Substring(1));
                    ans.Append(j);
                }
            }
        }
        
        Rec(start);
        ans.Append(start);
        return ans.ToString();
    }
}
