/*
Winter is coming! Your first job during the contest is to design a standard heater with fixed warm radius to warm all the houses.

Now, you are given positions of houses and heaters on a horizontal line, find out minimum radius of heaters so that all houses could be covered by those heaters.

So, your input will be the positions of houses and heaters seperately, and your expected output will be the minimum radius standard of heaters.

Note:
Numbers of houses and heaters you are given are non-negative and will not exceed 25000.
Positions of houses and heaters you are given are non-negative and will not exceed 10^9.
As long as a house is in the heaters' warm radius range, it can be warmed.
All the heaters follow your radius standard and the warm radius will the same.
Example 1:
Input: [1,2,3],[2]
Output: 1
Explanation: The only heater was placed in the position 2, and if we use the radius 1 standard, then all the houses can be warmed.
Example 2:
Input: [1,2,3,4],[1,4]
Output: 1
Explanation: The two heater was placed in the position 1 and 4. We need to use radius 1 standard, then all the houses can be warmed.
 
*/
// Comment: Should be easy, but there are a few spoilers
// 1. Without sort, naively seracihng max of minimal distance between heater and houses are O(n*t) causing time-out
// 2. After sort, it is close to the answer. The bettwe way is to once we find the minimal distnace between heater and house, then we don't need to search from 0'th heater to compute the next minimal distance of the house.
// Instead, we can start from the index that was matched.. See below code. Node, we should decrement j by one to start from either the exact match. This covers also the one element of heater case where the loop exits.
public class Solution {

    public int FindRadius(int[] houses, int[] heaters) {
        int ans = 0;
        Array.Sort(houses);
        Array.Sort(heaters);
        
        int j=0;
        foreach(var hp in houses) {
            int d = Int32.MaxValue;
            for( ; j<heaters.Length; j++) {
                int t = heaters[j];
                int delta = Math.Abs(hp-t);
                if (delta > d) {
                    break;
                }
                d = delta;
            }
            // Spoiler: Should search from the previous index
            // that was matched.
            --j;
            ans = Math.Max(ans, d);
        }
        return ans;
    }
}

