/*
There is a list of sorted integers from 1 to n. Starting from left to right, remove the first number and every other number afterward until you reach the end of the list.

Repeat the previous step again, but this time from right to left, remove the right most number and every other number from the remaining numbers.

We keep repeating the steps again, alternating left to right and right to left, until a single number remains.

Find the last number that remains starting with a list of length n.

Example:

Input:
n = 9,
1 2 3 4 5 6 7 8 9
2 4 6 8
2 6
6

Output:
6
*/
// Comment: Consider start/end point with step only. Use utility function to compute such condition
public class Solution {
    public int LastRemaining(int n) {
        int getCnt(int i, int j, int step)
        {
            return (j-i)/step + 1;
        }
        int[] skip(int i, int j, int step, bool rev) {
            int cnt = getCnt(i,j,step);
            int start =i;
            int end = j;
            if (!rev) {
                if (cnt%2 == 1) {                
                    end -= step;
                } 
                start += step;
            } else {
                if (cnt%2 == 1) {
                    start += step;
                } 
                end -= step;                
            }
            return new int[]{start, end, step << 1};
        }
        
        int s = 1, e = n, t = 1;
        bool reverse = false;
        while(getCnt(s,e,t) > 1) {
            int[] var = skip(s,e,t, reverse);
            reverse = !reverse;
            s = var[0];
            e = var[1];
            t = var[2];
            
        }
        return s;
    }
}

