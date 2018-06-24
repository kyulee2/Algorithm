/*
Given an array of characters, compress it in-place.

The length after compression must always be smaller than or equal to the original array.

Every element of the array should be a character (not int) of length 1.

After you are done modifying the input array in-place, return the new length of the array.


Follow up:
Could you solve it using only O(1) extra space?


Example 1:
Input:
["a","a","b","b","c","c","c"]

Output:
Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]

Explanation:
"aa" is replaced by "a2". "bb" is replaced by "b2". "ccc" is replaced by "c3".
Example 2:
Input:
["a"]

Output:
Return 1, and the first 1 characters of the input array should be: ["a"]

Explanation:
Nothing is replaced.
Example 3:
Input:
["a","b","b","b","b","b","b","b","b","b","b","b","b"]

Output:
Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].

Explanation:
Since the character "a" does not repeat, it is not compressed. "bbbbbbbbbbbb" is replaced by "b12".
Notice each digit has it's own entry in the array.
Note:
All characters have an ASCII value in [35, 126].
1 <= len(chars) <= 1000.
*/
// Comment: Straightfowrad. Just be careful with int to char conversion without library.
public class Solution {
    public int Compress(char[] chars) {
        int i = 0, j=0;
        int len = chars.Length;
        int getCount()
        {
            char c = chars[i];
            int cnt = 0;
            while(i<len && c == chars[i]) {
                i++; cnt++;
            }
            return cnt;
        }
        void write(char c, int cnt)
        {
            chars[j++] = c;
            if (cnt==1) return;
            int n = cnt;
            int p = 1;
            while(n/10 > 0) {
                p *= 10;
                n/=10;
            }
            while(p>0) {
                int d = cnt / p;
                chars[j++] = (char)('0' + d);
                cnt %= p;
                p /= 10;
            }
        }
        
        while(i<len) {
            char c = chars[i];
            int cnt = getCount();
            write(c, cnt);
        }
        
        return j;   
    }
}

