/*
Given a non-negative integer, you could swap two digits at most once to get the maximum valued number. Return the maximum valued number you could get.

Example 1:
Input: 2736
Output: 7236
Explanation: Swap the number 2 and the number 7.
Example 2:
Input: 9973
Output: 9973
Explanation: No swap.
Note:
The given number is in the range [0, 108]
*/
// Comment: Greedy. Find the larger digit that occurs at the later index.
// Use a map/array to bookeep the last index for digit occurence.
// Since we're comparing digit which ranges 0~9, don't need to do binary search, etc. Just use count.
// O(n) time and O(10) constant memory where n is # of digit.
public class Solution {
    public int MaximumSwap(int num) {
        var s = num.ToString().ToCharArray();
        var map = new int[10]; // last index of digit occurrence
        int len = s.Length;
        // Build map
        for(int i=0; i<len; i++)
            map[s[i]-'0'] = i;
        
        // try to replace larger digit that occurs at later index
        for(int i=0; i<s.Length; i++) {
            char c = s[i];
            for(char d = '9'; d > c; d--) {
                if (map[d-'0'] > i) {
                    int j = map[d-'0'];
                    var t = s[i];
                    s[i] = s[j];
                    s[j] = t;
                    return Convert.ToInt32(new String(s));
                }
            }
        }
        
        return num;
    }
}
