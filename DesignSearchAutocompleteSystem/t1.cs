/*
Design a search autocomplete system for a search engine. Users may input a sentence (at least one word and end with a special character '#'). For each character they type except '#', you need to return the top 3 historical hot sentences that have prefix the same as the part of sentence already typed. Here are the specific rules:

The hot degree for a sentence is defined as the number of times a user typed the exactly same sentence before.
The returned top 3 hot sentences should be sorted by hot degree (The first is the hottest one). If several sentences have the same degree of hot, you need to use ASCII-code order (smaller one appears first).
If less than 3 hot sentences exist, then just return as many as you can.
When the input is a special character, it means the sentence ends, and in this case, you need to return an empty list.
Your job is to implement the following functions:

The constructor function:

AutocompleteSystem(String[] sentences, int[] times): This is the constructor. The input is historical data. Sentences is a string array consists of previously typed sentences. Times is the corresponding times a sentence has been typed. Your system should record these historical data.

Now, the user wants to input a new sentence. The following function will provide the next character the user types:

List<String> input(char c): The input c is the next character typed by the user. The character will only be lower-case letters ('a' to 'z'), blank space (' ') or a special character ('#'). Also, the previously typed sentence should be recorded in your system. The output will be the top 3 historical hot sentences that have prefix the same as the part of sentence already typed.


Example:
Operation: AutocompleteSystem(["i love you", "island","ironman", "i love leetcode"], [5,3,2,2]) 
The system have already tracked down the following sentences and their corresponding times: 
"i love you" : 5 times 
"island" : 3 times 
"ironman" : 2 times 
"i love leetcode" : 2 times 
Now, the user begins another search: 

Operation: input('i') 
Output: ["i love you", "island","i love leetcode"] 
Explanation: 
There are four sentences that have prefix "i". Among them, "ironman" and "i love leetcode" have same hot degree. Since ' ' has ASCII code 32 and 'r' has ASCII code 114, "i love leetcode" should be in front of "ironman". Also we only need to output top 3 hot sentences, so "ironman" will be ignored. 

Operation: input(' ') 
Output: ["i love you","i love leetcode"] 
Explanation: 
There are only two sentences that have prefix "i ". 

Operation: input('a') 
Output: [] 
Explanation: 
There are no sentences that have prefix "i a". 

Operation: input('#') 
Output: [] 
Explanation: 
The user finished the input, the sentence "i a" should be saved as a historical sentence in system. And the following input will be counted as a new search. 

Note:
The input sentence will always start with a letter and end with '#', and only one blank space will exist between two words.
The number of complete sentences that to be searched won't exceed 100. The length of each sentence including those in the historical data won't exceed 100.
Please use double-quote instead of single-quote when you write test cases even for a character input.
Please remember to RESET your class variables declared in class AutocompleteSystem, as static/class variables are persisted across multiple test cases. Please see here for more details.
*/
// Comment: Important. Since we're tracking top 3 only, I use manual comparision in the list.
// we could use a heap.
public class AutocompleteSystem {

    class Node {
        public Dictionary<char, Node> childs;
        public int cnt;
        public char ch;
        public Node() {
            childs = new Dictionary<char, Node>();
        }
        public Node(char c) {
            childs = new Dictionary<char, Node>();
            ch = c;
        }
        public Node parent;
    }
    Node root;
    Node current;
    public AutocompleteSystem(string[] sentences, int[] times) {
        root = new Node();
        for(int i=0; i<sentences.Length; i++) {
            string s = sentences[i];
            int t = times[i];
            Node curr = root;
            foreach(var c in s) {
                if (!curr.childs.ContainsKey(c)) {
                   curr.childs[c] = new Node(c); 
                }
                var next = curr.childs[c];
                next.parent = curr;
                curr = next;
            }
            curr.cnt = t;
        }
        current = root;
    }
    
    string getString(Node n) {
        StringBuilder b = new StringBuilder();
        while(n != root) {
            b.Append(n.ch);
            n = n.parent;
        }
        var t = b.ToString().ToCharArray();
        Array.Reverse(t);
        return new string(t);
    }
    
    public IList<string> Input(char c) {
        
        var ans = new List<string>();
        if (c == '#') {
            ++current.cnt;
            current = root;
            return ans;
        }
        
        if (!current.childs.ContainsKey(c))
            current.childs[c] = new Node(c);
        var next2 = current.childs[c];
        next2.parent = current;
        current = next2;
        
        List<Node> top = new List<Node>();
        void Rec(Node r) {
            if (r.cnt>0) {
                switch(top.Count) {
                    case 0:
                        top.Add(r);
                        break;
                    case 1:
                        if (top[0].cnt >= r.cnt)
                            top.Add(r);
                        else {
                            top.Add(top[0]);
                            top[0] = r;
                        }
                        break;
                    case 2:
                        if (top[1].cnt>= r.cnt)
                            top.Add(r);
                        else if (top[0].cnt>= r.cnt) {
                            top.Add(top[1]);
                            top[1] = r;
                        } else {
                            top.Add(top[1]);
                            top[1] = top[0];
                            top[0] = r;
                        }
                        break;
                    case 3:
                        if (top[2].cnt>= r.cnt) {}
                        else if (top[0].cnt < r.cnt) {
                            top[2] = top[1];
                            top[1] = top[0];
                            top[0] = r;
                        } else if (top[1].cnt < r.cnt) {
                            top[2] = top[1];
                            top[1] = r;
                        } else {
                            top[2] = r;
                        }
                        break;
                    default: 
                        break;
                }
            }
            
            var keys = r.childs.Keys.ToList();
            keys.Sort((x,y)=>{ return x - y;});
            foreach(var k in keys) {
                var next = r.childs[k];
                Rec(next);
            }
        }
        
        Rec(current);
        foreach(var n in top) {
            ans.Add(getString(n));
        }
        return ans;
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */
