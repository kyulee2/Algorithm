/*
Write a function to generate the generalized abbreviations of a word. 

Note: The order of the output does not matter.

Example:

Input: "word"
Output:
["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
*/
class Solution {
    List<string> ans;
    bool[] status;
    int len;
    string s;
    string output()
    {
        StringBuilder b = new StringBuilder();
        for(int i=0; i<len; i++) {
            if (status[i])
                b.Append(s[i]);
            else {
                int cnt = 0;
                while(i<len && !status[i]) {
                    i++; cnt++;
                }
                i--;
                b.Append(cnt);
            }
        }
        return b.ToString();
    }
    
    void Rec(int i, int n)
    {
        if (i==n) {
            ans.Add(output());
            return;
        }
        
        // Spoiler: Either starts from i or using HashSet instead of List 
        // to avoid duplication
        for(int j=i; j<len; j++) {
            if (status[j]) continue;
            status[j] = true;
            Rec(j+1, n);
            status[j] = false;
        }
    }
    public IList<string> GenerateAbbreviations(string word) {
        // Initialize data
        ans = new List<string>();
        len = word.Length;
        s = word;
        status = new bool[len];
        
        // main rec
        for(int i=0; i<= len ; i++)
            Rec(0, i);
        
        return ans;
    }
}

