/*
In a string composed of 'L', 'R', and 'X' characters, like "RXXLRXRXL", a move consists of either replacing one occurrence of "XL" with "LX", or replacing one occurrence of "RX" with "XR". Given the starting string start and the ending string end, return True if and only if there exists a sequence of moves to transform one string to the other.
Example:
Input: start = "RXXLRXRXL", end = "XRLXXRRLX"
Output: True
Explanation:
We can transform start to end following these steps:
RXXLRXRXL ->
XRXLRXRXL ->
XRLXRXRXL ->
XRLXXRRXL ->
XRLXXRRLX
Note:
1 <= len(start) = len(end) <= 10000.
Both start and end will only consist of characters in {'L', 'R', 'X'}.
*/
// Comment: Initially just move pointer by 1 and try match even with swap.
// This failed with the following case (should return true) where the continuous X followed by L.
// As below, finding the first matching pair
//"XXXXXLXXXX"
//"LXXXXXXXXX"

public class Solution {
    
    void Swap()
    {
        if (i+1 >=len) return;
        char c1 = t[i];
        if (c1=='X') {
            // Try find the first L after X
            int j = i + 1;
            while(j<len && t[j] =='X') j++;
            if (j<len && t[j] == 'L') {
                t[i] = 'L';
                t[j]= 'X';
            }
        }
        else if (c1=='R') {
            // Try find the first X after R
            int j= i+1;
            while(j<len && t[j] == 'R') j++;
            if (j<len && t[j] == 'X') {
                t[i] = 'X';
                t[j] = 'R';
            }
        }
    }
    int len;
    char[] t;
    int i; // current index
    public bool CanTransform(string start, string end) {
        // Init data
        len = start.Length;
        if (len != end.Length) return false;
        
        return Perform(start, end);
    }
    
    bool Perform(string start, string end) {
        t = start.ToCharArray();

        for(i =0; i<len; i++) {
            char c = t[i];
            char d = end[i];
            if (c==d) continue;
            Swap();
            if (t[i] != end[i])
                return false;
        }
        return true;
    }
}
