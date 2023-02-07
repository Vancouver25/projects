using System;

class Node{
	public char data { get; set; }
    public List<Node> child { get; set; } = new List<Node>();
};


class Tree{	
	public Node root { get; set; }

	//Input data by creating new nodes
	public Tree(char input){
        root = new Node { 
			data = input 
		};
    }
	
	//Tree depth calculations using recursion for every child node
	public int get_depth(Node node){
		if (node == null)
		{
			return 0;
		}

		int depth = -1;
		foreach (Node child in node.child)
		{
			depth = Math.Max(depth, get_depth(child));
		}
		return depth + 1;
	}

	public static void Main(){
		/*Structure
		       A
		     /   \
			B     D 
		   /    / | \
	      C    E  G  H
              /	 
			 F  
        */
		//Input data into the structure
		Tree tree = new Tree('A');
		tree.root.child.Add(new Node { data = 'B' });
		tree.root.child[0].child.Add(new Node { data = 'C' });

		tree.root.child.Add(new Node { data = 'D' });
		tree.root.child[1].child.Add(new Node { data = 'E' });
		tree.root.child[1].child[0].child.Add(new Node { data = 'F' });

		tree.root.child[1].child.Add(new Node { data = 'G' });
		tree.root.child[1].child.Add(new Node { data = 'H' });

		//Calculate depth of the tree
		Console.WriteLine("Tree depth:  " + tree.get_depth(tree.root));	
	}   
};