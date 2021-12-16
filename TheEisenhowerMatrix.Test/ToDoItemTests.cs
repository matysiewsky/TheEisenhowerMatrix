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
        private const string _message = "Example message";
        private const bool _isImportant = true;
        private DateTime _deadline = DateTime.Today;
        private ItemStatus _status = ItemStatus.Marked;
        private ToDoItem _item;

        [SetUp]
        public void CreateTestToDoItem()
        {
            _item = new ToDoItem(_message, _isImportant, _deadline);
        }

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
            ToDoItem item = new ToDoItem(message, isImportant, _deadline);

            Assert.AreEqual(item.Deadline, _deadline, "checking Deadline");
            Assert.AreEqual(item.Status, ItemStatus.Unmarked, "checking Status");
            Assert.AreEqual(item.Message, message, "checking Message");
            Assert.AreEqual(item.IsImportant, isImportant, "checking IsImportant");
        }


        [Test]
        public void ConstructorThird_WhencCalled_ShouldInitializeProperties()
        {
            ToDoItem item = new ToDoItem(_message, _isImportant, _deadline, _status);

            Assert.AreEqual(item.Deadline, _deadline, "checking Deadline");
            Assert.AreEqual(item.Status, _status, "checking Status");
            Assert.AreEqual(item.Message, _message, "checking Message");
            Assert.AreEqual(item.IsImportant, _isImportant, "checking IsImportant");
        }

        [Test]
        public void SetStatus_WhenCalled_ShouldSetStatus()
        {
            _item.SetStatus(_status);
            Assert.AreEqual(_item.Status, _status);
        }

        [Test]
        public void GetFormattedDeadline_WhenCalled_ShouldTurnFormatedDeadline()
        {
            string expectedDeadline = $"{_deadline:dd-MM}";
            string givenDeadline = _item.GetFormattedDeadline();
            Assert.AreEqual(expectedDeadline, givenDeadline);
        }

        //[Test]
        //public void GetDeadlineStatus_WhenCalled_ShouldReturnProperDeadlineStatus()
        //{
        //    DeadlineStatus expectedStatus = DeadlineStatus.OneDayLeft;

        //    _item.GetDeadlineStatus();
        //}

    }
}
