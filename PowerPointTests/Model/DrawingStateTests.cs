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
    public class DrawingStateTests
    {
        Model _model;
        Shape _hint;
        DrawingState _drawingState;
        PrivateObject _modelPrivate;

        //測試繪圖模式初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _model.SetToolMode(ModeType.LINE_NAME);
            _hint = new Line(0, 0, 0, 0);
            _modelPrivate = new PrivateObject(_model);
            _modelPrivate.SetField("_isPressed", true);
        }

        //測試繪圖模式滑鼠被按下
        [TestMethod()]
        [DataRow(1, 1)]
        public void MouseDownTest(double pointX, double pointY)
        {
            _drawingState = new DrawingState(_model, pointX, pointY);
            _drawingState.MouseDown();

            Assert.IsInstanceOfType(_modelPrivate.GetField("_hint"), typeof(Line));
            Assert.AreEqual(pointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(pointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試繪圖模式滑鼠被按下(超出範圍)
        [TestMethod()]
        [DataRow(0, 0)]
        public void MouseDownOutRangeTest(double pointX, double pointY)
        {
            _drawingState = new DrawingState(_model, pointX, pointY);
            _drawingState.MouseDown();

            Assert.AreEqual(_modelPrivate.GetField("_hint"), null);
        }

        //測試繪圖模式滑鼠移動
        [TestMethod()]
        [DataRow(1, 1, 100, 100)]
        [DataRow(100, 100, 1, 1)]
        public void MouseMoveTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            _modelPrivate.SetField("_hint", _hint);
            _modelPrivate.SetField("_firstPointX", firstPointX);
            _modelPrivate.SetField("_firstPointY", firstPointY);

            _drawingState = new DrawingState(_model, pointX, pointY);
            _drawingState.MouseMove();

            Assert.AreEqual(firstPointX, _hint.GetPosition()._left);
            Assert.AreEqual(firstPointY, _hint.GetPosition()._top);
            Assert.AreEqual(pointX, _hint.GetPosition()._right);
            Assert.AreEqual(pointY, _hint.GetPosition()._bottom);
        }

        //測試繪圖模式滑鼠釋放
        [TestMethod()]
        public void MouseReleaseTest()
        {
            int expected = 1;
            Shapes shapes = _modelPrivate.GetField("_shapes") as Shapes;

            _modelPrivate.SetField("_hint", _hint);

            _drawingState = new DrawingState(_model);
            _drawingState.MouseRelease();

            Assert.AreEqual(expected, shapes.GetCount());
        }

        //測試繪圖模式鍵盤刪除按下
        [TestMethod()]
        public void DeletePressTest()
        {
            _drawingState = new DrawingState(_model);
            _drawingState.DeletePress();
        }
    }
}