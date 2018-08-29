/*
Compare two version numbers version1 and version2.
If version1 > version2 return 1; if version1 < version2 return -1;otherwise return 0.

You may assume that the version strings are non-empty and contain only digits and the . character.
The . character does not represent a decimal point and is used to separate number sequences.
For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

Example 1:

Input: version1 = "0.1", version2 = "1.1"
Output: -1
Example 2:

Input: version1 = "1.0.1", version2 = "1"
Output: 1
Example 3:

Input: version1 = "7.5.2.4", version2 = "7.5.3"
Output: -1
*/
// Comment: Straightforward. One gotcha about "1" vs "1.0"
// Only when two strings are empty, return 0. Otherwise assume number for empty string is 0.
public class Solution {
    public int CompareVersion(string version1, string version2) {
        if (version1=="" && version2=="") return 0;
        
        int idx = -1;
        int num1 = 0, num2 = 0;
        if (version1 != "") {
        if ((idx=version1.IndexOf('.'))!=-1) {
            num1 = Convert.ToInt32(version1.Substring(0, idx));
            version1 = version1.Substring(idx+1);
        } else {
            num1 = Convert.ToInt32(version1);
            version1 = "";
        }
        }

        if (version2 != "") {        
        if ((idx=version2.IndexOf('.'))!=-1) {
            num2 = Convert.ToInt32(version2.Substring(0, idx));
            version2 = version2.Substring(idx+1);
        } else {
            num2 = Convert.ToInt32(version2);
            version2 = "";
        }
        }
        
        if (num1<num2) return -1;
        else if (num1>num2) return 1;
        return CompareVersion(version1, version2);
    }
}
