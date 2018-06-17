/*
You are given a string representing an attendance record for a student. The record only contains the following three characters:
'A' : Absent.
'L' : Late.
'P' : Present.
A student could be rewarded if his attendance record doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).

You need to return whether the student could be rewarded according to his attendance record.

Example 1:
Input: "PPALLP"
Output: True
Example 2:
Input: "PPALLL"
Output: False
*/
// Comment: Easy. Not worth
public class Solution {
    public bool CheckRecord(string s) {
        int len = s.Length;
        int a = 0;
        for(int i = 0 ; i<len; i++) {
            // check a
            char c = s[i];
            if (c=='A') {
                a++;
                if (a>1)
                    return false;
                continue;
            }
            // check l
            int l = 0;
            while(i<len && s[i] == 'L') {
                i++; l++;
            }
            if (l>0) {
                if (l>2)
                    return false;
                i--; // restore i
            }
        }
        return true;
    }
}

