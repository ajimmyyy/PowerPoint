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
    public class ScaleStateTests
    {
        const double INIT_LEFT = 0;
        const double INIT_TOP = 0;
        const double INIT_RIGHT = 100;
        const double INIT_BOTTOM = 100;
        Model _model;
        Shape _shape;
        Shapes _shapes;
        ScaleState _scaleState;
        PrivateObject _modelPrivate;
        PrivateObject _scaleStatePrivate;

        //測試縮放模式初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _modelPrivate = new PrivateObject(_model);
            _shapes = _modelPrivate.GetField("_shapes") as Shapes;
            _scaleState = new ScaleState(_shape, _model, _shapes);
            _scaleStatePrivate = new PrivateObject(_scaleState);
        }

        //測試縮放模式滑鼠被按下
        [TestMethod()]
        public void MouseDownTest()
        {
            _scaleState.MouseDown(INIT_LEFT, INIT_TOP);

            Assert.IsInstanceOfType(_scaleStatePrivate.GetField("_selection"), typeof(Line));
            Assert.AreEqual(INIT_LEFT, _scaleStatePrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_TOP, _scaleStatePrivate.GetField("_firstPointY"));
        }

        //測試縮放模式滑鼠移動
        [TestMethod()]
        [DataRow(1, 1)]
        [DataRow(200, 200)]
        public void MouseMoveTest(double pointX, double pointY)
        {
            Shape selection = _scaleStatePrivate.GetField("_selection") as Shape;
            _scaleState.MouseMove(pointX, pointY);

            Assert.AreEqual(Math.Min(INIT_LEFT, pointX), selection.GetPosition()._left);
            Assert.AreEqual(Math.Min(INIT_TOP, pointY), selection.GetPosition()._top);
            Assert.AreEqual(Math.Max(INIT_LEFT, pointX), selection.GetPosition()._right);
            Assert.AreEqual(Math.Max(INIT_TOP, pointY), selection.GetPosition()._bottom);
        }

        //測試縮放模式滑鼠移動(無選取)
        [TestMethod()]
        [DataRow(1, 1)]
        public void MouseMoveNullSelectTest(double pointX, double pointY)
        {
            _scaleStatePrivate.SetField("_selection", null);
            _scaleState.MouseMove(pointX, pointY);

            Assert.AreEqual(INIT_LEFT, _shape.GetPosition()._left);
            Assert.AreEqual(INIT_TOP, _shape.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT, _shape.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM, _shape.GetPosition()._bottom);
        }

        //測試縮放模式滑鼠釋放
        [TestMethod()]
        [DataRow(200, 200)]
        public void MouseReleaseTest(double pointX, double pointY)
        {
            Shape selection = _scaleStatePrivate.GetField("_selection") as Shape;
            String expected = "((0, 0), (200, 200))";

            _scaleState.MouseMove(pointX, pointY);
            _scaleState.MouseRelease();

            Assert.AreEqual(expected, selection.Info);
        }

        //測試縮放模式滑鼠釋放(無選取)
        [TestMethod()]
        [DataRow(200, 200)]
        public void MouseReleaseNullSelectTest(double pointX, double pointY)
        {
            Shape selection = _scaleStatePrivate.GetField("_selection") as Shape;
            String expected = "((0, 0), (100, 100))";

            _scaleStatePrivate.SetField("_selection", null);
            _scaleState.MouseMove(pointX, pointY);
            _scaleState.MouseRelease();

            Assert.AreEqual(expected, selection.Info);
        }
    }
}