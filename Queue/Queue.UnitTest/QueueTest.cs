using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.hack3rlife.datastructures
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void EnqueueTest()
        {
            // arrange
            Queue<int> queue = new Queue<int>();

            // act
            queue.Enqueue(0);
            queue.Display();
            queue.Enqueue(1);
            queue.Display();
            queue.Enqueue(2);
            queue.Display();

            // assert
            var expected = 0;
            var actual = queue.Peek();

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void DequeueTest()
        {
            // arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Display();
            queue.Enqueue(1);
            queue.Display();
            queue.Enqueue(2);
            queue.Display();

            // act
            var actual = 0;
            var expected = queue.Dequeue();
            queue.Display();

            // assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void ClearTest()
        {
            // arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Display();
            queue.Enqueue(1);
            queue.Display();
            queue.Enqueue(2);
            queue.Display();

            // act
            queue.Clear();

            // assert
            Assert.IsNull(queue.head);
            Assert.IsNull(queue.tail);
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            // arrange
            var actual = new List<int>();
            var expected = new List<int>() { 0, 1, 2 };

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            queue.Display();
            queue.Enqueue(1);
            queue.Display();
            queue.Enqueue(2);
            queue.Display();

            // act
            var enumerator = queue.GetEnumerator();

            while (enumerator.MoveNext())
            {
                actual.Add(enumerator.Current);
            }

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
