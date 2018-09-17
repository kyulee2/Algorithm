/*
You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move consists of turning one wheel one slot. 
The lock initially starts at '0000', a string representing the state of the 4 wheels. 
You are given a list of deadends dead ends, meaning if the lock displays any of these codes, the wheels of the lock will stop turning and you will be unable to open it. 
Given a target representing the value of the wheels that will unlock the lock, return the minimum total number of turns required to open the lock, or -1 if it is impossible. 
Example 1:
Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
Output: 6
Explanation:
A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
because the wheels of the lock become stuck after the display becomes the dead end "0102".

Example 2:
Input: deadends = ["8888"], target = "0009"
Output: 1
Explanation:
We can turn the last wheel in reverse to move from "0000" -> "0009".

Example 3:
Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
Output: -1
Explanation:
We can't reach the target without getting stuck.

Example 4:
Input: deadends = ["0000"], target = "8888"
Output: -1

Note:
The length of deadends will be in the range [1, 500].
target will not be in the list deadends.
Every string in deadends and the string target will be a string of 4 digits from the 10,000 possibilities '0000' to '9999'.
*/
// Comment: Initially I thought a better solution since the next move would be any +1/-1 for each of 4 wheels.
// It's simply BFS with visited set to avoid duplication.
// O(A^N + D) where A is the number of digits in our alphabet, N is the number of digits in the lock, and D is the size of deadends.
public class Solution {
    public int OpenLock(string[] deadends, string target) {
        var set = new HashSet<string>(deadends);
        var q = new Queue<Tuple<string,int>>();
        var visited = new HashSet<string>();
        q.Enqueue(new Tuple<string, int>("0000", 0));
        while(q.Count > 0) {
            var n = q.Dequeue();
            var curr = n.Item1;
            var dist = n.Item2;
            if (set.Contains(curr))
                continue;
            if (visited.Contains(curr))
                continue;
            visited.Add(curr);
            if (curr==target)
                return dist;
            
            var t = curr.ToCharArray();
            for(int i=0; i<4; i++) {
                var c = t[i];
                var bc = c=='0' ? '9' : (char)(c - 1);
                t[i] = bc;
                q.Enqueue(new Tuple<string,int>(new String(t), dist + 1));
                var ac = c=='9' ? '0' : (char)(c + 1);
                t[i] = ac;
                q.Enqueue(new Tuple<string,int>(new String(t), dist + 1));
                // restore
                t[i] = c;
            }
        }
        
        return -1;
    }
}