/*
Design and implement a data structure for Least Frequently Used (LFU) cache. It should support the following operations: get and put. 
get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item. For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted. 
Follow up:
Could you do both operations in O(1) time complexity?
Example: 
LFUCache cache = new LFUCache( 2  );

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.get(3);       // returns 3.
cache.put(4, 4);    // evicts key 1.
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4
*/
// Comment: Key point is to maintain list of list, two maps -- key to node, frequency to list
// The main list is ordered by frequency.
// Within the same frequency list, new node always put into the last.
// When chossing a victim, we got the first entry of list of list.
// Node should have key/value/frequency. To utilize existing LinkedList, should use LinkedListNode.
// Oherwise, Remove/Find, etc operations are O(n) not O(1)
// So, syntax are complex/confusing, though.
public class LFUCache {
    class Node {
        public Node(int k, int v) {
            key =k;
            value = v;
            freq = 1;
        }
        public int key;
        public int value;
        public int freq;
    }
    LinkedList<LinkedList<Node>> l;
    Dictionary<int, LinkedListNode<LinkedList<Node>>> fmap;
    Dictionary<int, LinkedListNode<Node>> kmap;
    int curr;
    int cap;
    
    public LFUCache(int capacity) {
        l = new LinkedList<LinkedList<Node>>();
        fmap = new Dictionary<int, LinkedListNode<LinkedList<Node>>>();
        kmap = new Dictionary<int, LinkedListNode<Node>>();
        cap = capacity;
    }
    
    public int Get(int key) {
        if (!kmap.ContainsKey(key))
            return -1;
        var prevN = kmap[key];
        var n = prevN.Value;
        int freq = n.freq;
        // Remove the node
        var prevL = fmap[freq];
        var fl = prevL.Value;
        fl.Remove(prevN);
        
        
        // Add it to the next freq list
        n.freq = freq + 1;
        if (!fmap.ContainsKey(n.freq)) {
            var nl = new LinkedList<Node>();
            fmap[n.freq] = new LinkedListNode<LinkedList<Node>>(nl);
            // insert it after prevL
            l.AddAfter(prevL, fmap[n.freq]);
        }
        fmap[n.freq].Value.AddLast(prevN);
        // no change in kmap.
        
        // Remove the prev list if needed.
        if (fl.Count == 0) {
            l.Remove(prevL);
            fmap.Remove(freq);
        }       
        
        return n.value;        
    }
    
    
    public void Put(int key, int value) {
        // Spoiler: Don't anything for 0 capacity
        if (cap == 0)
            return;
        
        // Arugable Spoiler: Do not insert if the key exists already?
        // According to test, just throw old value and update it with new one.
        if (kmap.ContainsKey(key)) {
            var kln = kmap[key];
            var kn = kln.Value;
            var fll = fmap[kn.freq];
            // Remove it from the current frequency group
            fll.Value.Remove(kln);
            ++kn.freq;
            kn.value = value; // update value in place
            
            // Add it to new frequncy group
            if (!fmap.ContainsKey(kn.freq)) {
                var ll = new LinkedList<Node>();
                var nll = new LinkedListNode<LinkedList<Node>>(ll);
                fmap[kn.freq] = nll;
                l.AddAfter(fll, nll); // Register new freq group after old one.
            }
            fmap[kn.freq].Value.AddLast(kln);            

            // Remove old frequency group if needed
            if (fll.Value.Count==0) {
                l.Remove(fll);
                fmap.Remove(kn.freq-1);
            }
            return;
        }
        
        // New key case below
        if (curr<cap) {
            // create new node
            var node = new Node(key, value);
            var ln = new LinkedListNode<Node>(node);
            if (!fmap.ContainsKey(1)) {
                var list = new LinkedList<Node>();
                fmap[1] = new LinkedListNode<LinkedList<Node>>(list);
                l.AddFirst(fmap[1]);
            }            
            kmap[key] = ln;
            fmap[1].Value.AddLast(ln);
            curr++;
            return;
        }
        
        // Pick the victim from the first in l
        var fl = l.First;
        var fn = l.First.Value.First;
        var n = fn.Value;        
        l.First.Value.RemoveFirst();
        if (l.First.Value.Count == 0) {
            l.RemoveFirst();
            fmap.Remove(n.freq);
        }
        kmap.Remove(n.key);
        
        // Create a new node
        var nn = new Node(key, value);
        var lnn = new LinkedListNode<Node>(nn);
        if (!fmap.ContainsKey(1)) {
            var list = new LinkedList<Node>();
            fmap[1] = new LinkedListNode<LinkedList<Node>>(list);
            l.AddFirst(fmap[1]);
        }            
        kmap[key] = lnn;
        fmap[1].Value.AddLast(lnn);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

