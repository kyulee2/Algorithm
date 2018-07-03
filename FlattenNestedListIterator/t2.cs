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
// HasNext should be recursion to recursively handle empty nested one
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
public class NestedIterator {
    IList<NestedInteger> Curr;
    Stack<Tuple<IList<NestedInteger>, int>> Stk;
    int i;
    public NestedIterator(IList<NestedInteger> nestedList) {
        Curr = nestedList;
        Stk = new Stack<Tuple<IList<NestedInteger>, int>>();
    }

    public bool HasNext() {
        while (Curr.Count == i) {
            if (Stk.Count == 0)
                return false;
            var n = Stk.Pop();
            Curr = n.Item1;
            i = n.Item2;
        }
        
        if (!Curr[i].IsInteger()) {
            Stk.Push(new Tuple<IList<NestedInteger>, int>(Curr, i+1));
            Curr = Curr[i].GetList();
            i = 0;
            // Spoiler: Empty nested list
            return HasNext();
        }
        
        return true;
    }

    public int Next() {
        return Curr[i++].GetInteger();   
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
