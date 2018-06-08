/*
You are playing the following Bulls and Cows game with your friend: You write down a number and ask your friend to guess what the number is. Each time your friend makes a guess, you provide a hint that indicates how many digits in said guess match your secret number exactly in both digit and position (called "bulls") and how many digits match the secret number but locate in the wrong position (called "cows"). Your friend will use successive guesses and hints to eventually derive the secret number.

Write a function to return a hint according to the secret number and friend's guess, use A to indicate the bulls and B to indicate the cows. 

Please note that both secret number and friend's guess may contain duplicate digits.

Example 1:

Input: secret = "1807", guess = "7810"

Output: "1A3B"

Explanation: 1 bull and 3 cows. The bull is 8, the cows are 0, 1 and 7.
Example 2:

Input: secret = "1123", guess = "0111"

Output: "1A1B"

Explanation: The 1st 1 in friend's guess is a bull, the 2nd or 3rd 1 is a cow.
Note: You may assume that the secret number and your friend's guess only contain digits, and their lengths are always equal.
*/
// Comment: Initially I though map [chr : set of index]. As long as there is any index that matches current char in guess, I counted as cows. The problem above actually considers the total count of chars which are duplicated -- one on one mapping not one on multiples. So, Intead, should consider count as below.
public class Solution {
    public string GetHint(string secret, string guess) {
        // map[chr : cnt]
        Dictionary<char, int> map = new Dictionary<char, int>();
        for(int i=0; i<secret.Length; i++) {
            char c = secret[i];
            if (!map.ContainsKey(c))
                map[c] = 0;
            ++map[c];
        }
        
        StringBuilder b = new StringBuilder();
        int cows = 0;
        // Two passes: find bulls first
        HashSet<int> bulls = new HashSet<int>();
        for(int i=0; i<guess.Length; i++) {
            char c = guess[i];
            if (!map.ContainsKey(c))
                continue;
            if (i < secret.Length && secret[i] == c) {
                // Record bulls index to skip in the cows loop
                bulls.Add(i);
                --map[c];
                if (map[c] == 0)
                    map.Remove(c);
            }
        }
        
        // Find cows.
        for(int i=0; i<guess.Length; i++) {
            if (bulls.Contains(i))
                continue;
            char c = guess[i];
            if (!map.ContainsKey(c))
                continue;
            cows++;
            --map[c];
            if (map[c] == 0)
                map.Remove(c);
        }
        
        b.Append(bulls.Count);
        b.Append('A');
        b.Append(cows);
        b.Append('B');
        return b.ToString();
    }
}

