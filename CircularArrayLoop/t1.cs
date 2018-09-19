/*
You are given an array of positive and negative integers. If a number n at an index is positive, then move forward n steps. Conversely, if it's negative (-n), move backward n steps. Assume the first element of the array is forward next to the last element, and the last element is backward next to the first element. Determine if there is a loop in this array. A loop starts and ends at a particular index with more than 1 element along the loop. The loop must be "forward" or "backward'.

Example 1: Given the array [2, -1, 1, 2, 2], there is a loop, from index 0 -> 2 -> 3 -> 0.

Example 2: Given the array [-1, 2], there is no loop.

Note: The given array is guaranteed to contain no element "0".

Can you do it in O(n) time complexity and O(1) space complexity?
*/
// Comment: The key is to sum of index should be len or -len.
// The first one: O(n) for both time and spacec class Solution
{
    public bool CircularArrayLoop(int[] nums)
    {
        int len = nums.Length;
        // Spoiler:
        if (len<=1)
            return false;
        
        int cnt = 0;
        bool[] visited = new bool[len];
        for(int j=0; j<len ;j++) {
            int i = j;
            int sum = 0;
            while(sum <len && sum >-len && !visited[i])
            {
                visited[i] = true;
                sum += nums[i];
                i += nums[i];
                if (i >= len) i %= len;
                else if (i <0)
                    i += len;
            }
            if (sum == len)
                return true;
        }
        
        return false;
    }
}
// Comment: The blow is O(n) time and O(1) space
public class Solution
{
    public bool CircularArrayLoop(int[] nums)
    {
        int len = nums.Length;
        // Spoiler:
        if (len<=1)
            return false;
        
        int cnt = 0;
        //bool[] visited = new bool[len];
        for(int j=0; j<len ;j++) {
            int i = j;
            int sum = 0;
            while(sum <len && sum >-len && nums[i]!=0)
            {
                var k = nums[i]; // spoiler: keep it before flush it to zero
                nums[i] = 0; // for checking visited

                sum += k;
                i += k;
                if (i >= len) i %= len;
                else if (i <0)
                    i += len;
            }
            if (sum == len)
                return true;
        }
        
        return false;
    }
}

