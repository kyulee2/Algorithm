/*
Given a non-empty list of words, return the k most frequent elements.
Your answer should be sorted by frequency from highest to lowest. If two words have the same frequency, then the word with the lower alphabetical order comes first.
Example 1:
Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
Output: ["i", "love"]
Explanation: "i" and "love" are the two most frequent words.
    Note that "i" comes before "love" due to a lower alphabetical order.

Example 2:
Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
Output: ["the", "is", "sunny", "day"]
Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
    with the number of occurrence being 4, 3, 2 and 1 respectively.

Note:
You may assume k is always valid, 1 = k = number of unique elements.
Input words contain only lowercase letters.

Follow up:
Try to solve it in O(n log k) time and O(n) extra space.
*/
// Comment: Should be similar to TopKFrequentElements (integer) which can be solved using partition o(n)
// Here PriorityQueue/heap + map is used. O(n logk) time with O(n) space
public class Solution {
    public class Node {
        public string val;
        public int cnt;
        public Node(string n, int c) {
            val = n; cnt = c;
        }
        public int CompareTo(Node other)
        {
            int diff = cnt - other.cnt;
            if (diff!=0) return diff;
            return other.val.CompareTo(val);
        }
    }
    public class Heap {
        List<Node> l;
        Node nil;
        public Heap() {
            l = new List<Node>();
            nil = new Node("",Int32.MaxValue);
            l.Add(nil); // dummy root
        }
        public int Count { get { return l.Count - 1;} }
        void Swap(int i, int j) {
            var t = l[i]; l[i] = l[j]; l[j] = t;
        }
        public void Add(string n, int c)
        {
            l.Add(new Node(n, c));
            up(Count);
        }
        public string Pop()
        {
            var t = l[1].val;
            Swap(1, Count);
            l.RemoveAt(Count); // Spoiler: Remove element first before down
            down(1);
            
            return t;
        }
        void up(int i)
        {
            if (i<=1) return;
            int p = i/2;
            if (l[i].CompareTo(l[p])<0) {
                Swap(i,p);
                up(p);
            }
        }
        void down(int i)
        {
            if (i>=Count) return;
            var left = i*2>Count ? nil : l[i*2];
            var right = i*2+1 > Count ? nil : l[i*2+1];
            if (left.CompareTo(right)<0) {
                if (left.CompareTo(l[i])<0) {
                    Swap(i, i*2);
                    down(i*2);
                }
            } else {
                if (right.CompareTo(l[i])<0) {
                    Swap(i, i*2+1);
                    down(i*2+1);
                }
            }
        }
    }
    public IList<string> TopKFrequent(string[] words, int k) {
        // Init map to word count O(n) space, O(n) time
        var map = new Dictionary<string, int>();
        foreach(var w in words)
            if (map.ContainsKey(w))
                map[w]++;
            else map[w] = 1;
        
        var ans = new List<string>();
        var Heap = new Heap(); // O(k) time since we only holds k elements
        int len = map.Count;
        int i=0;
        foreach(var key in map.Keys) {
            Heap.Add(key, map[key]);
            if (i>=k) {
                Heap.Pop();
            }
            i++;
        }
        
        for(i=0; i<k; i++)
            ans.Add(Heap.Pop());
        ans.Reverse();
        
        return ans;
    }
}