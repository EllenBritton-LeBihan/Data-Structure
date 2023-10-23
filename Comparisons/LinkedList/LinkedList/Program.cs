using System;
using System.Collections.Generic;
using System.Diagnostics;

public class LinkedListSet
{
    // Create a linked list to store the elements of the set.
    private LinkedList<int> elements;

    public LinkedListSet()
    {
        elements = new LinkedList<int>();
    }

    // a)

    // Remove all elements from the set.
    public void Clear()
    {
        elements.Clear();
    }

    // Check whether the set is empty.
    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    // Return the number of elements in the set.
    public int Size()
    {
        return elements.Count;
    }

    // There's no fixed capacity in a linked list-based set, so return int.MaxValue.
    public int Capacity()
    {
        return int.MaxValue;
    }

    // Check if a value exists in the set.
    public bool Contains(int value)
    {
        return elements.Contains(value);
    }

    // Check whether a value is an element of the set.
    public bool IsElementOf(int x)
    {
        return elements.Contains(x);
    }

    // Print the list of elements in the set in the order they appear in the linked list.
    public void Print()
    {
        foreach (var element in elements)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    // b)

    // Add an element to the set if it is not already present.
    public void Add(int value)
    {
        if (!Contains(value))
        {
            elements.AddLast(value);
        }
    }

    // Remove an element from the set.
    public void Remove(int value)
    {
        elements.Remove(value);
    }

    // c)

    // Create a copy of the set.
    public LinkedListSet Copy()
    {
        LinkedListSet copySet = new LinkedListSet();
        foreach (var element in elements)
        {
            copySet.Add(element);
        }
        return copySet;
    }

    // Check if this set is a subset of another set.
    public bool IsSubset(LinkedListSet otherSet)
    {
        foreach (var element in elements)
        {
            if (!otherSet.Contains(element))
            {
                return false;
            }
        }
        return true;
    }

    // Find the intersection of two sets.
    public LinkedListSet Intersection(LinkedListSet otherSet)
    {
        LinkedListSet result = new LinkedListSet();
        foreach (var element in elements)
        {
            if (otherSet.Contains(element))
            {
                result.Add(element);
            }
        }
        return result;
    }

    // Find the symmetric difference of two sets.
    public LinkedListSet SymmetricDifference(LinkedListSet otherSet)
    {
        LinkedListSet result = new LinkedListSet();

        // Add elements from this set that are not in the other set.
        foreach (var element in elements)
        {
            if (!otherSet.Contains(element))
            {
                result.Add(element);
            }
        }

        // Add elements from the other set that are not in this set.
        foreach (var element in otherSet.elements)
        {
            if (!elements.Contains(element))
            {
                result.Add(element);
            }
        }

        return result;
    }
}

public class LinkedListSets
{
    public static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        LinkedListSet set = new LinkedListSet();
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

        LinkedListSet copy = set.Copy();
        Console.WriteLine("Copy of the set: ");
        copy.Print();

        LinkedListSet subset = new LinkedListSet();
        subset.Add(1);
        subset.Add(2);
        Console.WriteLine("Is the subset {1, 2} a subset of the set? " + set.IsSubset(subset));

        LinkedListSet intersection = set.Intersection(subset);
        Console.WriteLine("Intersection of the set and the subset {1, 2}: ");
        intersection.Print();

        LinkedListSet symmetricDifference = set.SymmetricDifference(subset);
        Console.WriteLine("Symmetric difference of the set and the subset {1, 2}: ");
        symmetricDifference.Print();

        stopwatch.Stop();
        double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Time taken for linked list : {elapsedTimeInSeconds} seconds");
    }
}