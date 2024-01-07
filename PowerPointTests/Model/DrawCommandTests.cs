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
    public class DrawCommandTests
    {
        Shape _shape;
        Shapes _shapes;
        Model _model;
        PrivateObject _modelPrivate;
        DrawCommand _drawCommand;

        //測試DrawCommand初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(0, 0, 0, 0);
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _shapes = _modelPrivate.GetField("_shapes") as Shapes;
            _drawCommand = new DrawCommand(_model, _shape, _shapes);
        }

        //測試DrawCommand執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            int expectedCount = 1;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _drawCommand.Execute();

            Assert.AreEqual(expectedCount, shapes.GetCount());
        }

        //測試DrawCommand執行復原命令
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            int expectedCount = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _drawCommand.Execute();
            _drawCommand.ReverseExecute();

            Assert.AreEqual(expectedCount, shapes.GetCount());
        }
    }
}