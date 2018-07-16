/*
A gene string can be represented by an 8-character long string, with choices from "A", "C", "G", "T".
Suppose we need to investigate about a mutation (mutation from "start" to "end"), where ONE mutation is defined as ONE single character changed in the gene string.
For example, "AACCGGTT" -> "AACCGGTA" is 1 mutation.
Also, there is a given gene "bank", which records all the valid gene mutations. A gene must be in the bank to make it a valid gene string.
Now, given 3 things - start, end, bank, your task is to determine what is the minimum number of mutations needed to mutate from "start" to "end". If there is no such a mutation, return -1.
Note:
Starting point is assumed to be valid, so it might not be included in the bank.
If multiple mutations are needed, all mutations during in the sequence must be valid.
You may assume start and end string is not the same.
 
Example 1:
start: "AACCGGTT"
end:   "AACCGGTA"
bank: ["AACCGGTA"]

return: 1
 
Example 2:
start: "AACCGGTT"
end:   "AAACGGTA"
bank: ["AACCGGTA", "AACCGCTA", "AAACGGTA"]

return: 2
 
Example 3:
start: "AAAAACCC"
end:   "AACCCCCC"
bank: ["AAAACCCC", "AAACCCCC", "AACCCCCC"]

return: 3
*/
// Comment: Map ACGT to 1,2,4,8 bit.
// To get valid mutation, apply xor which should have only two bits are different,
public class Solution {
    public int MinMutation(string start, string end, string[] bank) {
        bool isValidMove(int n) {
            int cnt = 0;
            while(n>0 && cnt<3) {
                cnt++;
                n &= (n-1);
            }
            return cnt == 2;
        }
        int encode(string s)
        {
            int t = 0;
            foreach(var c in s) {
                t <<=4;
                switch(c) {
                    case 'A' : t += 1; break;
                    case 'C' : t += 2; break;
                    case 'G' : t += 4; break;
                    case 'T' : t += 8; break;
                }
            }
            return t;
        }
        int st = encode(start);
        int ed= encode(end);
        var b = new List<int>();
        foreach(var word in bank)
            b.Add(encode(word));
        
        var q = new Queue<int[]>();
        q.Enqueue(new int[]{st,0});
        var ans = Int32.MaxValue;
        var visited = new HashSet<int>();
        while(q.Count != 0) {
            var node = q.Dequeue();
            if (visited.Contains(node[0]))
                continue;
            visited.Add(node[0]);
            if (node[0] ==ed) {
                ans = node[1];
                break;
            }
            foreach(var next in b) {
                if (next == node[0])
                    continue;
                int xor = next ^ node[0];
                if (!isValidMove(xor))
                    continue;
                q.Enqueue(new int[]{next, node[1]+1});
            }
        }
        
        return ans==Int32.MaxValue ? -1 : ans;
    }
}
