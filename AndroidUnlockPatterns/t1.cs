/*
Given an Android 3x3 key lock screen and two integers m and n, where 1 = m = n = 9, count the total number of unlock patterns of the Android lock screen, which consist of minimum of m keys and maximum n keys.
Rules for a valid pattern:
Each pattern must connect at least m keys and at most n keys.
All the keys must be distinct.
If the line connecting two consecutive keys in the pattern passes through any other keys, the other keys must have previously selected in the pattern. No jumps through non selected key is allowed.
The order of keys used matters.

 
Explanation:
| 1 | 2 | 3 |
| 4 | 5 | 6 |
| 7 | 8 | 9 |

Invalid move: 4 - 1 - 3 - 6 
Line 1 - 3 passes through key 2 which had not been selected in the pattern.
Invalid move: 4 - 1 - 9 - 2
Line 1 - 9 passes through key 5 which had not been selected in the pattern.
Valid move: 2 - 4 - 1 - 3 - 6
Line 1 - 3 is valid because it passes through key 2, which had been selected in the pattern
Valid move: 6 - 5 - 4 - 1 - 9 - 2
Line 1 - 9 is valid because it passes through key 5, which had been selected in the pattern.
Example:
Given m = 1, n = 1, return 9. 
*/
// Comment: Tricky. See cnt is updated in place
// Use skip table to coniser jump through visited number
public class Solution {
    public int NumberOfPatterns(int m, int n) {
        // Skip table
        var map = new int[10,10];        
        map[1,3] = 2;
        map[3,1] = 2;
        map[4,6] = 5;
        map[6,4] = 5;
        map[7,9] = 8;
        map[9,7] = 8;
        map[1,7] = 4;
        map[7,1] = 4;
        map[2,8] = 5;
        map[8,2] = 5;
        map[3,9] = 6;
        map[9,3] = 6;
        map[1,9] = 5;
        map[9,1] = 5;
        map[3,7] = 5;
        map[7,3] = 5;
        var visited = new bool[10];
        int Rec(int num, int depth, int cnt)
        {
            if (depth>=m)
                cnt++;
            depth++;
            if (depth>n)
                return cnt;            
            
            visited[num] = true;
            for(int next = 1; next<=9; next++) {
                if(!visited[next] && (map[num, next]==0 || visited[map[num,next]]))
                    cnt = Rec(next, depth, cnt);
            }
            visited[num] = false;
            return cnt;
        }
        // 1,3,7,9 are symmetric
        int ans = Rec(1, 1, 0) * 4;
        // 2,4,6,8 are symmetric
        ans += Rec(2, 1, 0) * 4;
        // 5
        ans += Rec(5, 1, 0);
        return ans;
	}
}
