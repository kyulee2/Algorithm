/*
Given an array of citations sorted in ascending order (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.
According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N - h papers have no more than h citations each."
Example:
Input: citations = [0,1,3,5,6]
Output: 3 
Explanation: [0,1,3,5,6] means the researcher has 5 papers in total and each of them had 
             received 0, 1, 3, 5, 6 citations respectively. 
             Since the researcher has 3 papers with at least 3 citations each and the remaining 
             two with no more than 3 citations each, her h-index is 3.
Note:
If there are several possible values for h, the maximum one is taken as the h-index.
Follow up:
This is a follow up problem to H-Index, where citations is now guaranteed to be sorted in ascending order.
Could you solve it in logarithmic time complexity?
*/
// Comment: See below comment and example. answer should be recorded as the number of papers, n
// which will gurantee at least h citations.
// [0,1,4,5,6] => 3 is h index. At index 2, citation is 4, the number of papers are 5-2 = 3.
public class Solution {
    public int HIndex(int[] citations) {
        int len = citations.Length;
        int i =0, j = len -1;
        int ans = 0;
        while(i<=j) {
            int mid = i + (j-i)/2;
            int n = len - mid;
            var h = citations[mid];
            if (h == n)
                return n;
            else if (h < n) {
                i = mid + 1;
            } else { // h>n
                ans = n; // spoiler: not h but n. n paper has at least h citation -- [0,1,4,5,6] => 3 papers has at least 3 citations.
                j = mid - 1;
            }
        }
        return ans;
    }
}
