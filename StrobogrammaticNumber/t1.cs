/*
A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
Write a function to determine if a number is strobogrammatic. The number is represented as a string.
Example 1:
Input:  "69"
Output: true
Example 2:
Input:  "88"
Output: true
Example 3:
Input:  "962"
Output: false
*/
// Comment: Striaghtforward
public class Solution {
    public bool IsStrobogrammatic(string num) {
        // 6 - 9
        // 0, 1, 8
        int len = num.Length;
        int i =0, j=len-1;
        while(i<j) {
            char l = num[i];
            char r = num[j];
            switch(l) {
                case '0':
                case '8':
                case '1':
                    if (r != l)
                        return false;
                    break;
                case '6':
                    if (r!= '9') return false;
                    break;
                case '9':
                    if (r!='6') return false;
                    break;
                default:
                    return false;
            }
            i++;
            j--;
        }
        if (i==j) {
            char c= num[i];
            if (c=='1' || c=='8' || c=='0')
                return true;
            return false;
        }
        return true;
    }
}