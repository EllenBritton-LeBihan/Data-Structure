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

-To measure efficiency of the code I used three different data structures (Linked Lists, Red-Black Trees and and compared time taken for them to compile and execute. These codes have been included in the "Comparisons" folder, and the results logged here: 
![image](https://github.com/Neo-3l/Data-Structure/assets/114653081/ccc3cb5a-d624-4086-b730-4750ec5163bc)

We can see that all of these are pretty efficient but the red-black tree comes out overall as the most performent. 
