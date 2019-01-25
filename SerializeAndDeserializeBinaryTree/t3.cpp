/*
Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

Example: 

You may serialize the following tree:

    1
   / \
  2   3
     / \
    4   5

as "[1,2,3,null,null,4,5]"
Clarification: Just the same as how LeetCode OJ serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.

Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.

*/
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Codec {
public:
    string ans1;
    void Rec(TreeNode* root) {
        if (!root) {
            ans1+= " #";
            return;
        }
        ans1 += " " + to_string(root->val);
        Rec(root->left);
        Rec(root->right);
    }
    // Encodes a tree to a single string.
    string serialize(TreeNode* root) {
        Rec(root);
        return ans1;
    }

    string str;
    int len;
    int i;
    string getNext() {
        while(i<len && str[i]==' ') i++;
        if (i==len) return "";
        int j = str.find(' ',  i); // spoiler: find char, start idx
        if (j==string::npos) j = len;
        auto t = str.substr(i, j-i);
        i = j;
        return t;
    } 
    
    TreeNode* Rec2(TreeNode* n) {
        string m = getNext();
        if (m!="#") {
            auto l = new TreeNode(stoi(m));
            n->left = l;
            Rec2(l);
        }
        m = getNext();
        if (m!="#") {
            auto r = new TreeNode(stoi(m));
            n->right = r;
            Rec2(r);
        }
      
        return n;
    }
    // Decodes your encoded data to tree.
    TreeNode* deserialize(string data) {
        str = data; 
        i = 0; len = data.size();
        string n = getNext();
        if (n=="#") return nullptr;
        return Rec2(new TreeNode(stoi(n)));
    }
};

// Your Codec object will be instantiated and called as such:
// Codec codec;
// codec.deserialize(codec.serialize(root));
