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
public class NestedIterator {

    Stack<IList<NestedInteger>> q;
    Stack<int> qi;
    IList<NestedInteger> curr;
    int curri;
    public NestedIterator(IList<NestedInteger> nestedList) {
        q = new Stack<IList<NestedInteger>>();
        qi = new Stack<int>();
        curr = nestedList;
        curri = 0;
    }

    public bool HasNext() {
        if (curr.Count != curri) {
            NestedInteger n = curr[curri];
            if (n.IsInteger())
                return true;
            // Push nested list early            
            q.Push(curr);
            qi.Push(++curri); /* record next starting iteration */
            curr = n.GetList();
            curri = 0;
            return HasNext();
        }
        
        if (q.Count != 0) {
            curr = q.Pop();
            curri = qi.Pop();
            return HasNext();
        }
        
        return false;
    }

    public int Next() {
        if (curr.Count == curri)
            throw new Exception("Invalid Next");
        NestedInteger n = curr[curri++];
        if (!n.IsInteger())
            throw new Exception("Invalid Next");
        return n.GetInteger();
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
