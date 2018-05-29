/*
Given a string, your task is to count how many palindromic substrings in this string. 
The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters. 
Example 1:
Input: "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".

Example 2:
Input: "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".

Note:
The input string length won't exceed 1000.
*/
// Comment: The key point is to consider single or double center.
// Don't forget adding 'j' below within while loop.

public class Solution {
    void AddPalSingle(int i)
    {
        ans++;
        int j =1;
        while(i-j >=0 && i + j <len) {
            if (str[i-j] != str[i+j])
                break;
            ans++;
            j++;
        }
    }
     void AddPalDouble(int i)
    {
        if(i+1 >= len) return;
        if (str[i] != str[i+1])
            return;
        ans++;
        int j =1;
        while(i-j >=0 && i + j  + 1 <len) {
            if (str[i-j] != str[i+j+1])
                break;
            ans++;
            j++;
        }
    }
    
    int ans ;
    string str;
    int len;
    public int CountSubstrings(string s) {
        ans = 0;
        len = s.Length;
        str = s;
        for(int i=0; i<len; i++) {
            AddPalSingle(i);
            AddPalDouble(i);
        }
        return ans;
    }
}

