/*
Implement a data structure supporting the following operations:

Inc(Key) - Inserts a new key with value 1. Or increments an existing key by 1. Key is guaranteed to be a non-empty string.
Dec(Key) - If Key's value is 1, remove it from the data structure. Otherwise decrements an existing key by 1. If the key does not exist, this function does nothing. Key is guaranteed to be a non-empty string.
GetMaxKey() - Returns one of the keys with maximal value. If no element exists, return an empty string "".
GetMinKey() - Returns one of the keys with minimal value. If no element exists, return an empty string "".

Challenge: Perform all these in O(1) time complexity. 
*/
// Comment:  Intersting/good practice with LinkedList/HashMap/HashSet all together.
public class AllOne {
    public class Node {
        public HashSet<string> keys;
        public int cnt;
        public Node(int c = 1)
        {
            keys = new HashSet<string>();
            cnt = c;
        }
        public void Add(string key)
        {
            keys.Add(key);
        }
        public string Get()
        {
            foreach(var e in keys)
                return e;
            return "";
        }
    }
    
    public LinkedList<Node> l;
    public Dictionary<string, LinkedListNode<Node>> map;
    /** Initialize your data structure here. */
    public AllOne() {
        l = new LinkedList<Node>();
        map = new Dictionary<string, LinkedListNode<Node>>();
        
    }
    
    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    public void Inc(string key) {
        if (!map.ContainsKey(key)) {
            if (l.Count ==0 || l.First.Value.cnt >1) {
                var n = new Node();
                n.Add(key);
                l.AddFirst(n);
                map[key] = l.First;
            } else {
                l.First.Value.Add(key);
                map[key] = l.First;
            }
        } else {
            var curr = map[key];
            var next = curr.Next;
            if (next != null && (next.Value.cnt == curr.Value.cnt+1)) {
                next.Value.Add(key);
                map[key] = next;
            } else {
                var n = new Node(curr.Value.cnt + 1);
                n.Add(key);
                l.AddAfter(curr, n);
                map[key] = curr.Next;
            }
            // Remove the key from the old Node
            curr.Value.keys.Remove(key);
            if (curr.Value.keys.Count == 0)
                l.Remove(curr);
        }
        
    }
    
    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    public void Dec(string key) {
        if (!map.ContainsKey(key))
            return;
        var curr = map[key];
        var prev = curr.Previous;
        if (prev != null && (prev.Value.cnt == curr.Value.cnt-1)) {
            prev.Value.Add(key);
            map[key] = prev;
        } else {
            if (curr.Value.cnt != 1) {
                var n = new Node(curr.Value.cnt - 1);
                n.Add(key);
                l.AddBefore(curr, n);
                map[key] = curr.Previous;
            } else // Remove it if the count becomes 0
                map.Remove(key);
        }
        // Remove the key from the old Node
        curr.Value.keys.Remove(key);
        if (curr.Value.keys.Count == 0)
            l.Remove(curr);
    }
    
    /** Returns one of the keys with maximal value. */
    public string GetMaxKey() {
        if (l.Count==0) return "";
        return l.Last.Value.Get();
    }
    
    /** Returns one of the keys with Minimal value. */
    public string GetMinKey() {
        if (l.Count==0) return "";
        return l.First.Value.Get();
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */
