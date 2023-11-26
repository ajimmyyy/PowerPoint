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
        const double INIT_POINT_X = 100;
        const double INIT_POINT_Y = 100;
        Shape _shape;
        DrawingState _drawingState;
        PrivateObject _drawingStatePrivate;

        //測試繪圖模式初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(0, 0, 0, 0);
            _drawingState = new DrawingState(INIT_POINT_X, INIT_POINT_Y, _shape);
            _drawingStatePrivate = new PrivateObject(_drawingState);
        }

        //測試繪圖模式滑鼠被按下
        [TestMethod()]
        [DataRow(1, 1)]
        public void MouseDownTest(double pointX, double pointY)
        {
            _drawingState.MouseDown();

            Assert.IsInstanceOfType(_drawingStatePrivate.GetField("_hint"), typeof(Line));
            Assert.AreEqual(INIT_POINT_X, _drawingStatePrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_POINT_Y, _drawingStatePrivate.GetField("_firstPointY"));
        }

        //測試繪圖模式滑鼠移動
        [TestMethod()]
        [DataRow(1, 1)]
        [DataRow(200, 200)]
        public void MouseMoveTest(double pointX, double pointY)
        {
            Shape hint = _drawingStatePrivate.GetField("_hint") as Shape;
            _drawingState.MouseMove(pointX, pointY);

            Assert.AreEqual(INIT_POINT_X, hint.GetPosition()._left);
            Assert.AreEqual(INIT_POINT_Y, hint.GetPosition()._top);
            Assert.AreEqual(pointX, hint.GetPosition()._right);
            Assert.AreEqual(pointY, hint.GetPosition()._bottom);
        }

        //測試繪圖模式滑鼠釋放
        [TestMethod()]
        public void MouseReleaseTest()
        {
            _drawingState.MouseRelease();

            Assert.IsInstanceOfType(_drawingStatePrivate.GetField("_hint"), typeof(Line));
            Assert.AreEqual(INIT_POINT_X, _drawingStatePrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_POINT_Y, _drawingStatePrivate.GetField("_firstPointY"));
        }
    }
}