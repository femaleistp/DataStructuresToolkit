# DataStructuresToolkit
**Author:** Brittany Hancock  
**Course:** IT 415 Data Structures and Algorithms  
**Term:** Fall 2025  
**Instructor:** Lenore Montalbano  

---

## Overview
The **DataStructuresToolkit** project is a C# solution demonstrating key data structure and algorithm concepts using reusable, testable modules.  
It includes arrays, lists, stacks, queues, recursion, sorting, and searching examples — each with time complexity analysis and console demos.  
All modules are documented with XML comments and tested using xUnit.  
The toolkit now also includes **performance measurement utilities** that time algorithms in microseconds and apply **JIT warm-up** to improve accuracy.

---

## Project Structure
**DataStructuresToolkit** – main class library containing all data structure and algorithm files.  
**DataStructuresToolkit.Tests** – xUnit test project verifying correctness and edge cases.  
**DemoHarness** – console demo application that runs and compares algorithms visually and through timing output.

---

## ArrayStringListHelpers.cs
Purpose: Helper methods for arrays, strings, and lists.

**Key Methods:**  
- `InsertIntoArray` – shifts items right and overwrites the last element.  
- `DeleteFromArray` – shifts items left and clears the last slot.  
- `ConcatenateNamesNaive` – joins names using string concatenation (`+=`) **O(n²)**.  
- `ConcatenateNamesBuilder` – joins names using `StringBuilder` **O(n)**.  
- `CapitalizeEachName` – capitalizes the first letter of each word.  
- `InsertIntoList` – inserts an integer into a `List<int>` at a specific index.

**Complexity Summary:**  
- Insert/Delete: O(n) time, O(1) space.  
- Concatenation (StringBuilder): O(n) time, O(n) space.  
All methods include parameter validation and XML documentation.

---

## ComplexityTester.cs
Purpose: Demonstrates growth rates under constant, linear, and quadratic conditions.

**Key Methods:**  
- `RunConstantScenario` – O(1) using n(n+1)/2 formula.  
- `RunLinearScenario` – O(n) using a single loop.  
- `RunQuadraticScenario` – O(n²) using nested loops.

**Use:**  
Displays elapsed time in milliseconds for side-by-side comparison.  
Provides foundational understanding of algorithmic efficiency.

---

## MyStack.cs
Purpose: Implements a dynamic **stack (LIFO)** with automatic resizing.

**Main Methods:**  
- `Push` – adds an item to the top.  
- `Pop` – removes and returns the top item.  
- `Peek` – returns the top item without removing it.  
- `Count` – returns the number of items currently stored.

**Behavior:**  
Resizes when full; supports undo/redo functionality.  

**Complexity:**  
Push/Pop/Peek: O(1) average case; Resize: O(n).

---

## MyQueue.cs
Purpose: Implements a **circular queue (FIFO)** that grows automatically.

**Main Methods:**  
- `Enqueue` – adds an item to the back.  
- `Dequeue` – removes and returns the front item.  
- `Peek` – returns the front item without removing it.  
- `Count` – number of items currently in queue.

**Behavior:**  
Automatically doubles capacity when full; wraps indices circularly.

**Complexity:**  
Enqueue/Dequeue/Peek: O(1); Resize: O(n).

---

## RecursionHelpers.cs
Purpose: Demonstrates three recursion types.

**Mathematical Recursion:**  
- `Factorial(int n)` – computes n! recursively.

**Problem-Solving Recursion:**  
- `IsPalindrome(string s)` – checks if a string reads the same forward and backward.

**Structural Recursion:**  
- `CountFilesRecursively(string path)` – counts files in subdirectories.

**Complexity:**  
Factorial / Palindrome: O(n) time, O(n) space.  
Directory traversal: O(n) time, O(d) space where d = depth.

---

## SortingSearchingHelpers.cs
Purpose: Implements and compares **sorting and searching algorithms**.

**Sorting Algorithms:**  
- `BubbleSort(int[] arr)` – O(n²)  
- `MergeSort(int[] arr)` – O(n log n)

**Searching Algorithms:**  
- `LinearSearch(int[] arr, int target)` – O(n)  
- `BinarySearch(int[] arr, int target)` – O(log n)

**Enhancements (Oct 2025):**  
- Converted timing to **microseconds (µs)** for higher precision.  
- Added **JIT warm-up** runs for BubbleSort, MergeSort, LinearSearch, and BinarySearch to remove first-call timing spikes.  
- Improved console output formatting (`F1` for sorts, `F0` for searches).  
- Titles updated from milliseconds to **microseconds** in the table header.  

---

## DemoHarness
### Demo_StacksQueues.cs
Simulates stack and queue operations in real-world use cases:
1. **Undo History (Stack)** – text editing simulation with reversible changes.  
2. **Print Queue (Queue)** – demonstrates job ordering and processing.  
3. **Performance Test** – compares MyStack and MyQueue runtime in microseconds.

### Demo_SortingSearching.cs
New console demo comparing algorithm performance.

**Features:**  
- Measures BubbleSort, MergeSort, LinearSearch, and BinarySearch across multiple input sizes (100, 1000, 10000).  
- Reports execution times in **microseconds (µs)**.  
- Includes **JIT warm-up** calls for accurate results.  
- Outputs tabular summary for easy comparison.

**Sample Output:**

=== Demo: Sorting and Searching Helpers ===

Array Size BubbleSort (µs) MergeSort (µs) LinearSearch (µs) BinarySearch (µs)  
100 88 25 0.7 0.3  
1000 1625 192 5.2 0.2  
10000 156097 2823 53.5 0.3  

---
## Testing
All algorithms are validated using xUnit.

**Test Files:**
- ArrayStringListHelpers_Tests.cs  
- ComplexityTester_Tests.cs  
- MyStackTests.cs  
- MyQueueTests.cs  
- RecursionHelpersTests.cs  
- SortingSearchingHelpers_Tests.cs *(planned for extension)*  

**Results:**
- All existing tests pass successfully.  
- New demos verified manually in console runs.

---

## Reflection
Developing this toolkit deepened my understanding of how data structures and algorithms differ in behavior and efficiency.  
Through direct timing experiments, I learned how sorting scales with n, and how search algorithms differ logarithmically and linearly.  
Implementing warm-up calls showed how JIT compilation can distort first-run performance, while measuring in microseconds revealed subtle efficiency differences otherwise hidden in milliseconds.  
This project now provides both theoretical and empirical insight into algorithm performance — bridging classroom concepts with practical benchmarking.
