/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */

// Comment: The key point is to use stack to evaluate NestedInteger.
// Assuming operation Next() follows HasNext(), eagerly the nested list should be expanded
// while Next() only expects an integer at current position from the given/current list.
// Otherwise, we could end up with incorrectly handling [[]] empty nested one.
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * class NestedInteger {
 *   public:
 *     // Return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool isInteger() const;
 *
 *     // Return the single integer that this NestedInteger holds, if it holds a single integer
 *     // The result is undefined if this NestedInteger holds a nested list
 *     int getInteger() const;
 *
 *     // Return the nested list that this NestedInteger holds, if it holds a nested list
 *     // The result is undefined if this NestedInteger holds a single integer
 *     const vector<NestedInteger> &getList() const;
 * };
 */
class NestedIterator {
public:
    stack<vector<NestedInteger>> s;
    stack<int> si;
    int idx;
    vector<NestedInteger> curr;
    NestedIterator(vector<NestedInteger> &nestedList) {
        idx = 0;
        curr = nestedList;
    }

    int next() {
        int ans = curr[idx++].getInteger();
        return ans;
    }

    bool hasNext() {
        if (idx != curr.size()) {
            if (curr[idx].isInteger())
                return true;
            si.push(idx+1);
            s.push(curr);
            auto l = curr[idx].getList();
            curr = l;
            idx = 0;
            return hasNext();
        } 
        if (s.size()==0) return false;
        curr = s.top(); s.pop();
        idx = si.top(); si.pop();
        return hasNext();
    }
};

/**
 * Your NestedIterator object will be instantiated and called as such:
 * NestedIterator i(nestedList);
 * while (i.hasNext()) cout << i.next();
 */