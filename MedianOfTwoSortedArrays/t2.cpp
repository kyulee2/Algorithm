/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

You may assume nums1 and nums2 cannot be both empty.

Example 1:

nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:

nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5
*/
// Comment: Basically partition two arrays, i ,j: meet the two conditions
// i + j = len1-i + len2 - j  -- the length of two side sums are identical
// A[i-1]<=B[j] && B[j-1]<= A[i] -- the max of left of A is smaller than the min of right of B, and vice-versa
// i is 0 ~ len1 j= halflength - i. try to find such split point by doing binary search
// A[i-1]>B[j] (i>0) -- i is too big, decreae i (search left)
// A[i] < B[j-1] (i<len-1) -- i is too small, increae i (search right)
// otherwise, meet the condition. Handle special case when i = 0/j=0/i=len1/j=len1
// For odd count, max of left, for even count, (max of left + min of right) /2
// Time complexity: O(log (min(len1, len2)))
class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        int len1 = nums1.size();
        int len2 = nums2.size();
        if (len1>len2) return findMedianSortedArrays(nums2, nums1);
        
        // i+j == len1-i + len2-j
        int half = (len1+len2+1)/2;
        int mini = 0, maxi = len1; // 0~len1. find i, j until a[i-1]<=b[j] && b[j-1]<= a[i]
        while(mini<=maxi) {
            int i= (maxi-mini)/2 + mini;
            int j = half - i;
            if (i>0 && nums1[i-1] >nums2[j]) {// i is too big
                maxi = i-1;
            } else if (i<len1 && nums2[j-1]> nums1[i]) { /* spoiler: not j>0, but check i<len1 */
                mini = i + 1;
            } else { // corner case: i==0, or i==len1, or else above cases.
                int maxleft = 0;
                if (i==0)
                    maxleft = nums2[j-1];
                else if (j==0)
                    maxleft = nums1[i-1];
                else maxleft = max(nums1[i-1], nums2[j-1]);
                
                // When odd elements, return max of left;
                if ((len1+len2)%2!=0)
                    return (double)maxleft;
                
                int minright = 0;
                if (i==len1)
                    minright = nums2[j];
                else if (j==len2)
                    minright = nums1[i];
                else minright = min(nums1[i], nums2[j]);
                
                return (double)(maxleft + minright) / 2;
            }
        }
        
        return 0.0;
    }
};