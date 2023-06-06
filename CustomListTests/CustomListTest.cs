using CustomList;

namespace CustomListTests
{
    [TestClass]
    public class CustomListTest
    {
        [TestMethod]

        // add tests
        public void Add_CountIncrementsAsItemsAdded()
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(10);
            list.Add(20);
            list.Add(30);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void Add_FirstItemAddedIsFoundAtZeroIndex()
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(10);

            Assert.AreEqual(10, list[0]);
        }

        [TestMethod]
        public void Add_SecondItemAddedIsFoundAtOneIndex()
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(10);
            list.Add(20);

            Assert.AreEqual(20, list[1]);
        }

        [TestMethod]
        public void Add_CapacityIncreasesWhenExceeded()
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);
            list.Add(60);

            Assert.AreEqual(6, list.Count);
            Assert.IsTrue(list.Capacity >= 6);
        }

        [TestMethod]
        public void Add_AfterCapacityIncreases_OriginalItemsPersistInSameIndex()
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            list.Add(50);
            list.Add(60);

            
            Assert.AreEqual(10, list[0]);
            Assert.AreEqual(30, list[2]);
            Assert.AreEqual(50, list[4]);
        }

        [TestMethod]

        //remove tests
        public void Remove_CountDecrementsWhenItemSuccessfullyRemoved()
        {
            CustomList<int> list = new CustomList<int>() { 10, 20, 30 };

            bool removed = list.Remove(20);

            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void Remove_ReturnsTrueWhenItemSuccessfullyRemoved()
        {
            CustomList<int> list = new CustomList<int>() { 10, 20, 30 };

            bool removed = list.Remove(20);

            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void Remove_CountDoesNotDecrementWhenItemNotInCustomList()
        {
            CustomList<int> list = new CustomList<int>() { 10, 20, 30 };
            
            bool removed = list.Remove(40);

            Assert.AreEqual(3, list.Count);
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void Remove_ItemsShiftBackwardsAfterItemRemoved()
        {
            CustomList<int> list = new CustomList<int>() { 10, 20, 30, 40 };

            bool removed = list.Remove(20);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(10, list[0]);
            Assert.AreEqual(30, list[1]);
            Assert.AreEqual(40, list[2]);
        }

        [TestMethod]

        //string tests
        public void ToString_ListOfStrings_ReturnsExpectedResult()
        {
            CustomList<string> list = new CustomList<string>() { "apple", "banana", "cherry" };

            string result = list.ToString();

            Assert.AreEqual("apple, banana, cherry", result);
        }

        [TestMethod]
        public void ToString_ListOfInts_ReturnsExpectedResult()
        {
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5 };

            string result = list.ToString();

            Assert.AreEqual("1, 2, 3, 4, 5", result);
        }

        [TestMethod]
        public void ToString_EmptyList_ReturnsEmptyString()
        {
            CustomList<int> list = new CustomList<int>();

            string result = list.ToString();

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]

        //plus operators
        public void PlusOperator_FirstListIsLongerThanSecondList()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3, 4, 5 };
            CustomList<int> list2 = new CustomList<int>() { 6, 7 };

            CustomList<int> result = list1 + list2;

            Assert.AreEqual(7, result.Count);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, result.ToArray());
        }

        [TestMethod]
        public void PlusOperator_SecondListIsLongerThanFirstList()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2 };
            CustomList<int> list2 = new CustomList<int>() { 3, 4, 5, 6, 7 };

            CustomList<int> result = list1 + list2;

            Assert.AreEqual(7, result.Count);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7 }, result.ToArray());
        }

        [TestMethod]
        public void PlusOperator_OneListIsEmpty_ResultIsUnchanged()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> list2 = new CustomList<int>();

            CustomList<int> result1 = list1 + list2;
            CustomList<int> result2 = list2 + list1;

            Assert.AreEqual(3, result1.Count);
            Assert.AreEqual(3, result2.Count);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result1.ToArray());
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result2.ToArray());
        }

        [TestMethod]

        //minus operators

        public void MinusOperator_FirstListIsLongerThanSecondList()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3, 4, 5 };
            CustomList<int> list2 = new CustomList<int>() { 2, 4 };

            CustomList<int> result = list1 - list2;

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, result.ToArray());
        }

        [TestMethod]
        public void MinusOperator_SecondListIsLongerThanFirstList()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> list2 = new CustomList<int>() { 2, 4, 5, 6, 7 };

            CustomList<int> result = list1 - list2;

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new[] { 1, 3 }, result.ToArray());
        }

        [TestMethod]
        public void MinusOperator_SecondListIsEmpty_ResultIsUnchanged()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> list2 = new CustomList<int>();

            CustomList<int> result1 = list1 - list2;
            CustomList<int> result2 = list2 - list1;

            Assert.AreEqual(3, result1.Count);
            Assert.AreEqual(0, result2.Count);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result1.ToArray());
            CollectionAssert.AreEqual(new int[0], result2.ToArray());
        }

        [TestMethod]
        public void MinusOperator_RemoveSingleInstanceFromSecondList()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3, 3, 3 };
            CustomList<int> list2 = new CustomList<int>() { 1, 2, 3 };

            CustomList<int> result = list1 - list2;

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new[] { 3, 3 }, result.ToArray());
        }
    }
}