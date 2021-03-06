/*
Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

Note:

The number of elements initialized in nums1 and nums2 are m and n respectively.
You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
Example:

Input:
nums1 = [1,2,3,0,0,0], m = 3
nums2 = [2,5,6],       n = 3

Output: [1,2,2,3,5,6]
*/
// Comment: Fill from the end to sort in place
public class Solution {
    /* Using extra space */
    /*
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var ans = new int[m+n];
        int i=0, j=0, k=0;
        while(i<m && j<n) {
            if (nums1[i]<nums2[j]) {
                ans[k++] = nums1[i++];
            } else {
                ans[k++] = nums2[j++];
            }
        }
        while(i<m) ans[k++] = nums1[i++];
        while(j<n) ans[k++] = nums2[j++];
        Array.Copy(ans, nums1, m+n);
    }
    */
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int i=m-1, j=n-1, k=m+n-1;
        while(i>=0 && j>=0)
            if (nums1[i]>nums2[j])
                nums1[k--] = nums1[i--];
            else
                nums1[k--] = nums2[j--];
        while(i>=0) nums1[k--] = nums1[i--];
        while(j>=0) nums1[k--] = nums2[j--];
    }
}


