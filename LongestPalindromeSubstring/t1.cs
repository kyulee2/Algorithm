/*
Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
Example 1:
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.
Example 2:
Input: "cbbd"
Output: "bb"
*/
// Comment: Can be solved using a DP. The below is use odd/even expansion.
// Be carefule about substring index calculation.
// It's O(n^2) time with O(1) space.
public class Solution {
    public string LongestPalindrome(string s) {
        int count = s.Length;
        string getMaxOdd(int i)
        {
            int len = 1;
            int c = i;
            int j = i+1; 
            i--;
            while(i>=0 && j<count && s[i] == s[j]) {
                len += 2;
                i--; j++;
            }
            return s.Substring(c-(len-1)/2, len);
        }
        string getMaxEven(int i)
        {
            int len = 0;
            int c = i;
            int j = i+1; 
            while(i>=0 && j<count && s[i] == s[j]) {
                len += 2;
                i--; j++;
            }
            return len==0 ? "" : s.Substring(c-(len-2)/2, len);       
        }
        
        string ans = "";
        for(int i=0; i<count; i++) {
            var s1 = getMaxOdd(i);
            var s2 = getMaxEven(i);
            if (s1.Length > ans.Length)
                ans = s1;
            if (s2.Length > ans.Length)
                ans = s2;
        }
        return ans;
    }
}
