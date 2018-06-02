/*
An abbreviation of a word follows the form <first letter><number><last letter>. Below are some examples of word abbreviations:
a) it                      --> it    (no abbreviation)

     1
b) d|o|g                   --> d1g

              1    1  1
     1---5----0----5--8
c) i|nternationalizatio|n  --> i18n

              1
     1---5----0
d) l|ocalizatio|n          --> l10n
Assume you have a dictionary and given a word, find whether its abbreviation is unique in the dictionary. A word's abbreviation is unique if no other word from the dictionary has the same abbreviation.
Example:
Given dictionary = [ "deer", "door", "cake", "card" ]

isUnique("dear") -> false
isUnique("cart") -> true
isUnique("cane") -> false
isUnique("make") -> true
*/

// Comment: Spoiler-- Need to clarify the condition. It's not just a set to see if the given abbreviation exists.
// It needs to use a map to store the unique word along with the abbreviation key.
// If there are more than one word that has the same key/abbreviation, store empty string instead.
// For the given word, if the key is not in the dictionary/map, return true -- it's unique.
// If the key is in the map and the corresponding word is the same, then also return true.
public class ValidWordAbbr {

    string Abb(string str) {
        int len = str.Length;
        if (len<=2) return str;
        StringBuilder b = new StringBuilder();
        b.Append(str[0]);
        b.Append(len -2);
        b.Append(str[len-1]);
        return b.ToString();
    }
    Dictionary<string, string> map;
    
    public ValidWordAbbr(string[] dictionary) {
        map = new Dictionary<string, string>();
        foreach(var s in dictionary) {
            string key = Abb(s);
            if (!map.ContainsKey(key)) map[key]  = s;
            if (map[key] != s)
                map[key] = "";
        }
    }
    
    public bool IsUnique(string word) {
        string key = Abb(word);
        if (!map.ContainsKey(key))
            return true;
        return map[key] == word;
    }
}

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */
