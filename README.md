# DataStructuresToolkit
**Author:** Brittany Hancock  
**Course:** IT 415 Data Structures and Algorithms  
**Term:** Fall 2025  
**Instructor:** Lenore Montalbano  

---

## Overview
The DataStructuresToolkit project is a C# solution that demonstrates the main data structure and algorithm concepts using reusable code modules.  
It includes arrays, lists, stacks, queues, recursion, and complexity analysis examples.  
All modules are documented with XML comments and tested with xUnit to confirm they work correctly.  
The toolkit builds toward later topics such as tree traversals and divide-and-conquer algorithms.

---

## Project Structure
**DataStructuresToolkit** – main library containing all class files.  
**DataStructuresToolkit.Tests** – xUnit tests that confirm each method works correctly.  
**DemoHarness** – console demo project that shows how stacks and queues behave in real examples.

---

## ArrayStringListHelpers.cs
Purpose: Helper methods for arrays, strings, and lists.

**Key Methods:**  
InsertIntoArray – shifts items right and overwrites the last element.  
DeleteFromArray – shifts items left and clears the last slot.  
ConcatenateNamesNaive – joins names with spaces using += (O(n²)).  
ConcatenateNamesBuilder – joins names using StringBuilder (O(n)).  
CapitalizeEachName – capitalizes each word in a name string.  
InsertIntoList – inserts a value into a List<int> at a specific index.

**Complexity Summary:**  
Insert and delete: O(n) time, O(1) space.  
Concatenation with StringBuilder: O(n) time, O(n) space.  
All methods include parameter checks and XML documentation.

---

## ComplexityTester.cs
Purpose: Shows how runtime grows under constant, linear, and quadratic conditions.

**Key Methods:**  
RunConstantScenario – O(1) using n(n+1)/2 formula.  
RunLinearScenario – O(n) by summing numbers with a loop.  
RunQuadraticScenario – O(n²) using nested loops.

**Use:**  
The tests display elapsed time in milliseconds to compare performance as n increases.

---

## MyStack.cs
Purpose: Implements a simple resizable stack (LIFO).

**Main Methods:**  
Push – adds an item to the top.  
Pop – removes and returns the last item added.  
Peek – returns the top item without removing it.  
Count – property returning the number of items.

**Behavior:**  
Resizes the internal array when full.  
Supports Undo and backtracking use cases.

**Complexity:**  
Push/Pop/Peek – O(1) time and space.  
Resize – O(n) time, O(n) space when triggered.

---

## MyQueue.cs
Purpose: Implements a circular queue (FIFO).

**Main Methods:**  
Enqueue – adds an item to the end.  
Dequeue – removes and returns the front item.  
Peek – returns the front item without removing it.  
Count – property returning the number of items.

**Behavior:**  
Uses a circular array that wraps when full.  
Doubles capacity automatically when resizing.  
Ideal for managing tasks or print jobs in order.

**Complexity:**  
Enqueue/Dequeue/Peek – O(1) time and space.  
Resize – O(n) time when expanding.

---

## RecursionHelpers.cs
Purpose: Demonstrates recursion for three different problem types.

**Mathematical Recursion:**  
Factorial(int n) – calculates n! recursively.  
Base case: n == 0 returns 1.  
Recursive case: n * Factorial(n - 1).

**Problem-Solving Recursion:**  
IsPalindrome(string s) – checks if a string reads the same forward and backward.  
Base case: strings of length 0 or 1 return true.  
Recursive case: compare first and last character, then recurse inward.

**Structural Recursion:**  
CountFilesRecursively(string path) – counts files in a directory and subdirectories.  
Base case: directory with no subfolders returns number of files.  
Recursive case: adds results from subfolders to the count.

**Complexity:**  
Factorial and IsPalindrome: O(n) time, O(n) space.  
CountFilesRecursively: O(n) time, O(d) space where d is directory depth.

---

## Testing
All tests are written using xUnit in the DataStructuresToolkit.Tests project.

**Test Files:**  
ArrayStringListHelpers_Tests_.cs – checks array, string, and list functions.  
ComplexityTester_Tests.cs – compares constant, linear, and quadratic runs.  
MyStackTests.cs – verifies push, pop, peek, resize, and empty exceptions.  
MyQueueTests.cs – verifies enqueue, dequeue, wraparound, resize, and exceptions.  
RecursionHelpersTests.cs – verifies factorial, palindrome, and directory recursion.

**Result:**  
All tests pass successfully in Visual Studio Test Explorer.

---

## DemoHarness
File: Demo_StacksQueues.cs

This console demo shows how stacks and queues behave with real examples.  
It includes:

Part 1 – A text editor that uses a stack for undo history.  
Part 2 – A print queue that processes jobs in order.  
Part 3 – A performance test comparing MyStack and MyQueue speed.

**Output:**  
Displays all actions step by step in the console and shows timing in milliseconds and microseconds for performance comparison.

---

## Reflection
Creating this toolkit helped me understand how arrays, stacks, queues, and recursion work behind the scenes.  
I learned how data structures handle storage, access, and resizing.  
The ComplexityTester made it clear how time grows with input size.  
Recursion taught me to identify base and recursive steps.  
Writing tests and XML documentation helped me see each method’s purpose and limits clearly.  
This toolkit now serves as a foundation for future topics like trees, sorting, and divide-and-conquer algorithms.
