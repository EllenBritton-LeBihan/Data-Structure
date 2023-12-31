# Data-Structure | The Set data type
![](https://user-images.githubusercontent.com/114653081/212480507-413faa1c-7821-42ba-b617-47519764f3ce.svg)

This program runs code efficient calculations on an abstract data set, the set has no particular order and no repetition. The data in the set may be Bool, Char, Int or any other data structure.

## Operations on data set
```C#
- Clear the set.
- Empty the set.
- Return the size of the set.
- Return maximum number of values that the set can hold.
- Check if a value is in the set.
- print a list of elements in the set.
- add an element to the set.
- remove an element from the set.
- copy the set.
- test whether the set is a subset of another set.
- return intersection of both sets.
- return the symmetric difference between both sets.
```
- All the above operations were used using the Red-Black tree data structure. This data structure hold certain advantages, for example, maintaing balance and ensuring efficient operations for operations such as insertion, deletion and searching. By ensuring self-balancing the tree's height remains logarithmic, which leads to efficient search and insertions times (O(log n)).

- To gauge the code's efficiency, I employed two distinct data structures (Linked Lists and a greedy algorithm) to evaluate their performance in contrast to Red-Black Trees. The code samples for these evaluations can be found in the "Comparisons" folder, and the results are documented below: 

![red black tree](https://github.com/Neo-3l/Data-Structure/assets/114653081/215f73e3-ebef-4af9-914a-8bd7a90623d3)

![Greedy](https://github.com/Neo-3l/Data-Structure/assets/114653081/76c3cb07-b7b7-4386-b5a3-4cb2a2147a43)

![Linkedlist](https://github.com/Neo-3l/Data-Structure/assets/114653081/f34be5ce-9042-4832-aeab-37df287e86c9)

*(Comparison between compile and execution times of the different algorithms used for computing the operations)*

All of these data structures display considerable efficiency, with the Red-Black Tree emerging as the top performer overall. 
Speed test was carried out multiple times and averaged under the same environment and conditions. 

## Resources

- https://www.geeksforgeeks.org/introduction-to-red-black-tree/
- https://www.geeksforgeeks.org/data-structures/linked-list/
- https://www.geeksforgeeks.org/greedy-algorithms/
