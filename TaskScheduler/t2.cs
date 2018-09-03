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
// Unlink t1.cs, use the built-in LinkedList for the scheduler queue.
public class Solution {
public class Solution {
    class Task {
    public int cnt;
    public char name;
    public Task(char c) { name = c; }
    }
    public int LeastInterval(char[] tasks, int n) {
        int currTime = 0;
        var map = new Dictionary<char, Task>();
        // Build map
        foreach(var c in tasks) {
            if (!map.ContainsKey(c))
                map[c] = new Task(c);
            map[c].cnt++;
        }
        
        // Schedule
        var l = map.Values.ToList();
        l.Sort((x,y) => (-x.cnt + y.cnt)); // sort by decreasing cnt
        var q = new LinkedList<Task>();
        foreach(var t in l)
            q.AddLast(t);
        
        var idle = new Task(' ');
        while(q.Count != 0) {
            currTime++;
            var task = q.First.Value;
            q.RemoveFirst();
            task.cnt--;
            if (task.cnt>0) {
                // search next n'th task                
                var target = q.First;
                int cnt = n;
                while(target != null && cnt>0) {
                    cnt--;
                    target = target.Next;
                }
                // Add idle if any
                while(cnt>0) {
                    q.AddLast(idle);
                    cnt--;
                }
                // search node whose cnt is smaller
                while(target != null && target.Value.cnt > task.cnt)
                    target = target.Next;
                // Insert it either before target or at the end
                if (target != null)
                    q.AddBefore(target, task);
                else q.AddLast(task);
            }
        }
        
        return currTime;
    }
}

