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
        const double INIT_LEFT = 1;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 100;
        Model _model;
        Shape _shape;
        Shapes _shapes;
        PointState _pointState;
        PrivateObject _modelPrivate;

        //測試選取模式初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _shapes = new Shapes();
            _shapes.AddShape(_shape);
            _modelPrivate = new PrivateObject(_model);
            _modelPrivate.SetField("_isPressed", true);
            _modelPrivate.SetField("_shapes", _shapes);
        }

        //測試選取模式滑鼠被按下
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(1, 1, false)]
        [DataRow(1, 100, true)]
        [DataRow(400, 200, true)]
        public void MouseDownTest(double pointX, double pointY, bool expected)
        {
            Selection selection = _modelPrivate.GetField("_selection") as Selection;
            _pointState = new PointState(_model, pointX, pointY);

            _pointState.MouseDown();

            Assert.AreEqual(expected, selection.ShapeSelect != null);
        }

        //測試選取模式滑鼠移動
        [TestMethod()]
        [DataRow(1, 100, 100, 200)]
        [DataRow(400, 200, 300, 100)]
        public void MouseMoveTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            Selection selection = _modelPrivate.GetField("_selection") as Selection;

            _pointState = new PointState(_model, firstPointX, firstPointY);
            _pointState.MouseDown();
            _pointState = new PointState(_model, pointX, pointY);
            _pointState.MouseMove();

            Assert.AreEqual(INIT_LEFT + (pointX - firstPointX), selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP + (pointY - firstPointY), selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT + (pointX - firstPointX), selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM + (pointY - firstPointY), selection.ShapeRange._bottom);
        }

        //測試選取模式滑鼠釋放
        [TestMethod()]
        [DataRow(1, 100, 100, 200)]
        public void MouseReleaseTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            string expected = "((100, 300), (499, 200))";
            Selection selection = _modelPrivate.GetField("_selection") as Selection;

            _pointState = new PointState(_model, firstPointX, firstPointY);
            _pointState.MouseDown();
            _pointState = new PointState(_model, pointX, pointY);
            _pointState.MouseMove();
            _pointState = new PointState(_model);
            _pointState.MouseRelease();

            Assert.AreEqual(expected, selection.ShapeSelect.Info);
        }

        //測試選取模式鍵盤刪除按下
        [TestMethod()]
        public void DeletePressTest()
        {
            int expected = 0;
            Selection selection = _modelPrivate.GetField("_selection") as Selection;
            selection.ShapeSelect = _shape;

            _pointState = new PointState(_model);
            _pointState.DeletePress();

            Assert.AreEqual(expected, _shapes.GetCount());
            Assert.IsNull(selection.ShapeSelect);
        }
    }
}