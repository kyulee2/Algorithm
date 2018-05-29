/*
Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks.Tasks could be done without original order. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle.
However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle. 
You need to return the least number of intervals the CPU will take to finish all the given tasks.
Example 1:
Input: tasks = ["A","A","A","B","B","B"], n = 2
Output: 8
Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.

Note:
The number of tasks is in the range [1, 10000].
The integer n is in the range [0, 100].
*/
// Comment: By acutally scheduling/running task, count the number of runs/loops.
// Initially, sort tasks by cnt. When running the first task (at head), reduce cnt.
// Place the task by traversing the next task 'n' times. If the end is reached, insert idle node.
// If the current insertion point has the higher cnt, push the taks further to the right until satisfied.
public class Solution {
    class Node {
        public Node(char c) { ch = c;}
        public Node next;
        public Node prev;
        public int cnt;
        public char ch;
    }
    class TaskQ {
        public TaskQ() {
            head = new Node(' ');
            tail = new Node(' ');
            head.next = tail;
            tail.prev = head;                
        }
        public Node head;
        public Node tail;
        public void Add(Node n) {
            tail.prev.next = n;
            n.prev = tail.prev;
            n.next = tail;
            tail.prev = n;
        }
        public void Remove(Node n) {
            n.prev.next = n.next;
            n.next.prev = n.prev;
        }  
    }
    public int LeastInterval(char[] tasks, int n) {
        // sort by cnt
        Dictionary<char, Node> map = new Dictionary<char, Node>();
        foreach(var c in tasks) {
            if (!map.ContainsKey(c)) map[c] = new Node(c);
            ++map[c].cnt;
        }
        List<Node> list = map.Values.ToList();
        list.Sort((x,y) => x.cnt - y.cnt);
        list.Reverse();
        
        // Put it into TaskQ
        TaskQ q = new TaskQ();
        foreach(var l in list)
            q.Add(l);
        
        // Schedule it by running
        int ans = 0;
        while(q.head.next != q.tail) {
            ans++;
            Node first = q.head.next;
            q.Remove(first);
            if (first.ch == '-') continue; // skip idle node
            first.cnt--;
            if (first.cnt == 0) continue; // skip the finished 

            Node curr = q.head.next;
            for(int i=0; i<n; i++) {
                if (curr == q.tail) {
                    for(; i<n; i++) {
                        q.Add(new Node('-')); // Add an idle node
                    }
                    break;
                }
                else {
                    curr = curr.next;
                }                
            }
          
            // Priotize the higher cnt node  
            while(curr != q.tail) {
                if (first.cnt >= curr.cnt)
                    break;
                curr = curr.next;
            }
            
            curr.prev.next = first;
            first.prev = curr.prev;
            first.next = curr;
            curr.prev = first;
        }
        
        return ans;
    }
}

