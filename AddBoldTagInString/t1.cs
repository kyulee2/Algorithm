/*
Given a string s and a list of strings dict, you need to add a closed pair of bold tag <b> and </b> to wrap the substrings in s that exist in dict. If two such substrings overlap, you need to wrap them together by only one pair of closed bold tag. Also, if two substrings wrapped by bold tags are consecutive, you need to combine them.
Example 1:
Input: 
s = "abcxyz123"
dict = ["abc","123"]
Output:
"<b>abc</b>xyz<b>123</b>"
Example 2:
Input: 
s = "aaabbcc"
dict = ["aaa","aab","bc"]
Output:
"<b>aaabbc</b>c"
Note:
The given dict won't contain duplicates, and its length won't exceed 100.
All the strings in input have length in range [1, 1000].

*/

// Comment: Overal idea is to build sorted pair, merge them and process output.
// As below, there are many spoilers regarding building/merging pairs.
// Should consider duplication/overlap of substring for the given dictionary word.

public class Solution {
    string str;
    string[] map;
    int len;
    List<int[]> S; // sorted pair
    List<int[]> M; // merged pair (and sorted)
    
    void build()
    {
        foreach(var s in map) {
            int start = str.IndexOf(s);
            // Spoiler: Check start is valid
            while(start != -1) {
                int end = start + s.Length - 1;
                S.Add(new int[]{start, end});
                // Spoiler: Allow duplicates and overlap
                // Keep adding such substring from the next start index.
                start = str.IndexOf(s, start + 1);
            }
        }
        
        // Sort by start index
        // Spoiler: break it by ending index for the same index
        S.Sort((x,y)=>{
            int d = x[0] - y[0];
            if(d == 0)
                return x[1] - y[1];
            return d;
        });
    }
    
    void merge()
    {
        // spoiler: don't do anything on empty
        if (S.Count==0) return;
        
        int[] curr = S[0];
        int j = 1;
        while(j < S.Count) {
            int[] next = S[j];
            if (curr[1]+1 >= next[0]) {
                // Spoiler!!!!
                // When curr is inclusive of next like [   [ ] ]
                // we should not merge but just skip it
                // Note this shouldn't be "and" operation as above, rather in separate like this.
                if (next[1]>curr[1])
                    curr = new int[]{curr[0], next[1]}; // merge
            }
            else {
                M.Add(curr);
                curr = next;
            }
            j++;
        }
        // Last element
        M.Add(curr);
    }
    
    string process()
    {
        // first part
        if (M.Count == 0) return str;
        StringBuilder b = new StringBuilder();
        int start = M[0][0];
        if (start > 0) {
            b.Append(str.Substring(0, start));
        }
        
        // main loop -- string from list & next
        int j = 0;
        while(j < M.Count) {
            int[] Pair = M[j++];
            b.Append("<b>");
            b.Append(str.Substring(Pair[0], Pair[1]-Pair[0]+1));
            b.Append("</b>");
            
            // check next
            if (j == M.Count) {
                if (Pair[1] < len -1)
                    b.Append(str.Substring(Pair[1]+1));
            } else {
                int[] Next = M[j];
                b.Append(str.Substring(Pair[1]+1, Next[0]-Pair[1]-1));
            }
        }
        return b.ToString();
    }
    
    public string AddBoldTag(string s, string[] dict) {
        // Initialize data
        str = s;
        len = s.Length;
        map = dict;
        S = new List<int[]>();
        M = new List<int[]>();
        
        // Build sorted pair
        build();
        
        // Merge
        merge();
        
        // Process output
        return process();
    }
}

