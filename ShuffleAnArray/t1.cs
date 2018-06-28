/*
Shuffle a set of numbers without duplicates.

Example:

// Init an array with set 1, 2, and 3.
int[] nums = {1,2,3};
Solution solution = new Solution(nums);

// Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
solution.shuffle();

// Resets the array back to its original configuration [1,2,3].
solution.reset();

// Returns the random shuffling of array [1,2,3].
solution.shuffle();

*/
// Comment: Straightfoward. Need to think about reversing iteration to swap elements randomly.
public class Solution {
    Random r;
    int[] orig;
    int[] s;
    int len;
    public Solution(int[] nums) {
        r = new Random();
        orig = nums;
        len = nums.Length;
        s = new int[len];
        Array.Copy(orig, s, len);
    }
    
    /** Resets the array to its original configuration and return it. */
    public int[] Reset() {
        Array.Copy(orig, s, len);
        return s;
    }
    
    /** Returns a random shuffling of the array. */
    public int[] Shuffle() {
        for(int i=len-1; i>=0; i--) {
            int j = r.Next(i+1);
            if (i!=j) {
                int t = s[i];
                s[i] = s[j];
                s[j] = t;
            }
        }
        return s;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */
