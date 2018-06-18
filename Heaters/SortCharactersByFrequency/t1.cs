/*
Given a string, sort it in decreasing order based on the frequency of characters.

Example 1:

Input:
"tree"

Output:
"eert"

Explanation:
'e' appears twice while 'r' and 't' both appear once.
So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
Example 2:

Input:
"cccaaa"

Output:
"cccaaa"

Explanation:
Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
Note that "cacaca" is incorrect, as the same characters must be together.
Example 3:

Input:
"Aabb"

Output:
"bbAa"

Explanation:
"bbaA" is also a valid answer, but "Aabb" is incorrect.
Note that 'A' and 'a' are treated as two different characters.
*/
// Comment: Use two maps. Just be careful about duplication of count.
// First map -- char to count, Second map -- count to list of chars.
public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> cmap = new Dictionary<char, int>();
        // Spoiler: list of char, not char for duplication of count
        Dictionary<int, List<char>> imap = new Dictionary<int, List<char>>();
        foreach(var c in s)
            if (cmap.ContainsKey(c)) ++cmap[c];
            else cmap[c] = 1;
        foreach(var k in cmap.Keys) {
            int cnt = cmap[k];
            if (!imap.ContainsKey(cnt)) imap[cnt] = new List<char>();
            imap[cnt].Add(k);
        }
        var l = imap.Keys.ToList();
        l.Sort();
        l.Reverse();
        Console.WriteLine("{0}", imap.Count);
        StringBuilder b = new StringBuilder();
        foreach(var cnt in l)
            foreach(var c in imap[cnt])
                b.Append(c, cnt);
        return b.ToString();
    }
}

