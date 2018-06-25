/*
Find the total area covered by two rectilinear rectangles in a 2D plane.
Each rectangle is defined by its bottom left corner and top right corner as shown in the figure.

Example:
Input: A = -3, B = 0, C = 3, D = 4, E = 0, F = -1, G = 9, H = 2
Output: 45
Note:
Assume that the total area is never beyond the maximum possible value of int.
*/
public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        int S1 = (C-A) * (D-B);
        int S2 = (G-E) * (H-F);
        int S = S1+S2;
        // Check non overlap first to bail out
        if (E>=C || A>=G || B>=H || F>=D)
            return S;
        int left = Math.Max(A,E);
        int right = Math.Min(C,G);
        int up = Math.Min(D, H);
        int down = Math.Max(B, F);
        int common = (right-left) * (up - down);
        return S - common;
    }
}

