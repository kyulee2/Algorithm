/*
Given a list of daily temperatures, produce a list that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. If there is no future day for which this is possible, put 0 instead.

For example, given the list temperatures = [73, 74, 75, 71, 69, 72, 76, 73], your output should be [1, 1, 4, 2, 1, 1, 0, 0].

Note: The length of temperatures will be in the range [1, 30000]. Each temperature will be an integer in the range [30, 100].
*/
// Comment: This problem is simlar to trapping water.
// Use a stack until height is ascending. By poping up all the prior locations, publish distance from the current index.

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int len = temperatures.Length;
        int[] t = temperatures;
        int[] ans = new int[len];
        Stack<int[]> s = new Stack<int[]>();
        if (len==0) return ans;
        s.Push(new int[]{t[0], 0});
        int i=1;
        for(; i<len ; i++) {
            while(s.Count > 0 && s.Peek()[0] < t[i]) {
                int[] j = s.Pop();
                ans[j[1]] = i-j[1];
            }
            s.Push(new int[]{t[i], i});
        }
        while(s.Count>0) {
            int[] j = s.Pop();
            ans[j[1]] = 0;
        }
        return ans;
    }
}

