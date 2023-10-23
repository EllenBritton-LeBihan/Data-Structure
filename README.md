# Data-Structure - The Set data type

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

![image](https://github.com/Neo-3l/Data-Structure/assets/114653081/9f8fd42e-1abf-4ab2-b251-f33f5ddb340c)

![image](https://github.com/Neo-3l/Data-Structure/assets/114653081/9545c506-8ada-4094-8918-e0ea353e5aed)

![image](https://github.com/Neo-3l/Data-Structure/assets/114653081/b2f96cff-9193-4a73-a13f-6792ed3267da)
*Comparison between compile and execution times*

All of these data structures display considerable efficiency, with the Red-Black Tree emerging as the top performer overall. 
