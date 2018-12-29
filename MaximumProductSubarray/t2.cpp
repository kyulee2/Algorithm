/*
Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.
Example 1:
Input: [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.
Example 2:
Input: [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray
*/
// Comment: O(n). Don't forget once hit the zero, reset product. The max product is from either side or before/after 0.
class Solution {
public:
    int maxProduct(vector<int>& nums) {
        int len = nums.size();
        if (len==0)
            return 0;
        int ans = nums[0];
        int p = 1;
        // forward
        for(int i=0; i<len; i++) {
            p *= nums[i];
            ans = max(ans, p);
            if (p==0)
                p = 1;
        }
        // backward
        p = 1;
        for(int i=len-1; i>=0; i--) {
            p *= nums[i];
            ans = max(ans, p);
            if (p==0)
                p = 1;
        }
        return ans;
    }
};
