# DataStructuresToolkit  
Author: Brittany Hancock  
Course: IT 415 Data Structures and Algorithms  
Term: Fall 2025  
Instructor: Lenore Montalbano  

============================================================

## Overview
This toolkit is a collection of data structures and algorithms implemented in C#.  
Each module demonstrates how its underlying structure behaves, how operations work internally, and how complexity affects performance.  
The project includes:

- Arrays and lists  
- Strings  
- Stacks and queues  
- Recursion  
- Sorting and searching  
- Binary trees, BSTs, AVL trees  
- Priority queues  
- Simple hash tables and associative containers  
- Singly and doubly linked lists  
- Graphs (NEW)  
- Set vs List benchmarking (NEW)  
- Console demos for each category  
- Full xUnit test coverage

All major components include XML documentation, validation logic, and clear complexity notes.

============================================================

## Project Structure
DataStructuresToolkit/  
Main library with all data structures and algorithm modules.

DataStructuresToolkit.Tests/  
xUnit tests covering every major structure.

DemoHarness/  
Console demos visualizing behavior, traversal, and performance.  
Includes the new Demo_GraphHelpers for this week's extension.

============================================================

# GraphHelpers (NEW)
Undirected graph module using adjacency lists.

### Features
- AddVertex  
- AddEdge (undirected, suppresses duplicates)  
- GetNeighbors  
- BFS  
- DFS  
- OrderBFS / OrderDFS  
- CountEdges  
- DegreeCounts  
- UniqueVertices  
- BuildAdjacencyList  

### Complexity
- AddVertex: O(1)  
- AddEdge: O(1)  
- GetNeighbors: O(1)  
- BFS: O(V + E)  
- DFS: O(V + E)  
- CountEdges: O(V + E)  
- DegreeCounts: O(V)  
- UniqueVertices: O(V log V)  

============================================================

## Demo_GraphHelpers (NEW)
Console demo output.

### Traversal Demo (BFS and DFS)

BFS from A:  
A  
B  
C  
D  
E  

DFS from A:  
A  
B  
D  
C  
E  

### CountEdges Demo

CountEdges(): 2

### DegreeCounts Demo

A:1  
B:2  
C:1  

### BuildAdjacencyList Demo

A -> B  
B -> A, C  
C -> B, A  

### UniqueVertices Demo

A  
B  
C  
D  

============================================================

## Benchmarking: List.Contains vs HashSet.Contains (NEW)

Searching for 999999...

List.Contains time: 1 ms  
HashSet.Contains time: 0 ms

Complexity difference demonstrated:
- List.Contains: O(n)  
- HashSet.Contains: O(1) average  

============================================================

## ArrayStringListHelpers
Helper methods for array, string, and list manipulation.

### Key Methods
InsertIntoArray  
DeleteFromArray  
ConcatenateNamesNaive  
ConcatenateNamesBuilder  
CapitalizeEachName  
InsertIntoList  

### Complexity
Array insert/delete: O(n)  
StringBuilder concat: O(n)  
List insert: O(n)  

============================================================

## ComplexityTester

RunConstantScenario: O(1)  
RunLinearScenario: O(n)  
RunQuadraticScenario: O(n squared)  

============================================================

## MyStack
Push, Pop, Peek, Count.  
Amortized O(1) operations. Resizes when needed.

============================================================

## MyQueue
Circular-array queue with wraparound and resizing.  
Enqueue and Dequeue in amortized O(1).

============================================================

## RecursionHelpers
Factorial, palindrome recursion, directory recursion.

============================================================

## SortingSearchingHelpers
BubbleSort: O(n squared)  
MergeSort: O(n log n)  
LinearSearch: O(n)  
BinarySearch: O(log n)

============================================================

## TreeToolkit and TreeNode
Binary tree, traversal helpers, height, depth.

============================================================

## Binary Search Tree (BST)
Insert, Contains, Height.

