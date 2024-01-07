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
    public class PointStateTests
    {
        const double INIT_POINT_X = 100;
        const double INIT_POINT_Y = 100;
        const double INIT_LEFT = 0;
        const double INIT_TOP = 0;
        const double INIT_RIGHT = 100;
        const double INIT_BOTTOM = 100;
        Shape _shape;
        Shapes _shapes;
        Model _model;
        PointState _pointState;
        PrivateObject _modelPrivate;
        PrivateObject _pointStatePrivate;

        //測試選取模式初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
            _shapes = _modelPrivate.GetField("_shapes") as Shapes;
            _pointState = new PointState(_shape, _model, _shapes);
            _pointStatePrivate = new PrivateObject(_pointState);
        }

        //測試選取模式滑鼠被按下
        [TestMethod()]
        public void MouseDownTest()
        {
            Shape selection = _pointStatePrivate.GetField("_selection") as Shape;
            _pointState.MouseDown(INIT_POINT_X, INIT_POINT_Y);

            Assert.IsInstanceOfType(selection, typeof(Line));
            Assert.IsTrue(selection.IsSelect());
            Assert.AreEqual(INIT_POINT_X, _pointStatePrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_POINT_Y, _pointStatePrivate.GetField("_firstPointY"));
        }

        //測試選取模式滑鼠被按下(無選取)
        [TestMethod()]
        public void MouseDownNullSelectTest()
        {
            _pointStatePrivate.SetField("_selection", null);
            _pointState.MouseDown(INIT_POINT_X, INIT_POINT_Y);
            Assert.IsFalse(_shape.IsSelect());
        }

        //測試選取模式滑鼠移動
        [TestMethod()]
        [DataRow(1, 1)]
        [DataRow(200, 200)]
        public void MouseMoveTest(double pointX, double pointY)
        {
            Shape selection = _pointStatePrivate.GetField("_selection") as Shape;

            _pointState.MouseDown(INIT_POINT_X, INIT_POINT_Y);
            _pointState.MouseMove(pointX, pointY);

            Assert.AreEqual(INIT_LEFT + (pointX - INIT_POINT_X), selection.GetPosition()._left);
            Assert.AreEqual(INIT_TOP + (pointY - INIT_POINT_Y), selection.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT + (pointX - INIT_POINT_X), selection.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM + (pointY - INIT_POINT_Y), selection.GetPosition()._bottom);
        }

        //測試選取模式滑鼠移動(無選取)
        [TestMethod()]
        [DataRow(1, 1)]
        public void MouseMoveNullSelectTest(double pointX, double pointY)
        {
            _pointStatePrivate.SetField("_selection", null);

            _pointState.MouseDown(INIT_POINT_X, INIT_POINT_Y);
            _pointState.MouseMove(pointX, pointY);

            Assert.AreEqual(INIT_LEFT, _shape.GetPosition()._left);
            Assert.AreEqual(INIT_TOP, _shape.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT, _shape.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM, _shape.GetPosition()._bottom);
        }

        //測試選取模式滑鼠釋放
        [TestMethod()]
        [DataRow(200, 200)]
        public void MouseReleaseTest(double pointX, double pointY)
        {
            Shape selection = _pointStatePrivate.GetField("_selection") as Shape;
            String expected = "((100, 100), (200, 200))";

            _pointState.MouseDown(INIT_POINT_X, INIT_POINT_Y);
            _pointState.MouseMove(pointX, pointY);
            _pointState.MouseRelease();

            Assert.AreEqual(expected, selection.Info);
        }

        //測試選取模式滑鼠釋放(無選取)
        [TestMethod()]
        [DataRow(200, 200)]
        public void MouseReleaseNullSelectTest(double pointX, double pointY)
        {
            Shape selection = _pointStatePrivate.GetField("_selection") as Shape;
            String expected = "((0, 0), (100, 100))";
            _pointStatePrivate.SetField("_selection", null);

            _pointState.MouseDown(INIT_POINT_X, INIT_POINT_Y);
            _pointState.MouseMove(pointX, pointY);
            _pointState.MouseRelease();

            Assert.AreEqual(expected, selection.Info);
        }
    }
}