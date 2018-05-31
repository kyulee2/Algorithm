/*
Given two 1d vectors, implement an iterator to return their elements alternately.
Example:
Input:
v1 = [1,2]
v2 = [3,4,5,6] 

Output: [1,3,2,4,5,6]

Explanation: By calling next repeatedly until hasNext returns false, 
             the order of elements returned by next should be: [1,3,2,4,5,6].
Follow up: What if you are given k 1d vectors? How well can your code be extended to such cases?
Clarification for the follow up question:
The "Zigzag" order is not clearly defined and is ambiguous for k > 2 cases. If "Zigzag" does not look right to you, replace "Zigzag" with "Cyclic". For example:
Input:
[1,2,3]
[4,5,6,7]
[8,9]

Output: [1,4,8,2,5,9,3,6,7].
*/
// Comment: The blow uses a tuple and queue to form a general solution which the follow-up says.
// Tuple simplifies the use of the single queue, but the tuple items are read-only, so I had to create tuples all the time. 
// Other way is to use two queue -- one for list and the other for index.
public class ZigzagIterator {

    Queue<Tuple<IList<int>, int>> q;
    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        q = new Queue<Tuple<IList<int>, int>>();
        q.Enqueue(new Tuple<IList<int>, int>(v1, 0));
        q.Enqueue(new Tuple<IList<int>, int>(v2, 0));
    }

    public bool HasNext() {
        while(q.Count != 0) {
            Tuple<IList<int>, int> t = q.Peek();
            if (t.Item1.Count > t.Item2) {
                return true;
            }
            q.Dequeue();
        }
        return false;
    }

    public int Next() {
        Tuple<IList<int>, int> t = q.Dequeue();
        int ans = t.Item1[t.Item2];
        q.Enqueue(new Tuple<IList<int>, int>(t.Item1, t.Item2+1));
        return ans;
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */

