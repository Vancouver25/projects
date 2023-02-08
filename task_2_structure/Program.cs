using System;

class Node
{
	private char _data;
	private List<Node> _child;

	public Node(char data)
	{
		_data = data;
		_child = new List<Node>();
	}


	//Output private data field value
	public char GetData()
	{
		return _data; 
	}

	//Output private child field value
	public List<Node> GetChild()
	{
		return _child; 
	}
};

class Tree
{
	private Node _root;

	public Tree(char input)
	{
		_root = new Node(input);
	}


	//Output private root field value
	public Node GetRoot()
	{
		return _root; 	
	}

	public int GetDepth(Node node)
	{
		if (node == null)
		{
			return 0;
		}

		int maxDepth = -1;
		foreach (Node child in node.GetChild())
		{
			maxDepth = Math.Max(maxDepth, GetDepth(child));
		}
		return maxDepth + 1;
	}

	public static void Main()
	{
		/*Structure
		       A
		     /   \
			B     D 
		   /    / | \
	      C    E  G  H
              /	 
			 F  
        */
		//Input data to create a structure
		Tree tree = new Tree('A');
		tree.GetRoot().GetChild().Add(new Node('B'));
		tree.GetRoot().GetChild()[0].GetChild().Add(new Node('C'));

		tree.GetRoot().GetChild().Add(new Node('D'));
		tree.GetRoot().GetChild()[1].GetChild().Add(new Node('E'));
		tree.GetRoot().GetChild()[1].GetChild()[0].GetChild().Add(new Node('F'));

		tree.GetRoot().GetChild()[1].GetChild().Add(new Node('G'));
		tree.GetRoot().GetChild()[1].GetChild().Add(new Node('H'));
		
		Console.WriteLine("MaxDepth: " + tree.GetDepth(tree.GetRoot()));
	}   
};