/*
Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array. 
Formally the function should:
Return true if there exists i, j, k 
such that a[i] < a[j] < a[k] given 0<= i<j<k<=n-1
else return false

Your algorithm should run in O(n) time complexity and O(1) space complexity. 
Examples:
Given [1, 2, 3, 4, 5],
return true. 
Given [5, 4, 3, 2, 1],
return false. 

// Comment: This is simple but quite interesting
// Try to find the two of minimal. This is cleaner and simpler than t1.cs
class Solution {
public:
    bool increasingTriplet(vector<int>& nums) {
        int len = nums.size();
        if (len<3) return false;
        int min1 = nums[0];
        int min2 = INT_MAX;
        for(int i=1; i<len; i++) {
            int n = nums[i];
            if (n>min1 && n>min2)
                return true;
            if (n<=min2 && n>min1) {
                min2 = n;
            } else if (n<=min1) {
                min1 = n;
            }
        }
        return false;
    }
};
