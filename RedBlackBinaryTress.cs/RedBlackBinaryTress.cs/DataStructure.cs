using System;
using System.Diagnostics;
public class RedBlackTreeSet
{
    private class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public bool IsRed;
        public int Size;

        public Node(int value)
        {
            Value = value;
            IsRed = true;
            Size = 1;
        }
    }

    //to access tree
    private Node root;


    //create Red Black tree set
    public RedBlackTreeSet()
    {
        root = null;
    }

    // a)

    //removes all elements from the set.
    public void Clear()
    {
        root = null;
    }

    //checks whether the set is empty.
    public bool IsEmpty()
    {
        return root == null;
    }


    //returns the number of elements in the set.
    public int Size()
    {
        return Size(root);
    }
    private int Size(Node node)
    {
        if (node == null)
            return 0;
        return node.Size;
    }

    //returns max number of elements in set...
    public int Capacity()
    {
        // Since Red Black Tree is a dynamic data structure there is no fixed capacity.
        return int.MaxValue;
    }
    public bool Contains(int value)
    {
        return Contains(root, value);
    }
    private bool Contains(Node node, int value)
    {
        if (node == null)
            return false;

        if (value < node.Value)
            return Contains(node.Left, value);
        else if (value > node.Value)
            return Contains(node.Right, value);
        else
            return true;
    }

    //is element of checks whether value x is in the set.
    public bool IsElementOf(int x)
    {
        return IsElementOf(root, x);
    }
    private bool IsElementOf(Node node, int x)
    {
        if (node == null)
            return false;

        if (x < node.Value)
            return IsElementOf(node.Left, x);
        else if (x > node.Value)
            return IsElementOf(node.Right, x);
        else
            return true;
    }

    //prints list of elements in set in some arbitrary order
    public void Print()
    {
        PrintInOrder(root);
        Console.WriteLine();
    }

    private void PrintInOrder(Node node)
    {
        if (node == null)
            return;

        PrintInOrder(node.Left);
        Console.Write(node.Value + " ");
        PrintInOrder(node.Right);
    }


    //  b)

    //adds element to set, if it is not already present.
    public void Add(int value)
    {
        //check if value being added is in a valid range.
        if (value < int.MinValue || value > int.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(value), "Value is out of range.");

        root = Add(root, value);
        root.IsRed = false;
    }
    private Node Add(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = Add(node.Left, value);
        else if (value > node.Value)
            node.Right = Add(node.Right, value);

        if (IsRed(node.Right) && !IsRed(node.Left))
            node = RotateLeft(node);
        if (IsRed(node.Left) && IsRed(node.Left.Left))
            node = RotateRight(node);
        if (IsRed(node.Left) && IsRed(node.Right))
            FlipColours(node);

        node.Size = 1 + Size(node.Left) + Size(node.Right);
        return node;
    }

    //removes element from set.
    public void Remove(int value)
    {

        if (!Contains(value))
            throw new ArgumentException("Value does not exist in the tree.", nameof(value));

        if (!IsRed(root.Left) && !IsRed(root.Right))
            root.IsRed = true;

        root = Remove(root, value);
        if (root != null)
            root.IsRed = false;
    }
    private Node Remove(Node node, int value)
    {
        if (value < node.Value)
        {
            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                node = MoveRedLeft(node);
            node.Left = Remove(node.Left, value);
        }
        else
        {
            if (IsRed(node.Left))
                node = RotateRight(node);
            if (value == node.Value && node.Right == null)
                return null;
            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                node = MoveRedRight(node);
            if (value == node.Value)
            {
                Node minNode = Minimum(node.Right);
                node.Value = minNode.Value;
                node.Right = DeleteMin(node.Right);
            }
            else
            {
                node.Right = Remove(node.Right, value);
            }
        }

        node.Size = Size(node.Left) + Size(node.Right) + 1;
        return node;
    }

    private Node Minimum(Node node)
    {
        if (node.Left == null)
            return node;
        return Minimum(node.Left);
    }

    private Node DeleteMin(Node node)
    {
        if (node.Left == null)
            return null;

        if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            node = MoveRedLeft(node);

        node.Left = DeleteMin(node.Left);
        return Balance(node);
    }

    //performs left notation on given node.
    private Node RotateLeft(Node node)
    {
        Node x = node.Right;
        node.Right = x.Left;
        x.Left = node;
        x.IsRed = node.IsRed;
        node.IsRed = true;
        x.Size = node.Size;
        node.Size = 1 + Size(node.Left) + Size(node.Right);
        return x;
    }

    //performs right notation on given node.
    private Node RotateRight(Node node)
    {
        Node x = node.Left;
        node.Left = x.Right;
        x.Right = node;
        x.IsRed = node.IsRed;
        node.IsRed = true;
        x.Size = node.Size;
        node.Size = 1 + Size(node.Left) + Size(node.Right);
        return x;
    }

    //flips Colours of input node and its two children
    private void FlipColours(Node node)
    {
        node.IsRed = !node.IsRed;
        node.Left.IsRed = !node.Left.IsRed;
        node.Right.IsRed = !node.Right.IsRed;
    }

    //moves red node to left to balance operations in red tree.
    private Node MoveRedLeft(Node node)
    {
        FlipColours(node);
        if (IsRed(node.Right.Left))
        {
            node.Right = RotateRight(node.Right);
            node = RotateLeft(node);
            FlipColours(node);
        }
        return node;
    }

    //moves red node to right to balance operations in red tree.
    private Node MoveRedRight(Node node)
    {
        FlipColours(node);
        if (IsRed(node.Left.Left))
        {
            node = RotateRight(node);
            FlipColours(node);
        }
        return node;
    }

    //performs various balancing operations on tree to maintain red black tree properties after insertion or deletion.
    private Node Balance(Node node)
    {
        if (IsRed(node.Right))
            node = RotateLeft(node);
        if (IsRed(node.Left) && IsRed(node.Left.Left))
            node = RotateRight(node);
        if (IsRed(node.Left) && IsRed(node.Right))
            FlipColours(node);
        node.Size = Size(node.Left) + Size(node.Right) + 1;
        return node;
    }
    private bool IsRed(Node node)
    {
        if (node == null)
            return false;
        return node.IsRed;
    }

    //c)

    //returns a copy of a set.
    public RedBlackTreeSet Copy()
    {
        RedBlackTreeSet copySet = new RedBlackTreeSet();
        Copy(root, copySet);
        return copySet;
    }
    private void Copy(Node node, RedBlackTreeSet copySet)
    {
        if (node == null)
            return;

        Copy(node.Left, copySet);
        copySet.Add(node.Value);
        Copy(node.Right, copySet);
    }

    //tests if set is a subset of otherSet.
    public bool IsSubset(RedBlackTreeSet otherSet)
    {
        if (otherSet == null)
            throw new ArgumentNullException(nameof(otherSet));

        return IsSubset(root, otherSet.root);
    }
    private bool IsSubset(Node node1, Node node2)
    {
        if (node2 == null)
            return true;
        if (node1 == null)
            return false;

        if (node1.Value < node2.Value)
            return IsSubset(node1.Right, node2);
        else if (node1.Value > node2.Value)
            return false;
        else
            return IsSubset(node1.Left, node2.Left) && IsSubset(node1.Right, node2.Right);
    }

    //returns intersection of set and otherSet.
    public RedBlackTreeSet Intersection(RedBlackTreeSet otherSet)
    {
        if (otherSet == null)
            throw new ArgumentNullException(nameof(otherSet));

        RedBlackTreeSet result = new RedBlackTreeSet();
        Intersection(root, otherSet.root, result);
        return result;
    }
    private void Intersection(Node node1, Node node2, RedBlackTreeSet result)
    {
        if (node1 == null || node2 == null)
            return;

        if (node1.Value < node2.Value)
            Intersection(node1.Right, node2, result);
        else if (node1.Value > node2.Value)
            Intersection(node1, node2.Right, result);
        else
        {
            Intersection(node1.Left, node2.Left, result);
            result.Add(node1.Value);
            Intersection(node1.Right, node2.Right, result);
        }
    }


    //returns symmetric difference of set and otherSet.
    public RedBlackTreeSet SymmetricDifference(RedBlackTreeSet otherSet)
    {
        if (otherSet == null)
            throw new ArgumentNullException(nameof(otherSet));

        RedBlackTreeSet result = new RedBlackTreeSet();
        SymmetricDifference(root, otherSet.root, result);
        return result;
    }
    private void SymmetricDifference(Node node1, Node node2, RedBlackTreeSet result)
    {
        if (node1 == null && node2 == null)
            return;

        if (node1 == null)
        {
            SymmetricDifference(node1, node2.Right, result);
            result.Add(node2.Value);
            SymmetricDifference(node1, node2.Left, result);
        }
        else if (node2 == null)
        {
            SymmetricDifference(node1.Left, node2, result);
            result.Add(node1.Value);
            SymmetricDifference(node1.Right, node2, result);
        }
        else
        {
            if (node1.Value < node2.Value)
            {
                SymmetricDifference(node1.Left, node2, result);
                result.Add(node1.Value);
                SymmetricDifference(node1.Right, node2, result);
            }
            else if (node1.Value > node2.Value)
            {
                SymmetricDifference(node1, node2.Left, result);
                result.Add(node2.Value);
                SymmetricDifference(node1, node2.Right, result);
            }
            else
            {
                SymmetricDifference(node1.Left, node2.Left, result);
                SymmetricDifference(node1.Right, node2.Right, result);
            }
        }
    }
}
public class RedBlackTrees
{
    //to test functions
    public static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        RedBlackTreeSet set = new RedBlackTreeSet();
        set.Add(1);
        set.Add(4);
        set.Add(7);

