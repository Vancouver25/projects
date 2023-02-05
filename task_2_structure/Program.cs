
using System;

//Ignore null variable warnings 
#pragma warning disable CS8618, CS8601, CS8625


//Used data structure is a tree, every node can have maximum 3 children nodes
//Tree depth calculations  were made using recursion
class Program{	

	class Node{

	public Node left, middle, right;
	public char data;

	//Initial values constructor
	public Node(){
		left = right = middle = null;
		data = '\0';
	}

	//Data input constructor
	public Node(Char input){
		data = input;
	}
	
	//Destructor  
	~Node(){}

	};


	//Input data by creating new nodes
	static Node add_node(char new_node){
		Node a = new Node();
		a.data = new_node;
		return a;
	}

	//Calculate depth using recursion
	//Tree depth = total number of edges from the root node to the most distant leaf node
	 static int find_depth(Node node, int depth){
        if (node == null){
            return depth-1;
		}

        int left_depth = find_depth(node.left, depth + 1);
        int middle_depth = find_depth(node.middle, depth + 1);
        int right_depth = find_depth(node.right, depth + 1);
        
        return Math.Max(Math.Max(left_depth, middle_depth), right_depth);
    }

	public static void Main(){
		/*Structure
		       A
		     /   \
			B     D 
		   /    / | \
	      C    E  G  K
              /	 
			 F  
        */
		 //Input data into the structure
		 char []data = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
    
		 Node root = add_node(data[0]);
		 root.left = add_node(data[1]);
		 root.left.left = add_node(data[2]);

		 root.right = add_node(data[3]);
		 root.right.left = add_node(data[4]);
		 root.right.left.left = add_node(data[5]);

		 root.right.middle = add_node(data[6]);
		 root.right.right = add_node(data[7]);


		//Calculate tree depth, pass the structure root node and current root depth 0 
		int depth = find_depth(root, 0);
		Console.WriteLine("Tree depth: " + depth);
    }
    
};
