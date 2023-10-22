# Data-Structure - The Set data type

This program runs code efficient calculations on an abstract set, the set has no particular order and no repetition. The data in the set may be Bool, char, int or any other data structure.

##Operations on data set
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

-To measure efficiency of the code I used various data structures and compared time taken for it to compile and execute. These codes have been included in the "Comparisons" folder, and the results logged here: 

-By adding a "stopwatch" to the main function of the C# project we can see that 
