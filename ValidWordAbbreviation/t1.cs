/*
Given a non-empty string s and an abbreviation abbr, return whether the string matches with the given abbreviation. 
A string such as "word" contains only the following valid abbreviations:
["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
Notice that only the above abbreviations are valid abbreviations of the string "word". Any other string is not a valid abbreviation of "word".
Note:
Assume s contains only lowercase letters and abbr contains only lowercase letters and digits. 
Example 1:
Given s = "internationalization", abbr = "i12iz4n":

Return true.

Example 2:
Given s = "apple", abbr = "a2e":

Return false.
*/

// Comment: Not hard. But careful about indexing increment. For non-digit case, increase both i/j
// For digit case, i/j are already incremented.
// There is one spoiler. "a" "01" returns false -- digit shouldn't start with 0.
public class Solution {
    int i;
    int j;
    int len1;
    int len2;
    bool isDigit()
    {
        return s2[j]>='0' && s2[j]<='9';
    }
    int getNum()
    {
        int sum = 0;
        while(j<len2 && isDigit()) {
            sum *= 10;
            sum += (int)(s2[j] - '0');
            j++;
        }
        return sum;
    }
    string s1;
    string s2;
    public bool ValidWordAbbreviation(string word, string abbr) {
        s1 = word;
        s2 = abbr;
        len1 = s1.Length;
        len2 = s2.Length;
        i = 0;
        j = 0;
        for(; i<len1 && j<len2; ) {
            if (!isDigit()) {
                if (s1[i++] == s2[j++])
                    continue;
                else return false;
            }
            // spoiler: no starts with 0
            if (s2[j] == '0') return false;
            
            // num case
            int n = getNum();
            i += n;
        }
        return i==len1 && j==len2;
    }
}
