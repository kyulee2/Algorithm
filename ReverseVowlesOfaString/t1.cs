/*
Write a function that takes a string as input and reverse only the vowels of a string.
Example 1:
Given s = "hello", return "holle". 
Example 2:
Given s = "leetcode", return "leotcede". 
Note:
The vowels does not include the letter "y". 
*/
// Comment: Don't forget covering capital/lower cases.
// If we do this in place (c++/c), we can traverse from two ends, i, j respectively
// until a vowel is found. Then swap in place.
public class Solution {
    bool isVowel(char c1) {
        // Ensure conver it to lower to check vowel all cases.
        char c = Char.ToLower(c1);
        return c=='a' || c=='e' || c=='i' || c=='o' || c=='u';
    }
    public string ReverseVowels(string s) {
        StringBuilder b1 = new StringBuilder();
        for(int i=s.Length-1; i>=0 ; --i)
            if (isVowel(s[i]))
                b1.Append(s[i]);
        StringBuilder b = new StringBuilder();
        for (int i=0, j=0; i<s.Length; ++i)
            if (isVowel(s[i]))
                b.Append(b1[j++]);
            else b.Append(s[i]);
        return b.ToString();
    }
}
