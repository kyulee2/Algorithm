/*
Design a data structure that supports all following operations in average O(1) time.

insert(val): Inserts an item val to the set if not already present.
remove(val): Removes an item val from the set if present.
getRandom: Returns a random element from current set of elements. Each element must have the same probability of being returned.

Example: 
// Init an empty set.
RandomizedSet randomSet = new RandomizedSet();

// Inserts 1 to the set. Returns true as 1 was inserted successfully.
randomSet.insert(1);

// Returns false as 2 does not exist in the set.
randomSet.remove(2);

// Inserts 2 to the set, returns true. Set now contains [1,2].
randomSet.insert(2);

// getRandom should return either 1 or 2 randomly.
randomSet.getRandom();

// Removes 1 from the set, returns true. Set now contains [2].
randomSet.remove(1);

// 2 was already in the set, so return false.
randomSet.insert(2);

// Since 2 is the only number in the set, getRandom always return 2.
randomSet.getRandom();
*/

// Comment: List + Dictionary, or Array + Dictionary.
// Map/Dictionary has value to the index of List.
// Remove is the key operation.
// If it is not the only element, swap it with the last element.
// Delete the last one, and update map
public class RandomizedSet {
    List<int> data;
    Dictionary<int, int> map;
    Random r;
    /** Initialize your data structure here. */
    public RandomizedSet() {
        data = new List<int>();
        map = new Dictionary<int, int>();
        r = new Random();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if (map.ContainsKey(val))
            return false;
        
        map[val] = data.Count;
        data.Add(val);
        return true;        
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if (!map.ContainsKey(val))
            return false;
        int idx = map[val];
        
        // Spoiler: Only do this swapping 
        if (data.Count != 1)
        {
            // Swap idx with last element (which is ignored)
            int lastIdx = data.Count -1;
            int t = data[lastIdx];
            data[lastIdx] = data[idx];
            data[idx] = t;
            // Update map for the last idx in place
            map[t] = idx;
        }
        
        map.Remove(val);
        data.RemoveAt(data.Count - 1);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
        int idx = r.Next(data.Count);
        return data[idx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */

