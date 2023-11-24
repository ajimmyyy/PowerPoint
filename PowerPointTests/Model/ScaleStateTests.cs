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
        const double INIT_TOP = 100;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 200;
        Model _model;
        Shape _shape;
        ScaleState _scaleState;
        PrivateObject _modelPrivate;

        //測試縮放模式初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _modelPrivate = new PrivateObject(_model);
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_isPressed", true);
            shapes.AddShape(_shape);
            _model.SelectShape(INIT_LEFT, INIT_TOP);
        }

        //測試縮放模式滑鼠被按下
        [TestMethod()]
        public void MouseDownTest()
        {
            _scaleState = new ScaleState(_model);
            _scaleState.MouseDown();

            Assert.AreEqual(INIT_LEFT, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_TOP, _modelPrivate.GetField("_firstPointY"));
        }

        //測試縮放模式滑鼠移動
        [TestMethod()]
        [DataRow(500, 300)]
        [DataRow(0, 100)]
        public void MouseMoveTest(double pointX, double pointY)
        {
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            _scaleState = new ScaleState(_model);
            _scaleState.MouseDown();
            _scaleState = new ScaleState(_model, pointX, pointY);
            _scaleState.MouseMove();

            Assert.AreEqual(INIT_LEFT, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_TOP, _modelPrivate.GetField("_firstPointY"));
            Assert.AreEqual(pointX, selection.ShapeRange._right);
            Assert.AreEqual(pointY, selection.ShapeRange._bottom);
        }

        //測試縮放模式滑鼠釋放
        [TestMethod()]
        [DataRow(500, 300)]
        [DataRow(0, 100)]
        public void MouseReleaseTest(double pointX, double pointY)
        {
            string expected = string.Format("(({0}, {1}), ({2}, {3}))", INIT_LEFT, INIT_TOP, pointX, pointY);
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            _scaleState = new ScaleState(_model);
            _scaleState.MouseDown();
            _scaleState = new ScaleState(_model, pointX, pointY);
            _scaleState.MouseMove();
            _scaleState = new ScaleState(_model);
            _scaleState.MouseRelease();

            Assert.AreEqual(expected, selection.ShapeSelect.Info);
        }

        //測試縮放模式鍵盤刪除按下
        [TestMethod()]
        public void DeletePressTest()
        {
            _scaleState = new ScaleState(_model);
            _scaleState.DeletePress();
        }
    }
}