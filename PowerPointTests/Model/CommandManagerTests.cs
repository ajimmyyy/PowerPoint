using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        CommandManager _commandManager;
        CommandMock _commandMock;

        //測試CommandManager初始化
        [TestInitialize()]
        public void Initialize()
        {
            _commandManager = new CommandManager();
            _commandMock = new CommandMock();
        }

        //測試CommandManager執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            int expectedCount = 1;

            _commandManager.Execute(_commandMock);

            Assert.AreEqual(expectedCount, _commandMock.ExecuteCount);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
        }

        //測試CommandManager操作復原
        [TestMethod()]
        public void UndoTest()
        {
            int expectedCount = 1;

            _commandManager.Execute(_commandMock);
            _commandManager.Undo();

            Assert.AreEqual(expectedCount, _commandMock.ReverseExecuteCount);
            Assert.IsFalse(_commandManager.IsUndoEnabled);
            Assert.IsTrue(_commandManager.IsRedoEnabled);
        }

        //測試CommandManager操作復原(Exception)
        [TestMethod()]
        public void UndoExceptionTest()
        {
            Assert.ThrowsException<Exception>(() => _commandManager.Undo());
        }

        //測試CommandManager操作重做
        [TestMethod()]
        public void RedoTest()
        {
            int expectedCount = 2;

            _commandManager.Execute(_commandMock);
            _commandManager.Undo();
            _commandManager.Redo();

            Assert.AreEqual(expectedCount, _commandMock.ExecuteCount);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
        }

        //測試CommandManager操作重做(Exception)
        [TestMethod()]
        public void RedoExceptionTest()
        {
            Assert.ThrowsException<Exception>(() => _commandManager.Redo());
        }
    }
}