/*
Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

Follow up:
Could you do both operations in O(1) time complexity?

Example:

LRUCache cache = new LRUCache( 2  );// capacity

cache.put(1, 1);
cache.put(2, 2);
cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.put(4, 4);    // evicts key 1
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);    
*/
// Comment: Use LinkedListNode. Record key/value pair as int[]. Famialize with Value, First, Remove, AddLast, apis.
public class LRUCache {
    int k;
    LinkedList<int[]> list;
    Dictionary<int, LinkedListNode<int[]>> map;
    public LRUCache(int capacity) {
        k = capacity;
        list = new LinkedList<int[]>();
        map = new Dictionary<int, LinkedListNode<int[]>>(); // key,value pair
    }
    
    public int Get(int key) {
        if (!map.ContainsKey(key))
            return -1;
        var n = map[key];
        list.Remove(n);
        list.AddLast(n);
        return n.Value[1];
    }
    
    public void Put(int key, int value) {
        if (map.ContainsKey(key)) {
            var n = map[key];
            list.Remove(n);
            list.AddLast(n);
            n.Value[1] = value;
        } else {
            if (map.Count == k) { // Remove old one from the head
                var n = list.First;
                list.Remove(n);
                map.Remove(n.Value[0]);
            }
            var node = new LinkedListNode<int[]>(new int[]{key, value});
            list.AddLast(node);
            map[key] = node;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
