/*
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!
Example:
Input: [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
*/
// Comment: Use a stack that has height/index. When stepping down, push it into stack.
// When stepping up, poping up stack and compute area by width (i - n[1] - 1) * (height(n[0])-LastLevel)
// Should track the lastLevel
// The spoiler is the last element where the remaining stack element is higher than current height.
// Should add up with width (i-peek()n[1] - 1) * height ( h - lastLevel)
public class Solution {
    public int Trap(int[] height) {
        Stack<int[]> s = new Stack<int[]>();
        int len = height.Length;
        int sum = 0;
        for(int i=0; i<len ; i++) {
            int h = height[i];
            if (s.Count == 0 || s.Peek()[0] > h)
                s.Push(new int[]{h, i});
            else {
                int lastLevel = 0;
                while(s.Count >0 && s.Peek()[0] <=h) {
                    int[] n = s.Pop();
                    sum += (n[0] -lastLevel) * (i - n[1] - 1);
                    lastLevel = n[0];
                }
                // Spoiler: Handle the corner case,e.g., 4, 2, 3
                // Consider the current height 
                if (s.Count>0 && s.Peek()[0] > h)
                {
                    sum += (h - lastLevel) * (i - s.Peek()[1] - 1);
                }
                s.Push(new int[]{h, i});
            }
        }
        return sum;
    }
}

