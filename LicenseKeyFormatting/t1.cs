/*
You are given a license key represented as a string S which consists only alphanumeric character and dashes. The string is separated into N+1 groups by N dashes.
Given a number K, we would want to reformat the strings such that each group contains exactly K characters, except for the first group which could be shorter than K, but still must contain at least one character. Furthermore, there must be a dash inserted between two groups and all lowercase letters should be converted to uppercase.
Given a non-empty string S and a number K, format the string according to the rules described above.
Example 1:
Input: S = "5F3Z-2e-9-w", K = 4

Output: "5F3Z-2E9W"

Explanation: The string S has been split into two parts, each part has 4 characters.
Note that the two extra dashes are not needed and can be removed.

Example 2:
Input: S = "2-5g-3-J", K = 2

Output: "2-5G-3J"

Explanation: The string S has been split into three parts, each part has 2 characters except the first part as it could be shorter as mentioned above.

Note:
The length of string S will not exceed 12,000, and K is a positive integer.
String S consists only of alphanumerical characters (a-z and/or A-Z and/or 0-9) and dashes(-).
String S is non-empty.
*/
// Comment: Overall easy. Just use StringBuilder. We could do one-pass with one additional memory.
// But it would be less error prone if we do this using multiple steps in separate.

public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
        StringBuilder b = new StringBuilder();
        foreach(var c in S)
            if (c != '-')
                b.Append(Char.ToUpper(c));
        StringBuilder ans = new StringBuilder();
        int r = b.Length % K;
        int i = 0;
        if (r > 0) {
            while(r-- > 0)
                ans.Append(b[i++]);
            // spoiler: do this only if this is not the end
            if (i != b.Length)
                ans.Append('-');
        }
        for(int j = 0; i < b.Length; i++, j++) {
            if (j !=0 && (j % K == 0))
                ans.Append('-');
            ans.Append(b[i]);
        }
        return ans.ToString();
    }
}


