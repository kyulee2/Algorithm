/*
A binary watch has 4 LEDs on the top which represent the hours (0-11), and the 6 LEDs on the bottom represent the minutes (0-59).

Each LED represents a zero or one, with the least significant bit on the right.


For example, the above binary watch reads "3:25".

Given a non-negative integer n which represents the number of LEDs that are currently on, return all possible times the watch could represent.

Example:

Input: n = 1
Return: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16", "0:32"]
Note:
The order of output does not matter.
The hour must not contain a leading zero, for example "01:00" is not valid, it should be "1:00".
The minute must be consist of two digits and may contain a leading zero, for example "10:2" is not valid, it should be "10:02".
*/
// Comment: Should avoid duplication using HashSet. Could be better way to avoid this
public class Solution {
    HashSet<string> ans;
    int len;
    int[] hours;
    int[] mins;
    bool[] hvisited;
    bool[] mvisited;

    string output(int h, int m)
    {
        StringBuilder b = new StringBuilder();
        b.Append(h);
        b.Append(':');
        if (m<10)
            b.Append('0');
        b.Append(m);
        return b.ToString();
    }
    
    bool isValid(int h, int m)
    {
        if (h>11) return false;
        if (m>59) return false;
        return true;
    }
    
    void Rec(int h, int m, int n)
    {
        if (!isValid(h,m))
            return;
        
        if (n==len) {
            ans.Add(output(h,m));
            return;
        }

        for(int i=0; i<hours.Length; i++)
        {
            if (hvisited[i]) continue;
            hvisited[i] = true;
            Rec(h + hours[i], m, n+1);
            hvisited[i] = false;
        }
        
        for(int i=0; i<mins.Length; i++)
        {
            if (mvisited[i]) continue;
            mvisited[i] = true;
            Rec(h, m+mins[i], n+1);
            mvisited[i] = false;
        }

        
    }
    public IList<string> ReadBinaryWatch(int num) {
        // Initialize data
        len = num;
        ans = new HashSet<string>();
        hours = new int[] {1,2,4,8};
        mins = new int[]{1,2,4,8,16,32};
        hvisited = new bool[hours.Length];
        mvisited = new bool[mins.Length];

        // Main recursion
        Rec(0, 0, 0);
        
        return ans.ToList();
    }
}

