/*
Alice has a hand of cards, given as an array of integers.
Now she wants to rearrange the cards into groups so that each group is size W, and consists of W consecutive cards.
Return true if and only if she can.
 

Example 1:
Input: hand = [1,2,3,6,2,3,4,7,8], W = 3
Output: true
Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8].
Example 2:
Input: hand = [1,2,3,4,5], W = 4
Output: false
Explanation: Alice's hand can't be rearranged into groups of 4.
 
Note:
1 <= hand.length <= 10000
0 <= hand[i] <= 10^9
1 <= W <= hand.length
*/
// Comment: Build map with num to cnt.
// Sort a list from keys of the map.
// While grouping W backward of list -- subtracting count in map and removing keys.
// As soon as the condition doesn't hold, it returns false. Otherwise, returns true with empty keys/map.
public class Solution {
    public bool IsNStraightHand(int[] hand, int W) {
        // build map - num : cnt
        int cnt = 0;
        var map = new Dictionary<int, int>();
        foreach(var h in hand) {
            cnt++;
            if (!map.ContainsKey(h))
                map[h] = 0;
            ++map[h];
        }
        if (cnt%W != 0)
            return false;

        var l = map.Keys.ToList();
        l.Sort();
        
        // Count from reverse to delete list with O(1)
        while(l.Count != 0) {
            int prev = -1;
            // Group with n contiguous elements backward
            for(int i=0, j=l.Count-1; i<W; i++,j--) {
                if (j<0)
                    return false;
                var p = l[j];
                if (!map.ContainsKey(p))
                    return false;
                // Reduce cnt
                --map[p];
                // Ensure the current key is one smaller than the prior one
                if (i!=0 && (prev != p + 1))
                    return false;
                prev = p;
                // Reduce map/l if count is 0
                if (map[p]==0) {
                    map.Remove(p);
                    // Ensure j is the last element
                    if (j != l.Count -1)
                        return false;
                    l.RemoveAt(j);
                }
            }
        }
        
        return true;
    }
}
