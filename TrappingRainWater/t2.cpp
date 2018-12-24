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
class Solution {
public:
    int trap(vector<int>& height) {
        stack<int> q;
        int s = 0;
        for(int  i=0; i<height.size(); i++) {
            auto h = height[i];
                int prevh = 0;
                while(q.size()!=0 && height[q.top()]<=h) {
                    int j = q.top();
                    q.pop();
                    int hj = height[j];
                    int width = i-j - 1;
                    int deltah = hj - prevh;
                    s += width * deltah;
                    prevh = hj;
                }
                // spoiler: handle the corner case, [4,2,3]
                if (q.size()>0 && height[q.top()] > h)
                {
                    s += (h - prevh) * (i - q.top()-1);
                }
                q.push(i);
        }
        
        return s;
    }
};

