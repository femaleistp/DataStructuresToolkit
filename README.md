# Week 3 - Custom Stack and Queue

This week I added MyStack and MyQueue to my project.  
They both use arrays and can grow in size when needed.  
I tested them with xUnit and made a demo to show how they work.

## What’s in the project
- MyStack.cs and MyQueue.cs are in DataStructuresToolkit  
- MyStackTests.cs and MyQueueTests.cs are in DataStructuresToolkit.Tests  
- Demo_StacksQueues.cs is in DemoHarness

## Summary of Behavior
**MyStack<T>**
- Works in Last In, First Out order (LIFO)  
- Methods: Push, Pop, Peek, Count  
- Push and Pop usually take O(1) time  
- Used for undo history, backtracking, or reversing data  

**MyQueue<T>**
- Works in First In, First Out order (FIFO)  
- Methods: Enqueue, Dequeue, Peek, Count  
- Enqueue and Dequeue usually take O(1) time  
- Used for processing tasks in order, like print jobs or lines of people  

## What the demo shows
- Part 1 shows MyStack working like an undo history  
- Part 2 shows MyQueue working like print jobs in order  
- Part 3 compares how fast they run

## Screenshots
1. 01_week3_solution_explorer_structure.png – project folders  
2. 02_week3_console_output_part1_stack.png – stack output  
3. 03_week3_console_output_part2_queue.png – queue output  
4. 04_week3_console_output_part3_performance.png – performance test  
5. 05_week3_test_explorer_all_passed.png – all tests passed

## Reflection
I learned how stacks and queues work and how to resize arrays.  
The demo helped me understand the difference between LIFO and FIFO.I also practiced writing tests with xUnit to make sure everything works.I practiced working between multiple classes and projects in one solution.Better understanding of XML documentation comments for methods and classes.