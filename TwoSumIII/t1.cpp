/*
Design and implement a TwoSum class. It should support the following operations: add and find.
add - Add the number to an internal data structure.
find - Find if there exists any pair of numbers which sum is equal to the value.
Example 1:
add(1); add(3); add(5);
find(4) -> true
find(7) -> false
Example 2:
add(3); add(1); add(2);
find(3) -> true
find(6) -> false
*/
// Comment: consider when duplicate
class TwoSum {
public:
    map<int, int> m;
    
    /** Initialize your data structure here. */
    TwoSum() {
        
    }
    
    /** Add the number to an internal data structure.. */
    void add(int number) {
        m[number]++;
    }
    
    /** Find if there exists any pair of numbers which sum is equal to the value. */
    bool find(int value) {
        for(auto tup : m) {
            auto k = tup.first;
            int v = value -k;
            if (m.find(v) != m.end()) {
                if (v!=k) return true;
                if (m[v] > 1) return true;
            }
        }
        return false;
    }
};

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.add(number);
 * bool param_2 = obj.find(value);
 */