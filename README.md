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
- Console demos for each category  
- Full xUnit test coverage

All major components include XML documentation, validation logic, and clear complexity notes.

============================================================

## Project Structure
**DataStructuresToolkit/**  
Main library with all data structures and algorithm modules.

**DataStructuresToolkit.Tests/**  
xUnit tests covering every major structure.

**DemoHarness/**  
Console demos that visualize behavior, order of operations, performance, and traversal output.

============================================================

## ArrayStringListHelpers
Helper methods for array, string, and list manipulation.

### Key Methods
- **InsertIntoArray** — shifts elements right and overwrites tail.  
- **DeleteFromArray** — shifts left and clears last slot.  
- **ConcatenateNamesNaive** — O(n²) due to repeated string concatenation.  
- **ConcatenateNamesBuilder** — O(n) using `StringBuilder`.  
- **CapitalizeEachName** — title-cases words in a sentence.  
- **InsertIntoList** — inserts at any index of a `List<int>`.

### Complexity
- Array insert/delete: **O(n)**  
- `StringBuilder` concat: **O(n)**  
- List insert: **O(n)**  

============================================================

## ComplexityTester
Shows constant, linear, and quadratic growth with timing output.

- **RunConstantScenario** — O(1)  
- **RunLinearScenario** — O(n)  
- **RunQuadraticScenario** — O(n²)  

Emphasizes the visible difference in timing as `n` increases.

============================================================

## MyStack
A generic LIFO stack with dynamic resizing.

### Operations
- **Push** — adds item; triggers resize if needed.  
- **Pop** — removes and returns top item.  
- **Peek** — views top without removing.  
- **Count** — current elements.

### Complexity
- Push/Pop: **amortized O(1)**  
- Resize: **O(n)**  

============================================================

## MyQueue
A circular-array queue with automatic resizing.

### Operations
- **Enqueue** — add to back.  
- **Dequeue** — remove from front.  
- **Peek** — view front.  
- **Count** — number of items.

### Behavior
- Head and tail wrap around.
- Resize preserves FIFO.

### Complexity
- Enqueue/Dequeue: **amortized O(1)**  
- Resize: **O(n)**  

============================================================

## RecursionHelpers
Three recursion examples demonstrating mathematical, structural, and directory recursion.

- **Factorial** — simple recursion with base case 0.  
- **IsPalindrome** — compares ends and recurses inward.  
- **CountFilesRecursively** — directory traversal.

### Complexity
- Factorial: **O(n)** time, **O(n)** space  
- Palindrome: **O(n)** time, **O(n)** space  
- Directory traversal: **O(n)** time, **O(d)** space  

============================================================

## SortingSearchingHelpers
Sorting and searching algorithms with microsecond timing.

- **BubbleSort** — O(n²)  
- **MergeSort** — O(n log n)  
- **LinearSearch** — O(n)  
- **BinarySearch** — O(log n)

Includes warm-ups to remove JIT distortion.

============================================================

## TreeToolkit and TreeNode
A simple binary tree supporting:

- **BuildTeachingTree**  
- **Inorder, Preorder, Postorder**  
- **Height**  
- **Depth** for locating a specific value  

### Complexity
Traversal: **O(n)**  
Space: **O(h)** (recursive stack)

============================================================

## Binary Search Tree (BST)
A classic integer BST.

- **Insert** — recursively adds values.  
- **Contains** — search.  
- **Height** — returns depth.  

### Complexity
- Average: **O(log n)**  
- Worst-case: **O(n)** (skewed)

============================================================

## AVL Tree
Self-balancing BST with automatic rotations.

### Features
- **Insert** — BST insert + rebalance.  
- **Contains** — recursive search.  
- **PrintTree** — prints keys with balance factors.  
- **RotateLeft / RotateRight**  
- **GetHeight / GetBalance**

### Rotation Cases
- Left Left  
- Right Right  
- Left Right  
- Right Left  

### Complexity
All operations: **O(log n)**  

============================================================

## Priority Queue
A min-heap storing ints.

### Operations
- **Enqueue** — bubble up.  
- **Dequeue** — bubble down.  
- **Count** — size.

### Complexity
- Insert/remove: **O(log n)**  
- Space: **O(n)**  

============================================================

## SimpleHashTable
Hash table using **chaining (List<int>)**.

- **Insert** — avoids duplicates.  
- **Contains** — membership check.  
- **PrintTable** — shows buckets.

### Complexity
- Average: **O(1)**  
- Worst-case: **O(n)** (collision chain)

============================================================

## AssociativeHelpers
Uses built-in generic containers.

- **BuildPhoneBook** → `Dictionary<string,string>`  
- **BuildFruitSet** → `HashSet<string>`  

============================================================

## Linked Lists (NEW)
Full implementation of both singly and doubly linked lists.

### SinglyLinkedList<T>
- **AddFirst**  
- **AddLast**  
- **Contains**  
- **Traverse**  

Complexity: O(n) traversal, O(1) insert at head.

### DoublyLinkedList<T>
- **AddFirst**  
- **AddLast**  
- **TraverseForward / TraverseBackward**  
- **Remove(node)** — adjusts prev/next pointers  

Complexity: O(1) node removal when node reference is known.

============================================================

## DemoHarness
Console demos that show full behavior and timing.

### Demo_StacksQueues
- Undo stack  
- Print queue  
- Performance test (100,000 ops)  

### Demo_SortingSearching
- Microsecond timing output  
- Bubble vs Merge  
- Linear vs Binary

### Demo_LinkedLists (NEW)
- SinglyLinkedList demo  
- DoublyLinkedList demo  
- Built-in LinkedList<T> comparison  

### TreeToolkitDemo
- Traversals  
- BST behavior  
- Skewed BST height demonstration  

============================================================

## Testing
All modules have xUnit coverage.

### Test Files
- **ArrayStringListHelpers_Tests**  
- **ComplexityTester_Tests**  
- **MyStackTests**  
- **MyQueueTests**  
- **RecursionHelpersTests**  
- **SortingSearchingHelpersTests** (timing inside demo)  
- **Tree tests** (BST, height, traversal)  
- **AvlTreeTests / AvlTreeHeightTests**  
- **PriorityQueueTests**  
- **SimpleHashTable_Tests**  
- **AssociativeHelpers_Tests**  
- **SinglyLinkedListTests** *(NEW)*  
- **DoublyLinkedListTests** *(NEW)*  

Coverage includes:

- Insert/delete  
- Resizing and wraparound  
- Negative cases  
- Traversal sequences  
- Balancing logic  
- Collision chains  
- Recursion base/error cases  
- Linked list pointer integrity  

============================================================

## Project Reflection
Building this toolkit made complexity visible in a practical way.  
Comparing naive and efficient approaches clarified the relationship between algorithm design and performance.  
Stacks, queues, recursion, and trees showed how structure determines behavior, while hash tables and AVL trees demonstrated the difference between average and worst-case scenarios.  
Adding linked lists strengthened my understanding of pointer manipulation, traversal logic, and node removal.

This project now serves as a reusable reference for both academic and real-world applications.

