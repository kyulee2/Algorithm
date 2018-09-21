/*
*/
// Comment: This is task scheduling.
// Use a priority queue to pull out k tasks
// O(n log n) for time and O(n) space
public class Solution {
    public class Node {
        public char ch;
        public int cnt;
        public Node(char c, int n) {
            ch = c;
            cnt = n;
        }
        public int compareTo(Node other) {
            if (cnt < other.cnt)
                return -1;
            if (cnt == other.cnt)
                return ch > other.ch ? -1 : 1;
            return 1;
        }
    }
    class Heap
    {
        List<Node> l;
        Node e;
        public Heap() {
            l = new List<Node>();
            e = new Node(' ', Int32.MinValue);
            l.Add(new Node(' ',0));
        }
        public int Count {
            get { return l.Count-1; }
        }
        public void Add(Node n) {
            l.Add(n);
            up(Count);
        }
        public Node Pop() {
            var t = l[1];            
            swap(1, Count);
            l.RemoveAt(Count);
            down(1);
            return t;
        }
        void swap(int i, int j) {
            var n = l[i]; l[i] = l[j]; l[j] = n;
        }
        void up(int i)
        {
            if (i<=1) return;
            int p = i/ 2;
            if (l[i].compareTo(l[p])==1) {
                swap(i,p);
                up(p);
            }
        }
        void down(int i)
        {
            if (i>=Count) return;
            var curr = l[i];
            var left = i*2 > Count ? e : l[i*2];
            var right = i*2 + 1 > Count ? e: l[i*2+1];
            if (left.compareTo(right)==1) {
                if (left.compareTo(curr)==1) {
                    swap(i, i*2);
                    down(i*2);
                }
            } else {
                if (right.compareTo(curr)==1) {
                    swap(i, i*2+1);
                    down(i*2+1);
                }
            }
        }
    }
    public string RearrangeString(string s, int k) {
        // Spoiler: when k= 0
        if (k==0 || s.Length == 1)
            return s;
        
        // build heap
        Heap h = new Heap();
        var map = new Dictionary<char, Node>();
        foreach(var c in s)
            if (!map.ContainsKey(c))
                map[c] = new Node(c, 1);
            else map[c].cnt++;
        foreach(var v in map.Values)
            h.Add(v);
        
        var ansb = new StringBuilder();
        bool hasShort = false;
        while(h.Count>0) {
            var t = new List<Node>();
            if (hasShort)
                return "";
            // Spoiler: Take k elements from the heap
            for(int i=0; i<k; i++) {                
                if (h.Count<=0) {
                    // The last entry can be short of k
                    // So instead of return "", we just set it flag for the next iter to fail.
                    hasShort = true;
                    break;
                }
                var n = h.Pop();
               // Console.WriteLine("{0}", n.ch);
                ansb.Append(n.ch);
                n.cnt--;
                if (n.cnt>0)
                    t.Add(n);
            }
            // Fall back those elements to the heap
            foreach(var e in t)
                h.Add(e);
        }
        
        return ansb.ToString();
    }
}