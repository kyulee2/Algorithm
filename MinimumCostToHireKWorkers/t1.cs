/*
There are N workers.  The i-th worker has a quality[i] and a minimum wage expectation wage[i].

Now we want to hire exactly K workers to form a paid group.  When hiring a group of K workers, we must pay them according to the following rules:

Every worker in the paid group should be paid in the ratio of their quality compared to other workers in the paid group.
Every worker in the paid group must be paid at least their minimum wage expectation.
Return the least amount of money needed to form a paid group satisfying the above conditions.

 

Example 1:

Input: quality = [10,20,5], wage = [70,50,30], K = 2
Output: 105.00000
Explanation: We pay 70 to 0-th worker and 35 to 2-th worker.
Example 2:

Input: quality = [3,1,10,10,1], wage = [4,8,2,2,7], K = 3
Output: 30.66667
Explanation: We pay 4 to 0-th worker, 13.33333 to 2-th and 3-th workers seperately. 
 

Note:

1 <= K <= N <= 10000, where N = quality.length = wage.length
1 <= quality[i] <= 10000
1 <= wage[i] <= 10000
Answers within 10^-5 of the correct answer will be considered correct.

*/
// Comment: Use a priority queue. The key part is to use factor - wage/quality.
// Sort the array by factor -- low wage compared to high quality.
// Using a sliding window with K employess in this sorted order.
// The sum of K's quality * current factor may produce minimum wage.
// Since we start from lowest factor, the current factor gurantees the prior element's wage
// already meets minimum wage. We just need to try find the minimal of sum of K's quality * current factor
public class Solution {
    public class Node {
        public double q;
        public double w;
        public Node(double q1, double w1) {
            q = (double)q1;
            w = (double)w1;
        }
    }
    public class Heap {
        List<Node> l;
        Node e;
        public int Count {
            get { return l.Count - 1; }
        }
        public Heap() {l = new List<Node>(); l.Add(new Node(0,0)); e = new Node(0, Double.MinValue);}
        public Node Top() {
            return l[1];
        }
        public Node Pop() {
            var ans = Top();
            Swap(1, Count);
            l.RemoveAt(Count);
            down(1);
            return ans;
        }
        public void Add(Node n) {
            l.Add(n);
            up(Count);
        }
        void Swap(int i, int j) {
            var t = l[i];
            l[i] = l[j];
            l[j] = t;
        }
        void up(int i) {
            if (i<=1) return;
            int p = i/2;
            if (l[p].q < l[i].q) {
                Swap(p,i);
                up(p);
            }
        }
        void down(int i) {
            if (i>Count) return;
            Node left = i * 2 > Count ? e : l[i*2];
            Node right = (i*2+1) > Count ? e : l[i*2+1];
            if (left.q > right.q) {
                if (left.q > l[i].q) {
                    Swap(i*2, i);
                    down(i*2);
                }
            } else {
                if (right.q > l[i].q) {
                    Swap(i*2+1, i);
                    down(i*2+1);
                }
            }
        }
    }
    public double MincostToHireWorkers(int[] quality, int[] wage, int K) {
        int len = wage.Length;
        var ans = double.MaxValue;
        var t  = new List<Node>();
        for(int i=0; i<len; i++)
            t.Add(new Node(quality[i], wage[i]));
        // Sort by factor
        t.Sort((x,y) => (x.w/x.q).CompareTo(y.w/y.q));
        
        Heap h = new Heap(); // max heap for quality
        double sum = 0;
        // Try the first smallest K element with lowest factor w/q
        foreach(var n in t) {
            h.Add(n);

            sum += n.q;
            if (h.Count > K)
                sum -= h.Pop().q;
            if (h.Count == K)
                ans = Math.Min(ans, sum * n.w/n.q);
        }
        
        return ans;
    }
}
