/*
Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.

Example 1:

Input: S = "ab#c", T = "ad#c"
Output: true
Explanation: Both S and T become "ac".
Example 2:

Input: S = "ab##", T = "c#d#"
Output: true
Explanation: Both S and T become "".
Example 3:

Input: S = "a##c", T = "#a#c"
Output: true
Explanation: Both S and T become "c".
Example 4:

Input: S = "a#c", T = "b"
Output: false
Explanation: S becomes "c" while T becomes "b".
Note:

1 <= S.length <= 200
1 <= T.length <= 200
S and T only contain lowercase letters and '#' characters.
Follow up:

Can you solve it in O(N) time and O(1) space?
*/
// Comment: The below uses O(1) space using backward scanning.
// Two spoilers below.
// 1. During the deletion of char, handle another '#'. 
// 2. Handle the last (first index) remaining string.
public class Solution {
    // return index for the next char which won't be deleted
    int findNext(string s, int idx)
    {
        while(idx>=0 && s[idx] == '#') {
            int i = idx;
            while(i>=0 && s[i] == '#') --i;
            if (i<0) return -1;
            int cnt = idx - i; // number of #
            
            // Spoiler1: Consume/delete char
            while(i>=0 && cnt>0) {
                if (s[i] != '#')
                    cnt--;
                else
                    // Found another # during the deletion
                    cnt++;
                i--;
            }
            idx = i;
        }
        return idx;
    }
    
    public bool BackspaceCompare(string S, string T) {
        int i = S.Length-1;
        int j = T.Length-1;
        while(i>=0 && j>=0) {
            i = findNext(S, i);
            j = findNext(T, j);
            if (i<0 || j<0)
                break;
            if (S[i] != T[j])
                return false;
            --i; --j;
        }
        
        // Spoiler2: delete the first/remaining delete e.g, "nz" vs "b#nz"
        if (i>=0) i = findNext(S,i);
        if (j>=0) j = findNext(T,j);

        return i<0 && j<0;
    }
}


