namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        private DynamicList<int> linkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedList = new DynamicList<int>();
        }

        [TestMethod]
        public void Count_WithElements_ShouldReturnCount()
        {
            this.linkedList.Add(5);
            this.linkedList.Add(18);

            Assert.AreEqual(2, this.linkedList.Count);
        }

        [TestMethod]
        public void Count_Empty_ShouldReturnZero()
        {
            Assert.AreEqual(0, this.linkedList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexator_EmptyListInvalidIndex_ShouldThrow()
        {
            var inavlid = this.linkedList[1];
        }

        [TestMethod]
        public void Indexator_TryIndexator_ShouldReturnValue()
        {
            for (int i = 1; i <= 100; i++)
            {
                this.linkedList.Add(i);
            }

            Assert.AreEqual(100, this.linkedList[99]);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Indexator_SetInvalidIndex_ShouldThrow()
        {
            this.linkedList[-1] = 5;
        }

        [TestMethod]
        public void Indexator_SetElementAtValidIndex_ShouldSet()
        {
            this.linkedList.Add(2);
            this.linkedList.Add(2);
            this.linkedList[1] = 5;

            Assert.AreEqual(5, this.linkedList[1]);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_ShouldThrow()
        {
            this.linkedList.RemoveAt(50);
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_OneLemenet_ShouldRemove()
        {
            this.linkedList.Add(10);

            var index = this.linkedList.RemoveAt(0);

            Assert.AreEqual(10, index);
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_AccessTheRemovedIndex_ShouldThrow()
        {
            for (int i = 1; i <= 100; i++)
            {
                this.linkedList.Add(i);
            }

            Assert.AreEqual(69, this.linkedList[68]);

            var element = this.linkedList.RemoveAt(68);

            Assert.AreEqual(70, this.linkedList[68]);
            Assert.AreEqual(69, element);
        }

        [TestMethod]
        public void RemoveAt_FirstIndex_ShouldFixTheHead()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(2);

            this.linkedList.RemoveAt(0);

            Assert.AreEqual(1, this.linkedList.Count);
        }

        [TestMethod]
        public void RemoveAt_LastIndex_ShouldFixTheTail()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(2);

            this.linkedList.RemoveAt(1);

            Assert.AreEqual(1, this.linkedList.Count);
        }

        [TestMethod]
        public void Remove_PresentElement_ShouldRemove()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(2);
            this.linkedList.Add(2);

            var index = this.linkedList.Remove(2);

            Assert.AreEqual(2, this.linkedList.Count);
            Assert.AreEqual(2, this.linkedList[1]);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void Remove_MissingElelement_ShouldRemove()
        {
            this.linkedList.Add(1);
            this.linkedList.Add(2);

            var index = this.linkedList.Remove(3);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void IndexOf_PresentElement_ShouldReturnIndex()
        {
            this.linkedList.Add(54);
            this.linkedList.Add(55);

            var index = this.linkedList.IndexOf(55);

            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void IndexOf_MissingElement_ShouldReturnMinusOne()
        {
            this.linkedList.Add(5);

            var index = this.linkedList.IndexOf(69);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void Contains_PresentElement_ShouldReturnTrue()
        {
            this.linkedList.Add(99999);

            var found = this.linkedList.Contains(99999);

            Assert.AreEqual(true, found);
        }

        [TestMethod]
        public void Contains_MissingElement_ShouldReturnTrue()
        {
            this.linkedList.Add(1);

            var found = this.linkedList.Contains(2);

            Assert.AreEqual(false, found);
        }
    }
}