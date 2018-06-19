/*
Given a word, you need to judge whether the usage of capitals in it is right or not. 
We define the usage of capitals in a word to be right when one of the following cases holds: 
All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital if it has more than one letter, like "Google".
Otherwise, we define that this word doesn't use capitals in a right way. 

Example 1:
Input: "USA"
Output: True

Example 2:
Input: "FlaG"
Output: False

Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters. 
*/
// Comment: Not much interesting.
public class Solution {
    public bool DetectCapitalUse(string word) {
        int len = word.Length;
        int c = 0, l = 0;
        foreach(var ch in word)
            if (ch>='A' && ch<='Z') c++;
            else l++;
        if (len == c)
            return true;
        if (len==l)
            return true;
        if (c==1 && word[0]>='A' && word[0]<='Z')
            return true;
        return false;
    }
}

