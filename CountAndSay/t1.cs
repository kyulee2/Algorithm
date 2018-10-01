/*
The count-and-say sequence is the sequence of integers with the first five terms as following:
1.     1
2.     11
3.     21
4.     1211
5.     111221
1 is read off as "one 1" or 11.
11 is read off as "two 1s" or 21.
21 is read off as "one 2, then one 1" or 1211.
Given an integer n where 1 = n = 30, generate the nth term of the count-and-say sequence.
Note: Each term of the sequence of integers will be represented as a string.
 
Example 1:
Input: 1
Output: "1"
Example 2:
Input: 4
Output: "1211"
*/
// Comment: O(nm) where m is the previous length
public class Solution {
    public string CountAndSay(int n) {
        string next(string str)
        {
            StringBuilder b = new StringBuilder();
            var c = str[0];
            var d = 1;
            for(int i=1; i<=str.Length; i++) {
                if (i==str.Length || str[i] != c) {
                    b.Append(d);
                    b.Append(c);
                    if (i!=str.Length) {
                        c = str[i];
                        d = 1;
                    }
                } else {
                    d++;
                }
            }
            return b.ToString();
        }
        string s = "1";
        for(int i=1; i<n; i++) {
            s = next(s);
        }
        return s;
    }
}