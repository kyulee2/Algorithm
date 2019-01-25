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
// The key failure/spoiler is to avoid swapping/updating when the set of currently picked value and the set of class RandomizedCollection {
public:
    map<int, set<int>> m; // val to list of index in order
    vector<int> v;
    /** Initialize your data structure here. */
    RandomizedCollection() {
        
    }
    
    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    bool insert(int val) {
        bool ans = false;
        if (m.find(val)==m.end()) {
            m[val] = set<int>();
            ans = true;
        }
        v.push_back(val);
        m[val].insert(v.size()-1);
        return ans;
    }
    
    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    bool remove(int val) {
        if (m.find(val)==m.end())
            return false;
        auto &ms = m[val];
        // get any index from m corresponding to val
        int idx;
        for(auto t : ms) {
            idx = t; break;
        }
        // Find the last element
        int lastE = v.back();
        auto &mls = m[lastE];
        
        // Replace current value by the lastElement at idx
        int lastIdx = v.size()-1;
        v[idx] = lastE;
        v.resize(lastIdx);
        
        // Update m 
        // SPoiler: The order of operations below are strictly enforced.
        // Otherwise, we should do this in separate when &ml != &mls
        // Think about ml == mls, idx = 0, last = 4.
        // start with updating/deleing 0 from ms and inserting 0 to mls -- essentionally no op.
        // But if we push down the erase operation below (commented out), we will end up with erasing both 0 and 4..
        ms.erase(idx);
        mls.insert(idx);
        mls.erase(lastIdx);
        //ms.erase(idx);

        if (ms.size()==0)
            m.erase(val);
        
        return true;
    }
    
    /** Get a random element from the collection. */
    int getRandom() {
        int i = rand()% v.size();
        return v[i];
    }
};

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.insert(val);
 * bool param_2 = obj.remove(val);
 * int param_3 = obj.getRandom();
 */