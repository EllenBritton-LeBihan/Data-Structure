using System;
using System.Diagnostics;

public class GreedySet
{
    private int[] elements;
    private int size;
    private const int DefaultCapacity = 16;

    public GreedySet()
    {
        elements = new int[DefaultCapacity];
        size = 0;
    }

    public void Clear()
    {
        elements = new int[DefaultCapacity];
        size = 0;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public int Size()
    {
        return size;
    }

    public int Capacity()
    {
        return elements.Length;
    }

    public bool Contains(int value)
    {
        return Array.IndexOf(elements, value) != -1;
    }

    public bool IsElementOf(int x)
    {
        return Contains(x);
    }

    public void Print()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(elements[i] + " ");
        }
        Console.WriteLine();
    }

    public void Add(int value)
    {
        if (!Contains(value))
        {
            if (size == elements.Length)
            {
                // If the array is full, double its capacity
                Array.Resize(ref elements, elements.Length * 2);
            }
            elements[size++] = value;
        }
    }

    public void Remove(int value)
    {
        int index = Array.IndexOf(elements, value);
        if (index != -1)
        {
            for (int i = index; i < size - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
            size--;
        }
    }

    public GreedySet Copy()
    {
        GreedySet copySet = new GreedySet();
        for (int i = 0; i < size; i++)
        {
            copySet.Add(elements[i]);
        }
        return copySet;
    }

    public bool IsSubset(GreedySet otherSet)
    {
        if (otherSet == null)
            throw new ArgumentNullException(nameof(otherSet));

        for (int i = 0; i < otherSet.size; i++)
        {
            if (!Contains(otherSet.elements[i]))
            {
                return false;
            }
        }
        return true;
    }

    public GreedySet Intersection(GreedySet otherSet)
    {
        if (otherSet == null)
            throw new ArgumentNullException(nameof(otherSet));

        GreedySet result = new GreedySet();
        for (int i = 0; i < size; i++)
        {
            if (otherSet.Contains(elements[i]))
            {
                result.Add(elements[i]);
            }
        }
        return result;
    }

    public GreedySet SymmetricDifference(GreedySet otherSet)
    {
        if (otherSet == null)
            throw new ArgumentNullException(nameof(otherSet));

        GreedySet result = new GreedySet();

        for (int i = 0; i < size; i++)
        {
            if (!otherSet.Contains(elements[i]))
            {
                result.Add(elements[i]);
            }
        }

        for (int i = 0; i < otherSet.size; i++)
        {
            if (!Contains(otherSet.elements[i]))
            {
                result.Add(otherSet.elements[i]);
            }
        }

        return result;
    }
}

public class GreedySets
{
    public static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        GreedySet set = new GreedySet();
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

        GreedySet copy = set.Copy();
        Console.WriteLine("Copy of the set: ");
        copy.Print();

        GreedySet subset = new GreedySet();
        subset.Add(1);
        subset.Add(2);
        Console.WriteLine("Is the subset {1, 2} a subset of the set? " + set.IsSubset(subset));

        GreedySet intersection = set.Intersection(subset);
        Console.WriteLine("Intersection of the set and the subset {1, 2}: ");
        intersection.Print();

        GreedySet symmetricDifference = set.SymmetricDifference(subset);
        Console.WriteLine("Symmetric difference of the set and the subset {1, 2}: ");
        symmetricDifference.Print();

        stopwatch.Stop();
        double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Time taken for Greedy Algorithm was : {elapsedTimeInSeconds} seconds");
    }
}