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
    public class AddCommandTests
    {
        Model _model;
        Shapes _shapes;
        PrivateObject _modelPrivate;
        AddCommand _addCommand;

        //測試DrawAddCommand初始化
        [TestInitialize()]
        public void Initialize()
        {
            int[] coordinate = new int[] { 0, 0, 10, 10 };
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _shapes = _modelPrivate.GetField("_shapes") as Shapes;
            _addCommand = new AddCommand(_model, ModeType.LINE_NAME, coordinate, _shapes);
        }

        //測試DrawAddCommand執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            int expectedCount = 1;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _addCommand.Execute();

            Assert.AreEqual(expectedCount, shapes.GetCount());
        }

        //測試DrawAddCommand執行復原命令
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            int expectedCount = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _addCommand.Execute();
            _addCommand.ReverseExecute();

            Assert.AreEqual(expectedCount, shapes.GetCount());
        }
    }
}