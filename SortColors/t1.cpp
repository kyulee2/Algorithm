/*
Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.
Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
Note: You are not suppose to use the library's sort function for this problem.
Example:
Input: [2,0,2,1,1,0]
Output: [0,0,1,1,2,2]
Follow up:
A rather straight forward solution is a two-pass algorithm using counting sort.
First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
Could you come up with a one-pass algorithm using only constant space?
*/
// Comment: 1) Consider how to push back the larger element to the later index
// 2) Pick the middle value to compare before and after element
class Solution {
public:
    void sortColors(vector<int>& nums) {
        int i, j, k;
        int len = nums.size();
        i=0; j=0; k=len-1;
        while(j<=k) {
            if (nums[i]==2) { // push back the largest at i to end
                auto t = nums[k];
                nums[k] = nums[i];
                nums[i] = t;
                k--;
            } else if (nums[j] ==2) { // push back the largest at j to end
                auto t = nums[k];
                nums[k] = nums[j];
                nums[j] = t;
                k--;
            } else if (nums[i]==1) { // push back the second largest at i to j
                auto t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
                j++;               
            } else { // == 0    // move i (and j) -- nums[i] == 0
                if (i==j) j++;   // the check is needed
                i++;
            }
        }
    }
};

// 2) This is concise but a bit less intuitive to come up with initially.
public class Solution {
    public void SortColors(int[] nums) {
        int i=0, j=0, k=nums.Length-1;
        while(j<=k) { // Spoiler: j "<=" k
            if (nums[j]==0) {
                var t = nums[j];
                nums[j] = nums[i];
                nums[i] = t;
                i++; // unlike the above, just increse without check.
                j++;
            }
            else if (nums[j]==2) {
                var t = nums[k];
                nums[k] = nums[j];
                nums[j] = t;
                k--;
            } else 
                j++;
        }
    }
}