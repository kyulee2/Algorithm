/*
An array is monotonic if it is either monotone increasing or monotone decreasing.
An array A is monotone increasing if for all i <= j, A[i] <= A[j].  An array A is monotone decreasing if for all i <= j, A[i] >= A[j].
Return true if and only if the given array A is monotonic.
 

Example 1:
Input: [1,2,2,3]
Output: true
Example 2:
Input: [6,5,4,4]
Output: true
Example 3:
Input: [1,3,2]
Output: false
Example 4:
Input: [1,2,4,5]
Output: true
Example 5:
Input: [1,1,1]
Output: true
 
Note:
1 <= A.length <= 50000
-100000 <= A[i] <= 100000
*/
// Comment: Easy. Use flag to track 3 stats.
public class Solution {
    public bool IsMonotonic(int[] A) {
        int len = A.Length;
        if (len<=1) return true;
        int flag = 0; // 0 non-determined, 1 increase, 2 decrease
        for(int i=1; i<len; i++) {
            int diff = A[i] - A[i-1];
            switch(flag) {
                case 0:
                    if (diff>0) flag = 1;
                    else if (diff<0) flag = 2;
                    break;
                case 1:
                    if (diff<0)
                        return false;
                    break;
                case 2:
                    if (diff>0)
                        return false;
                    break;
                default:
                    break;
            }
        }
        return true;
    }
}