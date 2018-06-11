/*
Implement an iterator to flatten a 2d vector.
Example:
Input: 2d vector =
[
  [1,2],
  [3],
  [4,5,6]
]
Output: [1,2,3,4,5,6]
Explanation: By calling next repeatedly until hasNext returns false, 
             the order of elements returned by next should be: [1,2,3,4,5,6].
Follow up:
As an added challenge, try to code it using only iterators in C++ or iterators in Java.
*/
// Comment: Spoiler with empty vector.
// The below does not work if someone use next() without hasNext().
// If that is the case, we should consult hasNext() always within next()
public class Vector2D {
    int i; // Next vector index
    int j;
    IList<int> curr;
    bool visitedHasNext;
    IList<IList<int>> v;
    public Vector2D(IList<IList<int>> vec2d) {
        v = vec2d;
        // Spoiler: [] empty vector
        if (vec2d.Count != 0)  {
            curr = vec2d[0];
            i++;
        }
    }

    public bool HasNext() {
        if (curr==null) return false;
        
        if (j<curr.Count)
            return true;
        while(i<v.Count) {
            curr = v[i++];
            j = 0;
            if (j< curr.Count)
                return true;
        }
        curr = null;
        return false;
    }

    public int Next() {
        return curr[j++];
    }
}

/**
 * Your Vector2D will be called like this:
 * Vector2D i = new Vector2D(vec2d);
 * while (i.HasNext()) v[f()] = i.Next();
 */
