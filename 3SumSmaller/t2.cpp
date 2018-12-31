Given an array of n integers nums and a target, find the number of index triplets i, j, k with 0 <= i < j < k < n that satisfy the condition nums[i] + nums[j] + nums[k] < target.

Example:

Input: nums = [-2,0,1,3], and target = 2
Output: 2 
Explanation: Because there are two triplets which sums are less than 2:
             [-2,0,1]
             [-2,0,3]
Follow up: Could you solve it in O(n2) runtime?

// Comment: Don't be confused by the i,j,k condition above.
// It's not meant for ordering, but simply saying distinct element.
// This problem is similar to this: Given sorted array, find two sum is less than a target?
// Hint. use two pointer (start,end)
class Solution {
public:
    int threeSumSmaller(vector<int>& nums, int target) {
        sort(nums.begin(), nums.end());
        int ans = 0;
        int len = nums.size();
        for(int i=0; i<len-2; i++) {
            int j= i+1, k=len-1;
            while(j<k) {
                int s = nums[i] + nums[j] + nums[k];
                if (s>= target)
                    k--;
                else {
                    ans += (k-j);
                    j++;
                }
            }
        }
        return ans;
    }
};
