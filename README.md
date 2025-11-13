# DataStructuresToolkit  
Author: Brittany Hancock  
Course: IT 415 Data Structures and Algorithms  
Term: Fall 2025  
Instructor: Lenore Montalbano  

============================================================

## Overview
This toolkit is a collection of data structures and algorithms implemented in C Sharp to demonstrate how each structure behaves, how operations work internally, and how complexity affects performance. The project includes arrays, lists, strings, stacks, queues, recursion, sorting, searching, binary trees, BSTs, AVL trees, priority queues, simple hash tables, associative containers, and console demos. Each module includes XML documentation, validation, and complexity notes. All major components are supported with xUnit tests.

============================================================

## Project Structure
DataStructuresToolkit contains the main library with all data structure and algorithm modules.  
DataStructuresToolkit.Tests contains xUnit tests for verification.  
DemoHarness contains console demos that visualize operations and show timing output.

============================================================

## ArrayStringListHelpers
Provides helper methods for arrays, strings, and lists based on common operations.

Key Methods  
InsertIntoArray shifts elements to the right and overwrites the last slot.  
DeleteFromArray shifts left and clears the tail.  
ConcatenateNamesNaive joins names using string concatenation and demonstrates O(n²).  
ConcatenateNamesBuilder joins names efficiently using StringBuilder.  
CapitalizeEachName formats words to uppercase first letters.  
InsertIntoList inserts items at any index in a List<int>.

Complexity  
Array insert and delete are O(n) time and constant space.  
StringBuilder concatenation is O(n).  
List inserts in the middle are O(n).

============================================================

## ComplexityTester
Shows constant, linear, and quadratic growth with timing output.

RunConstantScenario uses n(n+1)/2 and stays O(1).  
RunLinearScenario loops from 1 to n and is O(n).  
RunQuadraticScenario uses nested loops and reaches O(n²).

The purpose is to make growth rates visible through console timing.

============================================================

## MyStack
A generic LIFO stack with resizing.

Methods  
Push adds an item to the top and resizes when needed.  
Pop removes and returns the top item.  
Peek returns the top item without removing it.  
Count returns the number of stored items.

Complexity  
Push and Pop are amortized O(1).  
Resize is O(n).  
Memory use is O(n).

============================================================

## MyQueue
A generic FIFO queue using a circular array with automatic resizing.

Methods  
Enqueue adds to the back.  
Dequeue removes from the front.  
Peek returns the front item.  
Count returns the number of stored items.

Behavior  
Head and tail wrap around.  
Resize preserves order and doubles capacity.

Complexity  
Enqueue and Dequeue are amortized O(1).  
Resize is O(n).

============================================================

## RecursionHelpers
Three recursion examples showing mathematical, problem solving, and structural recursion.

Factorial calculates n factorial with a base case of zero.  
IsPalindrome checks a string by comparing ends and calling recursion on the substring.  
CountFilesRecursively walks a directory and subdirectories counting files.

Complexity  
Factorial and palindrome are O(n) time and O(n) space.  
Directory traversal is O(n) time and O(d) space.

============================================================

## SortingSearchingHelpers
Implements two sorting algorithms and two searching algorithms.

BubbleSort is quadratic and uses pairwise swaps.  
MergeSort divides data, sorts both halves, and merges them back together.  
LinearSearch scans from left to right.  
BinarySearch performs logarithmic search on sorted input.

Enhancements  
Timing measurements use microseconds.  
JIT warm up prevents first call timing distortion.  
Formatting makes comparisons readable.

Complexity  
BubbleSort O(n²)  
MergeSort O(n log n)  
LinearSearch O(n)  
BinarySearch O(log n)

============================================================

## TreeToolkit and TreeNode
Provides a simple binary tree with traversal and height utilities.

Features  
BuildTeachingTree creates a fixed structure for demonstration.  
Inorder, Preorder, and Postorder traverse the tree.  
Height returns the maximum depth.  
Depth finds the level of a specific value.

Complexity  
Traversal is O(n) time and O(h) space.

============================================================

## Binary Search Tree (BST)
A standard BST with integer values.

Insert places values recursively based on ordering.  
Contains checks for membership.  
Height returns tree height.

Complexity  
Average case O(log n) for insert and search.  
Worst case O(n) for skewed trees.

============================================================

## AVL Tree
A self balancing binary search tree with rotations.

Features  
Insert performs standard BST insertion then checks balance.  
Contains searches recursively.  
PrintTree displays node values with balance factors.  
GetHeight returns node height.  
GetBalance calculates height differences.  
RotateLeft and RotateRight rebalance the tree when needed.

Rotation Cases  
Left Left  
Right Right  
Left Right  
Right Left  

Complexity  
Insert and search are O(log n).  
Rotations are O(1).

============================================================

## Priority Queue
A min heap storing integers.

Enqueue inserts and bubbles up the value.  
Dequeue removes the root and bubbles down.  
HeapifyUp and HeapifyDown keep heap order.  
Count returns the number of items.

Complexity  
Insert and remove run in O(log n).  
Space is O(n).

============================================================

## SimpleHashTable
A basic hash table using chaining with List<int> buckets.

Insert computes key modulus bucket length and adds only if the key is not already present.  
Contains checks whether a key exists in its mapped bucket.  
PrintTable displays the contents of each bucket.

Complexity  
Average case O(1) for insert and contains.  
Worst case O(n) with many collisions.

============================================================

## AssociativeHelpers
Helpers showing built in containers.

BuildPhoneBook returns a Dictionary<string,string>.  
BuildFruitSet returns a HashSet<string> and shows that duplicates are ignored.

============================================================

## DemoHarness
Provides console demos for stacks and queues, sorting and searching, and tree operations.

Demo_StacksQueues  
Simulates undo history using MyStack and a print queue using MyQueue.  
Includes a performance test comparing stack and queue operations.

Demo_SortingSearching  
Compares BubbleSort, MergeSort, LinearSearch, and BinarySearch on arrays of size 100, 1000, and 10000.  
Outputs timing in microseconds after JIT warm up.

TreeToolkitDemo  
Runs all tree operations, prints traversals, calculates heights, and demonstrates BST and skewed tree behavior.

============================================================

## Testing
All modules are tested with xUnit.

Tests include  
ArrayStringListHelpers_Tests  
ComplexityTester_Tests  
MyStackTests  
MyQueueTests  
RecursionHelpersTests  
SortingSearchingHelpers tests planned  
TreeToolkit tests inside demos  
Bst tests inside traversal checks  
AvlTreeTests and AvlTreeHeightTests  
PriorityQueueTests  
SimpleHashTable_Tests  
AssociativeHelpers_Tests  

Test Coverage  
Insert, delete, resizing, wraparound, negative cases, exceptions, comparisons, height validation, and balancing logic.

============================================================

## Project Reflection
Building this toolkit helped me understand how each structure works internally and how complexity changes the performance of an operation. Implementing both naive and efficient algorithms made the differences visible, especially when timing the results in microseconds. The stack and queue demos gave me a clearer picture of how LIFO and FIFO behave in real scenarios. Recursion forced me to think in terms of base c
