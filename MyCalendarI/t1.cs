/*
Implement a MyCalendar class to store your events. A new event can be added if adding the event will not cause a double booking.

Your class will have the method, book(int start, int end). Formally, this represents a booking on the half open interval [start, end), the range of real numbers x such that start <= x < end.

A double booking happens when two events have some non-empty intersection (ie., there is some time that is common to both events.)

For each call to the method MyCalendar.book, return true if the event can be added to the calendar successfully without causing a double booking. Otherwise, return false and do not add the event to the calendar.

Your class will be called like this: MyCalendar cal = new MyCalendar(); MyCalendar.book(start, end)
Example 1:
MyCalendar();
MyCalendar.book(10, 20); // returns true
MyCalendar.book(15, 25); // returns false
MyCalendar.book(20, 30); // returns true
Explanation: 
The first event can be booked.  The second can't because time 15 is already booked by another event.
The third event can be booked, as the first event takes every time less than 20, but not including 20.
Note:

The number of calls to MyCalendar.book per test case will be at most 1000.
In calls to MyCalendar.book(start, end), start and end are integers in the range [0, 10^9].
*/
// Comment: Use BST to insert a node with log(n). If new range crosses a node, it means overlap (false). Visit left or right child recursively if both s/e is smaller or bigger than given node. To be eligible a left child (start-end), the parent node is "start". On the other hand, to be eligible a right child, the parent node should be end (!start).
public class MyCalendar {
    class Node {
        public int num;
        public bool start;
        public Node(int n, bool s)
        {
            num = n;
            start =s;
        }
        public Node left;
        public Node right;
    }
    Node root;
    public MyCalendar() {
    }
    
    bool Rec(Node n, int s, int e) {
        int v = n.num;
        if (s<v && e>v) return false;
        Node l= n.left;
        Node r = n.right;
        if (e<=v) {
            if (l != null)
                return Rec(l, s, e);
            if (!n.start)
                return false;
            n.left = new Node(s, true);
            n.left.right = new Node(e, false);
            return true;
        }
        // s>v
        if (r!=null)
            return Rec(r, s, e);
        if (n.start)
            return false;
        n.right = new Node(s, true);
        n.right.right = new Node(e, false);
        return true;
    }
    public bool Book(int start, int end) {
        if (root==null) {
            root = new Node(start, true);
            root.right = new Node(end, false);
            return true;
        }
        return Rec(root, start, end);
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */


