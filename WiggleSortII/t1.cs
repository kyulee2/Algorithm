/*
Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....

Example 1:

Input: nums = [1, 5, 1, 1, 6, 4]
Output: One possible answer is [1, 4, 1, 5, 1, 6].
Example 2:

Input: nums = [1, 3, 2, 2, 3, 1]
Output: One possible answer is [2, 3, 1, 3, 1, 2].
Note:
You may assume all input has valid answer.

Follow Up:
Can you do it in O(n) time and/or in-place with O(1) extra space?
*/
// Comment: partition to find median value
// Then 3 way sort assigning large first. Introduce virtual index to assign
// 1, 3, 5..., 0, 2, 4...
public class Solution {
    public void WiggleSort(int[] nums) {
        int len = nums.Length;
        int partition(int i, int j)
        {
            int last = j;
            int p = nums[j];
            while(i<j) {
                if (nums[i]<p) {
                    i++;
                    continue;
                }
                if (nums[--j]>=p) continue;
                // swap
                var t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
            }
            // swap
            var tt = nums[i];
            nums[i] = p;
            nums[last] = tt;
            return i;
        }
        
        int start = 0, end = len-1;
        int q = 0; // spoiler: Init with 0 that might be itself
        // Find median
        while( start < end) {
            q = partition(start, end);
            if (q==len/2) break;
            else if (q < len/2)
                start = q+1;
            else if (q>len/2)
                end = q - 1;
        }
        
        // (reversed) 3 way partition with virtual index
        // Large - Middle -Small
        int index(int idx) {
            int n = idx * 2  + 1;
            return n % (len|1);
            // 1,3,5,7,... 0, 2, 4, ...
        }
        
        // 0 1 2 3 4 5
        // 1 3 5 7 9 11
        // 1 3 5 7%7 =0 9%7 =2 11%7 = 4
        // Allocate/assign Large element first to  1 3 5 
        // then small element later to 0 2 4
        int x =0, y=0, k= len-1;
        int mid = nums[q];
        while(y<=k) {
            if (nums[index(y)]>mid) {
                var tt = nums[index(y)];
                nums[index(y)] = nums[index(x)];
                nums[index(x)] = tt;
                x++; y++;
            } else if (nums[index(y)]<mid) {
                var tt = nums[index(y)];
                nums[index(y)] = nums[index(k)];
                nums[index(k)] = tt;
                k--;                
            } else {
                y++;
            }
        }
    }
}
