/*
Given a set of keywords words and a string S, make all appearances of all keywords in S bold. Any letters between <b> and </b> tags become bold. 
The returned string should use the least number of tags possible, and of course the tags should form a valid combination. 
For example, given that words = ["ab", "bc"] and S = "aabcd", we should return "a<b>abc</b>d". Note that returning "a<b>a<b>b</b>c</b>d" would use more tags, so it is incorrect. 
Note:
words has length in range [0, 50].
words[i] has length in range [1, 10].
S has length in range [0, 500].
All characters in words[i] and S are lowercase letters.
*/
// Comment: Think about open/close and merge range in place.
// I use int[] map. Note open is before while close is after the char. So, when builing/creating map, +1 is considered for close. Inserting open/close is only when we moved from 0 or back to 0 of status.
public class Solution {
    public string BoldWords(string[] words, string S) {
        int len = S.Length;
        int[] map = new int[len+1];
        // Build map
        foreach(var w in words) {
            int i = 0;
            int start = 0;
            int wlen = w.Length;
            while(i<len && (i=S.IndexOf(w, start)) != -1) {
                ++map[i];
                --map[i+wlen];
                start = i + 1;
            }
        }
        
        // main loop to build string
        StringBuilder b = new StringBuilder();
        int status = 0;
        for(int j=0; j<len; j++) {
            char c = S[j];
            int s = map[j];
            if (s==0) {
                b.Append(c);
                continue;
            }
            if (s > 0 && status == 0) {
                b.Append("<b>");
            } else if (s + status == 0) {
                b.Append("</b>");
            }
            status += s;
            b.Append(c);
        }
        // Handle the last close
        if (status>0)
            b.Append("</b>");
        return b.ToString();
    }
}

