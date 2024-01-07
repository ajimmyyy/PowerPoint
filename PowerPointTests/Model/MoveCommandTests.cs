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
    public class MoveCommandTests
    {
        Coordinate _originPosition;
        Coordinate _lastPosition;
        Shape _originShape;
        Shape _lastShape;
        Shapes _shapes;
        Model _model;
        MoveCommand _moveCommand;
        PrivateObject _modelPrivate;

        //測試MoveCommand初始化
        [TestInitialize()]
        public void Initialize()
        {
            _originShape = new Line(0, 0, 0, 0);
            _lastShape = new Line(10, 10, 100, 100);
            _originPosition = _originShape.GetPosition().Clone();
            _lastPosition = _lastShape.GetPosition().Clone();
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _shapes = _modelPrivate.GetField("_shapes") as Shapes;
            _moveCommand = new MoveCommand(_model, _lastShape, _originPosition, _shapes);
        }

        //測試MoveCommand執行命令
        [TestMethod()]
        public void ExecuteTest()
        {
            _moveCommand.Execute();

            Assert.AreEqual(_lastPosition._left, _lastShape.GetPosition()._left);
            Assert.AreEqual(_lastPosition._top, _lastShape.GetPosition()._top);
            Assert.AreEqual(_lastPosition._right, _lastShape.GetPosition()._right);
            Assert.AreEqual(_lastPosition._bottom, _lastShape.GetPosition()._bottom);
        }

        //測試MoveCommand執行復原命令
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            _moveCommand.ReverseExecute();

            Assert.AreEqual(_originPosition._left, _lastShape.GetPosition()._left);
            Assert.AreEqual(_originPosition._top, _lastShape.GetPosition()._top);
            Assert.AreEqual(_originPosition._right, _lastShape.GetPosition()._right);
            Assert.AreEqual(_originPosition._bottom, _lastShape.GetPosition()._bottom);
        }
    }
}