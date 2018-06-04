/*
Given an Iterator class interface with methods: next() and hasNext(), design and implement a PeekingIterator that support the peek() operation -- it essentially peek() at the element that will be returned by the next call to next().
Example:
Assume that the iterator is initialized to the beginning of the list: [1,2,3].

Call next() gets you 1, the first element in the list.
Now you call peek() and it returns 2, the next element. Calling next() after that still return 2. 
You call next() the final time and it returns 3, the last element. 
Calling hasNext() after that should return false.
Follow up: How would you extend your design to be generic and work with all types, not just integer?
*/

// Comment: Recall how to access parent method
// Stash next value and its peek state until it's actually consumed by next()
// Below is the interface for Iterator, which is already defined for you.
// **DO NOT** modify the interface for Iterator.
class Iterator {
    struct Data;
	Data* data;
public:
	Iterator(const vector<int>& nums);
	Iterator(const Iterator& iter);
	virtual ~Iterator();
	// Returns the next element in the iteration.
	int next();
	// Returns true if the iteration has more elements.
	bool hasNext() const;
};


class PeekingIterator : public Iterator {
public:
    bool hasPeek;
    int dataPeek;
	PeekingIterator(const vector<int>& nums) : Iterator(nums) {
	    // Initialize any member here.
	    // **DO NOT** save a copy of nums and manipulate it directly.
	    // You should only use the Iterator interface methods.
	    hasPeek = false;
	}

    // Returns the next element in the iteration without advancing the iterator.
	int peek() {
        if (hasPeek)
            return dataPeek;
        
        if (!Iterator::hasNext())
            return Iterator::next();
        
        hasPeek = true;
        dataPeek = Iterator::next();
        
        return dataPeek;        
	}

	// hasNext() and next() should behave the same as in the Iterator interface.
	// Override them if needed.
	int next() {
	    if (!hasPeek)
            return Iterator::next();
        hasPeek = false;
        return dataPeek;
	}

	bool hasNext() const {
	    if (hasPeek) return true;
        return Iterator::hasNext();
	}
};