============================================================

## AVL Tree
Self-balancing BST with rotations and O(log n) operations.

============================================================

## Priority Queue
Min-heap with Enqueue and Dequeue in O(log n).

============================================================

## SimpleHashTable
Chaining hash table using List<int>.  
Average O(1), worst-case O(n).

============================================================

## AssociativeHelpers
Dictionary and HashSet helpers.

============================================================

## Linked Lists
SinglyLinkedList<T>: AddFirst, AddLast, Contains, Traverse.  
DoublyLinkedList<T>: forward and backward traversal, O(1) removal.

============================================================

## DemoHarness
Includes:
- Demo_StacksQueues  
- Demo_SortingSearching  
- Demo_LinkedLists  
- Demo_GraphHelpers (NEW)  
- TreeToolkitDemo  

============================================================

## Testing
All structures have xUnit test suites.  
GraphHelpers tests include:

- BFS  
- DFS  
- AddVertex  
- AddEdge  
- Duplicate suppression  
- CountEdges  
- DegreeCounts  
- UniqueVertices  
- BuildAdjacencyList  
- OrderBFS  
- OrderDFS  
- Boundary and negative cases  

============================================================

## Performance Analysis

### Stopwatch Timing: BubbleSort vs QuickSort
A timing demo was added to the project to compare two sorting algorithms on a reversed array.  
BubbleSort and QuickSort were measured using System.Diagnostics.Stopwatch after a JIT warm-up.

Sample Output:
```
Bubble Sort: 591 ms
QuickSort: 328 ms
```

This demonstrates the expected complexity difference:  
- BubbleSort: O(n^2), significantly slower on large inputs  
- QuickSort: O(n log n), consistently faster even on reversed arrays  

### Performance Profiler Snapshot
A CPU usage session was recorded using Visual Studio Performance Profiler.  
The profiler shows CPU distribution across DemoHarness and GraphHelpers modules.

Key profiler insights:
- Demo_GraphHelpers.RunBenchmarkDemo used the most CPU due to large List.Contains scans.
- BFS and DFS used very little CPU, which matches their O(V + E) complexity on a small graph.
- No unexpected hotspots or recursion issues were found.

Profiler Observation:  
"On small graphs (5 vertices), BFS and DFS complete almost instantly and rank near the bottom of CPU usage.  
Their cost becomes noticeable only when V and E increase, which confirms the linear-plus-edges complexity O(V + E)."

### Capstone Application Summary
Repeating these measurement techniques on the project graphs provided practical insight into performance behavior.

Findings:
- HashSet lookups stayed O(1) and always beat List.Contains.  
- BFS and DFS scaled as expected with stable performance.  
- Sorting demos clearly showed the difference between n^2 and n log n growth.

These measurements, screenshots, and profiler results are included in the Discussion 11 Showcase post.

### Screenshots

**BFS Timing Console Output**  
[Week11_FinalHandoff/Week11_BFSTimingConsoleOutput_Screenshot.png](Week11_FinalHandoff/Week11_BFSTimingConsoleOutput_Screenshot.png)

**Performance Profiler CPU Usage**  
[Week11_FinalHandoff/Week11_PerformanceProfiler_Screenshot.png](Week11_FinalHandoff/Week11_PerformanceProfiler_Screenshot.png)


============================================================

## Project Reflection
Building this toolkit made complexity visible in a practical way.  
Comparing naive and efficient approaches clarified how algorithm design relates to performance.  
Stacks, queues, recursion, and trees showed how structure determines behavior, while hash tables and AVL trees demonstrated the difference between average and worst-case scenarios.  
Adding linked lists strengthened my understanding of pointer manipulation and traversal logic.  
Extending the toolkit with GraphHelpers and benchmarking deepened my understanding of adjacency lists, traversal order, and the performance gap between linear and constant-time lookups.  
This project now serves as a reusable reference for both academic and real-world applications.