        Console.WriteLine("Set: ");
        set.Print();

        Console.WriteLine("Is empty? " + set.IsEmpty());
        Console.WriteLine("Size: " + set.Size());
        Console.WriteLine("Capacity: " + set.Capacity());

        Console.WriteLine("Is 4 in the set? " + set.Contains(4)); // Output: true
        Console.WriteLine("Is 5 in the set? " + set.IsElementOf(5)); // Output: False
        Console.WriteLine("Is 1 in the set? " + set.IsElementOf(1)); // Output: true

        Console.WriteLine("Adding 2 to the set");
        set.Add(2);
        Console.WriteLine("Set after adding 2: ");
        set.Print();

        Console.WriteLine("Removing 4 from the set");
        set.Remove(4);
        Console.WriteLine("Set after removing 4: ");
        set.Print();

        RedBlackTreeSet copy = set.Copy();
        Console.WriteLine("Copy of the set: ");
        copy.Print();

        RedBlackTreeSet subset = new RedBlackTreeSet();
        subset.Add(1);
        subset.Add(2);
        Console.WriteLine("Is the subset {1, 2} a subset of the set? " + set.IsSubset(subset));

        RedBlackTreeSet intersection = set.Intersection(subset);
        Console.WriteLine("Intersection of the set and the subset {1, 2}: ");
        intersection.Print();

        RedBlackTreeSet symmetricDifference = set.SymmetricDifference(subset);
        Console.WriteLine("Symmetric difference of the set and the subset {1, 2}: ");
        symmetricDifference.Print();

        stopwatch.Stop();
        double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Time taken for Red-Black Tree was: {elapsedTimeInSeconds} seconds");
    }
}