/*
Given a string s, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation.

Example 1:

Input: "aacecaaa"
Output: "aaacecaaa"
Example 2:

Input: "abcd"
Output: "dcbabcd"
*/ 
// Commnent: Hard tag, but seems not. But maybe a better one.
// The below is try to remove the end char, and to see if we can make palindrom from it.
// If so, prepend the removed char in the revese way to the original string
// The below is O(n^2). The better solution should be O(n) with KMP
class Solution {
public:
    string str;
    bool isPalindrome(int i, int j)
    {
        while(i<j) {
            if (str[i]!=str[j])
                return false;
            i++; j--;
        }
        return true;
    }
    string shortestPalindrome(string s) {
        str = s;
        int len = s.length();
        int i = len-1;
        for(; i>0; i--) {
            if (isPalindrome(0, i))
                break;
        }
        string post = s.substr(i+1);
        reverse(post.begin(), post.end());
        return post + s;
    }
};
