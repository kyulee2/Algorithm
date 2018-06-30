/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.



Example:

Input: "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
Note:

Although the above answer is in lexicographical order, your answer could be in any order you want.
*/
// Comment: Straightforward. See early bail-out below

public class Solution {
    public IList<string> LetterCombinations(string digits) {
        String[] map = new String[]{"","", "abc","def","ghi","jkl","mno","pqrs","tuv", "wxyz"};
        int len = digits.Length;
        List<string> ans = new List<string>();
        if (len==0) return ans;// early bail-out
        void Rec(int i, string s) {
            if (i==len) {
                ans.Add(s);
                return;
            }
            int idx = (int)(digits[i] -'0');
            foreach(var c in map[idx])
                Rec(i+1, s + c);
        }
        
        Rec(0,"");
        return ans;
    }
}

