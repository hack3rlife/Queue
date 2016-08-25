using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace com.hack3rlife.datastructures
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    /// TODO: Implement ICollection
    public class Queue<T> : IEnumerable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public Node<T> head { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Node<T> tail { get; private set; }

        /// <summary>
        /// Enqueue adds an element to the end of the Queue<T>
        /// </summary>
        /// <remarks>
        /// Remember that Queue is a Firs-In/First Out (LiFo) data structure, so we keep adding elements at the rear of the collection and removing them from the top.
        /// </remarks>
        /// <example>
        /// Enqueue(0)
        ///         -----
        ///    head | 0 | tail
        ///         -----
        ///  Enqueue(1)
        ///         -----  -----
        ///    head | 0 |  | 1 | tail
        ///         -----  -----
        ///  Enqueue(2)
        ///         -----  -----  -----
        ///    head | 0 |  | 1 |  | 2 | tail
        ///         -----  -----  -----
        /// </example>
        /// <param name="value">Value to be added</param>
        public void Enqueue(T value)
        {
            Node<T> node = new Node<T>(value);

            if (head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                tail.Next = node;
                tail = tail.Next;
            }
        }

        /// <summary>
        /// Dequeue removes the oldest element from the start of the Queue<T>
        /// </summary>
        /// <example>
        ///  Queue
        ///         -----  -----  -----
        ///    head | 0 |  | 1 |  | 2 | tail
        ///         -----  -----  -----
        ///  Dequeue()
        ///         -----  -----
        ///    head | 1 |  | 2 | tail
        ///         -----  -----
        ///  Dequeue()
        ///         -----
        ///    head | 2 | tail
        ///         -----  
        ///  Dequeue()
        ///          -
        ///    head | | tail
        ///          -
        /// </example>
        /// <returns>First element of the Queue<T> and remove it from the Queue<T></returns>
        /// <exception cref="NullReferenceException">When the Queue is empty</exception>
        public T Dequeue()
        {
            if (head == null)
            {
                throw new NullReferenceException("The Queue is empty");
            }
            else
            {
                var result = head.Value;

                head = head.Next;

                return result;
            }
        }

        /// <summary>
        /// Peek returns the oldest element that is at the start of the Queue but does not remove it from the Queue
        /// </summary>
        /// <returns>First element of the Queue<T></returns>
        /// <exception cref="NullReferenceException">When the Queue is empty</exception>
        public T Peek()
        {
            if (head == null)
            {
                throw new NullReferenceException("The Queue is empty");
            }
            else
            {
                return head.Value;
            }
        }

        /// <summary>
        /// Clear the Queue<T> and reset the counter
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
        }

        public void Display()
        {
            Console.Clear();

            Node<T> current = head;

            while (current != null)
            {
                Debug.Write(string.Format("| {0} | -> ", current.Value));
                current = current.Next;
            }

            Debug.WriteLine(string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (head != null)
            {
                Node<T> node = head;

                while (node != null)
                {
                    yield return node.Value;
                    node = node.Next;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
