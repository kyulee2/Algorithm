/*
Given an array of n distinct non-empty strings, you need to generate minimal possible abbreviations for every word following rules below.

Begin with the first character and then the number of characters abbreviated, which followed by the last character.
If there are any conflict, that is more than one words share the same abbreviation, a longer prefix is used instead of only the first character until making the map from word to abbreviation become unique. In other words, a final abbreviation cannot map to more than one original words.
If the abbreviation doesn't make the word shorter, then keep it as original.
Example:
Input: ["like", "god", "internal", "me", "internet", "interval", "intension", "face", "intrusion"]
Output: ["l2e","god","internal","me","i6t","interval","inte4n","f2e","intr4n"]
Note:
Both n and the length of each word will not exceed 400.
The length of each word is greater than 1.
The words consist of lowercase English letters only.
The return answers should be in the same order as the original array.
*/
// Comment: Can't assign IList to List directly.
// The key idea is to keep two maps (original string to encoded one) or vice versa
// When detected duplicated item, remove such mapping and put into nextList (WorkList).
// We do this until workList is empty. For each workList, we should increase prefix length
// See encode function how we generate such thing.
public class Solution
{
    // Until the given p index, get prefix.
    // followed by number of char until last char
    // followed by last char
    // goat -> g2t
    string encode(string s, int p)
    {
        int len = s.Length;
        if (p >= len - 3) // no abbreviation
            return s;
        int d = len - p - 2;
        return s.Substring(0, p + 1) + d.ToString() + s[len - 1];
    }

    public IList<string> WordsAbbreviation(IList<string> dict)
    {
	// Not List but IList as below.
        IList<string> nextList = dict;
        // s -> e, e -> s
        Dictionary<string, string> mape = new Dictionary<string, string>();
        Dictionary<string, string> mapd = new Dictionary<string, string>();
        int p = 0;
        while(nextList.Count != 0)
        {
            // Invalidate/delete any entry that alreadys resides in maps
            foreach (var s in nextList) {
                if (mape.ContainsKey(s)) {
                    string e = mape[s];
                    mape.Remove(s);
                    mapd.Remove(e); // optional?
                }
            }

            // Add encode into map
            List<string> newNextList = new List<string>();
            foreach(var s in nextList) {
                string e = encode(s, p);
                mape[s] = e;
                if (mapd.ContainsKey(e)) { // detect duplication
                    string t = mapd[e];
                    if (t!="") {
                        // Add the first element (that is duplicated, but not added yet)
                        newNextList.Add(t);
                        mapd[e] = "";
                    }
                    newNextList.Add(s);
                }
                else
                    mapd[e] = s;
            }
            nextList = newNextList;
            p++;
        }

        List<string> ans = new List<string>();
        foreach (var s in dict)
            ans.Add(mape[s]);
        return ans;
    }
}

