/*
You are given an array A of strings.
Two strings S and T are special-equivalent if after any number of moves, S == T.
A move consists of choosing two indices i and j with i % 2 == j % 2, and swapping S[i] with S[j].
Now, a group of special-equivalent strings from A is a non-empty subset S of A such that any string not in S is not special-equivalent with any string in S.
Return the number of groups of special-equivalent strings from A.
 

Example 1:
Input: ["a","b","c","a","c","c"]
Output: 3
Explanation: 3 groups ["a","a"], ["b"], ["c","c","c"]
Example 2:
Input: ["aa","bb","ab","ba"]
Output: 4
Explanation: 4 groups ["aa"], ["bb"], ["ab"], ["ba"]
Example 3:
Input: ["abc","acb","bac","bca","cab","cba"]
Output: 3
Explanation: 3 groups ["abc","cba"], ["acb","bca"], ["bac","cab"]
Example 4:
Input: ["abcd","cdab","adcb","cbad"]
Output: 1
Explanation: 1 group ["abcd","cdab","adcb","cbad"]
 
Note:
1 <= A.length <= 1000
1 <= A[i].length <= 20
All A[i] have the same length.
All A[i] consist of only lowercase letters.
*/
// Comment: Either way should be reasonable.
// The first one is use count for each alaphbet in odd/even separate.
// Just count the unique count patterns of such string representation. O(n m)
// The other way (commented out) is use sort to the odd/even chars in the same order to detect match easily. O(n mlogm)
public class Solution {
    public int NumSpecialEquivGroups(string[] A) {
        var map = new HashSet<string>();
        int len = A[0].Length;

        // O(n m) where n is # of string, m is len of each string
        foreach(var s in A) {
            var count = new int[52]; // count odd/even char
            for(int k=0; k<len; k++) {
                var c = s[k];
                count[c - 'a' + 26 * (k%2)]++;
            }
            // convert count array to string
            var key = string.Join(",", count);
            map.Add(key);
        }
        
        return map.Count;
    }    
    /* 
    public int NumSpecialEquivGroups(string[] A) {
        var map = new HashSet<string>();
        int len = A[0].Length;
        char[] s1 = null;
        if (len %2!=0)
            s1 = new char[len/2+1];
        else s1 = new char[len/2];
        char[] s2 = new char[len/2];
        
        // O(n m log m) where n is # of string, m is len of each string
        foreach(var s in A) {
            int i=0, j=0;
            var str = s.ToCharArray();
            for(int k=0; k<len; k++) {
                var c = str[k];
                if (k%2==0)
                    s1[i++] = c;
                else s2[j++] = c;
            }
            Array.Sort(s1);
            Array.Sort(s2);
            map.Add((new string(s1)) + (new string(s2)));
        }
        
        return map.Count;
    }
    */
}