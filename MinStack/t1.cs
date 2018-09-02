/*
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time. 
push(x) -- Push element x onto stack. 
pop() -- Removes the element on top of the stack. 
top() -- Get the top element. 
getMin() -- Retrieve the minimum element in the stack. 

Example:
MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin();   --> Returns -3.
minStack.pop();
minStack.top();      --> Returns 0.
minStack.getMin();   --> Returns -2.
*/
// Comment: Use two stacks
public class MinStack {
    int min;
    Stack<int> mstack;
    Stack<int> stack;
    /** initialize your data structure here. */
    public MinStack() {
        min = Int32.MaxValue;
        mstack = new Stack<int>();
        stack = new Stack<int>();
    }
    
    public void Push(int x) {
        stack.Push(x);
        if (x< min)
            min = x;
        mstack.Push(min);
    }
    
    public void Pop() {
        stack.Pop();
        mstack.Pop();
        min = mstack.Count==0? Int32.MaxValue : mstack.Peek();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */