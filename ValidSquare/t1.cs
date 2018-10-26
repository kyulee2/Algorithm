/*
Given the coordinates of four points in 2D space, return whether the four points could construct a square.

The coordinate (x,y) of a point is represented by an integer array with two integers.

Example:

Input: p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
Output: True
Note:

All the input integers are in the range [-10000, 10000].
A valid square has four equal sides with positive length and four equal angles (90-degree angles).
Input points have no order.
*/
// Comment: Bail out the same points.
public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        bool isSame(int[] a, int[] b) {
            return a[0]==b[0] && a[1]==b[1];
        }
        int dist(int[] a, int[] b) {
            return (a[0]-b[0])*(a[0]-b[0]) + (a[1]-b[1])*(a[1]-b[1]);
        }
        bool isValid(int[] a, int[] b, int[] c, int[] d) {
            int d1 = dist(a,b);
            int d2 = dist(a, c);
            int d3 = dist(a,d);
            return d1==d2 && (d1*2==d3) && dist(c,d) == d1;
        }
        if(isSame(p1,p2)||isSame(p1,p3)||isSame(p1,p4)||isSame(p2,p3)||isSame(p2,p4)||isSame(p3,p4))
            return false;
        return isValid(p1,p2,p3,p4) || isValid(p1,p2,p4,p3) || isValid(p1,p3,p4,p2);
    }
}

