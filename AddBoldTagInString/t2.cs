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
    public string AddBoldTag(string s, string[] dict) {
        int len = s.Length;
        var r = new List<int[]>();
        foreach(var word in dict) {
            int next = 0;
            int start = -1;
            // Spoiler: allow duplicated match of dictionary
            // Also matching can occur from start + 1 not end + 1 for repeated chars.
            while(next < len && (start=s.IndexOf(word, next))!=-1) {
                int end = start + word.Length - 1;
                r.Add(new int[]{start, end});
                next = start + 1;
            }        
        }
        
        var m = new List<int[]>();
        // Spoiler: Bail-out empty match or zero dict
        if (r.Count==0)
            return s;
        // merge range
        r.Sort((x,y)=>(x[0] - y[0]));
        int min = r[0][0];
        int max = r[0][1];
        for(int i=1; i<r.Count; i++) {
            var range = r[i];
            if (range[0] > max + 1) {
                m.Add(new int[]{min, max});
                min = range[0];
                max = range[1];
            } else {
                max = Math.Max(max, range[1]);
            }
        }
        m.Add(new int[]{min, max});
        
        int j= 0;
        var b = new StringBuilder();
        for(int i=0; i<len; i++) {
            if (j<m.Count && m[j][0] == i)
                    b.Append("<b>");
            b.Append(s[i]);
            if (j<m.Count && m[j][1] == i) {
                b.Append("</b>");
                j++;
            }
        }
        return b.ToString();
    }
}
