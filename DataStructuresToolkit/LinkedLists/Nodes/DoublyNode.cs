/* 
 * Reflection – Week 9 Linked Lists
 * 
 * What stood out to me when I implemented linked lists was that the same basic 
 * ideas work for both singly and doubly linked lists. I could use similar 
 * methods like AddFirst in each one, but the doubly linked list let me use 
 * Prev and Next so I could look back and forth at nodes that were ahead or 
 * behind. A singly linked list makes more sense when I do not need to move 
 * backward and I am only going down the chain. A doubly linked list makes more 
 * sense if I do want to move back and forth or remove something in the middle.
 * 
 * One thing that clicked for me when working with Node and DoublyNode was that 
 * the only real difference is that the doubly linked node stores both previous 
 * and next, while the single one only stores next. That small difference changes 
 * what the structure is able to do. What forced me to understand the mechanics 
 * was realizing that the doubly linked list is storing three values inside each 
 * node: the data, the one before it, and the one behind it. The singly linked 
 * list only stores two values: its data and the next one behind it, but that still 
 * gives me enough to search or check if it contains something.
 * 
 * Using xUnit taught me how to prepare for which methods I was going to implement. 
 * When a test failed, I knew exactly what part I needed to work on. When a test 
 * passed, I knew it was at least minimally correct. After building both list types 
 * from scratch, I understand that linked lists are easier to grow or shrink because 
 * each node can be stored anywhere in memory and does not require one big block of 
 * space. They can be scattered, and the references connect everything together.
*/

using System;
using System.Collections.Generic;

namespace DataStructuresToolkit.LinkedLists.Nodes
{
    /// <summary>
    /// A node in a doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node.</typeparam>
    public class DoublyNode<T>
    {
        public T Data;
        public DoublyNode<T> Prev;
        public DoublyNode<T> Next;

        /// <summary>
        /// Initializes a new instance of the DoublyNode class with the specified data.
        /// </summary>
        /// <param name="data">The data to store in the node.</param>
        public DoublyNode(T data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }
}
