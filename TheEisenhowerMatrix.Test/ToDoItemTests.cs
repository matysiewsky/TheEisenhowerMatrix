using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TheEisenhowerMatrix.Test
{
    [TestFixture]
    class ToDoItemTests
    {
        [Test]
        public void ConstructorFirst_WhencCalled_ShouldInitializeProperties()
        {
            ToDoItem emptyItem = new ToDoItem();
            Assert.AreEqual(emptyItem.Deadline, DateTime.MaxValue, "checking deadline");
            Assert.AreEqual(emptyItem.Status, ItemStatus.Empty, "checking status");
        }

        [Test]
        [TestCase("Example message", true)]
        [TestCase("Example message2", false)]
        public void ConstructorSecond_WhencCalled_ShouldInitializeProperties(string message, bool isImportant)
        {
            DateTime deadline = new DateTime(2022, 6, 6);
            ToDoItem item = new ToDoItem(message, isImportant, deadline);

            Assert.AreEqual(item.Deadline, deadline, "checking Deadline");
            Assert.AreEqual(item.Status, ItemStatus.Unmarked, "checking Status");
            Assert.AreEqual(item.Message, message, "checking Message");
            Assert.AreEqual(item.IsImportant, isImportant, "checking IsImportant");
        }


        [Test]
        public void ConstructorThird_WhencCalled_ShouldInitializeProperties()
        {
            const string message = "Example message";
            const bool isImportant = true;
            DateTime deadline = DateTime.Today;
            ItemStatus status = ItemStatus.Marked;

            ToDoItem item = new ToDoItem(message, isImportant, deadline, status);

            Assert.AreEqual(item.Deadline, deadline, "checking Deadline");
            Assert.AreEqual(item.Status, status, "checking Status");
            Assert.AreEqual(item.Message, message, "checking Message");
            Assert.AreEqual(item.IsImportant, isImportant, "checking IsImportant");
        }

    }
}
