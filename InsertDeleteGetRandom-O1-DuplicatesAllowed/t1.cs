/*
Design a data structure that supports all following operations in average O(1) time.
Note: Duplicate elements are allowed. 

insert(val): Inserts an item val to the collection.
remove(val): Removes an item val from the collection if present.
getRandom: Returns a random element from current collection of elements. The probability of each element being returned is linearly related to the number of same value the collection contains.

Example: 
// Init an empty collection.
RandomizedCollection collection = new RandomizedCollection();

// Inserts 1 to the collection. Returns true as the collection did not contain 1.
collection.insert(1);

// Inserts another 1 to the collection. Returns false as the collection contained 1. Collection now contains [1,1].
collection.insert(1);

// Inserts 2 to the collection, returns true. Collection now contains [1,1,2].
collection.insert(2);

// getRandom should return 1 with the probability 2/3, and returns 2 with the probability 1/3.
collection.getRandom();

// Removes 1 from the collection, returns true. Collection now contains [1,2].
collection.remove(1);

// getRandom should return 1 and 2 both equally likely.
collection.getRandom();
*/
// Comment: Use list and map to hashset to contain set of index to the list
// The key failure/spoiler is to avoid swapping/updating when the set of currently picked value and the set of the last index value are the same. Otherwise, we end up with removing twice.
public class RandomizedCollection {

    Dictionary<int, HashSet<int>> map; // value to set of index
    List<int> data; // list of value
    Random r;
    /** Initialize your data structure here. */
    public RandomizedCollection() {
        r = new Random();
        map = new Dictionary<int, HashSet<int>>();
        data = new List<int>();
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val) {
        bool ret = false;
        if (!map.ContainsKey(val)) {
            ret = true;
            map[val] = new HashSet<int>();
        }
        map[val].Add(data.Count);
        data.Add(val);
        return ret;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val) {
        if (!map.ContainsKey(val))
            return false;
        int idx =0; // pick any index from the set
        var currIdxSet = map[val];
        foreach(var e in currIdxSet) {
            idx = e;
            break;
        }
        
        int lastIdx = data.Count -1;
        int lastVal = data[lastIdx];
        var lastIdxSet = map[lastVal];
        // Spoiler: Do this only when lastIdxSet is different
        // otherwise, simply pick the lastIdx from the current set
        if (lastIdxSet == currIdxSet) {
            idx = lastIdx;
        } else {
            // swap val with lastVal
            data[idx] = lastVal;
            lastIdxSet.Remove(lastIdx);
            lastIdxSet.Add(idx);
        }
            
        // remove current index and set if it's the last
        currIdxSet.Remove(idx);
        if (currIdxSet.Count==0)
            map.Remove(val);
        // remove the lastval from the data
        data.RemoveAt(lastIdx);
        
        return true;
    }
    
    /** Get a random element from the collection. */
    public int GetRandom() {
        
        int idx = r.Next(data.Count);
        //Console.WriteLine("data {0} {1}", data.Count, idx);
        return data[idx];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */