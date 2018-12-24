/*
Implement a data structure supporting the following operations:

Inc(Key) - Inserts a new key with value 1. Or increments an existing key by 1. Key is guaranteed to be a non-empty string.
Dec(Key) - If Key's value is 1, remove it from the data structure. Otherwise decrements an existing key by 1. If the key does not exist, this function does nothing. Key is guaranteed to be a non-empty string.
GetMaxKey() - Returns one of the keys with maximal value. If no element exists, return an empty string "".
GetMinKey() - Returns one of the keys with minimal value. If no element exists, return an empty string "".

Challenge: Perform all these in O(1) time complexity. 
*/
// Comment:  Intersting/good practice with LinkedList/HashMap/HashSet all together.
class AllOne {
public:
    list<unordered_set<string>> q;
    unordered_map<int, list<unordered_set<string>>::iterator> m1; // cnt to set
    unordered_map<string, int> m2; // key to cnt
    /** Initialize your data structure here. */
    AllOne() {

        m1.clear();
        m2.clear();
        q.clear();
    }
    
    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    void inc(string key) {
        int cnt = ++m2[key];
        auto I = q.end();
        if (m1.find(cnt-1) != m1.end()) {
            I = m1[cnt-1];
            I->erase(key);
            if (I->size()==0) {
                I = q.erase(I);
                m1.erase(cnt-1);
            }
        }
        
        if (m1.find(cnt) == m1.end()) {
            m1[cnt] = q.insert(I, unordered_set<string>());
        }
        m1[cnt]->insert(key);
        //cout<<"m1size" << m1.size() <<"\n";
    }
    
    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    void dec(string key) {
        if (m2.find(key)==m2.end())
            return;
        int cnt = --m2[key];
        if (cnt==0)
            m2.erase(key);
        auto I = m1[cnt+1];
        ++I;
        m1[cnt+1]->erase(key);
        if (m1[cnt+1]->size()==0) {
            q.erase(m1[cnt+1]);
            m1.erase(cnt+1);
        }
        if (m1.find(cnt)==m1.end()) {
            if (cnt!=0) {
                m1[cnt] = q.insert(I, unordered_set<string>());
                m1[cnt]->insert(key);
            }
        } else {
            m1[cnt]->insert(key);
        }
        //cout<<"m1size" << m1.size() <<"\n";
    }
    
    /** Returns one of the keys with maximal value. */
    string getMaxKey() {
        if (q.size()==0)
            return "";
        for(auto s : q.front())
            return s;
        return "";
    }
    
    /** Returns one of the keys with Minimal value. */
    string getMinKey() {
        if (q.size()==0)
            return "";
        for(auto s : q.back())
            return s;
        return "";
    }
};

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.inc(key);
 * obj.dec(key);
 * string param_3 = obj.getMaxKey();
 * string param_4 = obj.getMinKey();
 */
