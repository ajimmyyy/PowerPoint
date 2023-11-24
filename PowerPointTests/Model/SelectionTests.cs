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
    public class SelectionTests
    {
        const double INIT_LEFT = 1;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 300;
        Selection _selection;
        PrivateObject _selectionPrivate;
        Shape _shape;

        //測試選取初始化
        [TestInitialize()]
        public void Initialize()
        {
            _selection = new Selection();
            _selectionPrivate = new PrivateObject(_selection);
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _selectionPrivate.SetField("_shapeSelect", _shape);
        }

        //測試選取設定位置
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        public void SetPositionTest(double left, double top, double right, double bottom)
        {
            _selection.SetPosition(left, top, right, bottom);

            Assert.AreEqual(left, _shape.GetPosition()._left);
            Assert.AreEqual(top, _shape.GetPosition()._top);
            Assert.AreEqual(right, _shape.GetPosition()._right);
            Assert.AreEqual(bottom, _shape.GetPosition()._bottom);
            Assert.AreEqual(left, _selection.ShapeRange._left);
            Assert.AreEqual(top, _selection.ShapeRange._top);
            Assert.AreEqual(right, _selection.ShapeRange._right);
            Assert.AreEqual(bottom, _selection.ShapeRange._bottom);
        }

        //測試選取設定位置(無選取)
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        public void SetPositionNoSelectTest(double left, double top, double right, double bottom)
        {
            _selection.Unselect();
            _selection.SetPosition(left, top, right, bottom);

            Assert.AreEqual(INIT_LEFT, _shape.GetPosition()._left);
            Assert.AreEqual(INIT_TOP, _shape.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT, _shape.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM, _shape.GetPosition()._bottom);
        }

        //測試選取更新資訊
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        public void UpdateInfoTest(double left, double top, double right, double bottom)
        {
            string expected = "((1, 1), (1, 1))";
            _selection.SetPosition(left, top, right, bottom);
            _selection.UpdateInfo();

            Assert.AreEqual(expected, _shape.Info);
        }

        //測試選取更新資訊(無選取)
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        public void UpdateInfoNoSelectTest(double left, double top, double right, double bottom)
        {
            string expected = _shape.Info;
            _selection.Unselect();
            _selection.SetPosition(left, top, right, bottom);
            _selection.UpdateInfo();

            Assert.AreEqual(expected, _shape.Info);
        }

        //測試選取更新位置
        [TestMethod()]
        public void UpdatePositionTest()
        {
            _selection.UpdatePosition();

            Assert.AreEqual(INIT_LEFT, _selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP, _selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT, _selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM, _selection.ShapeRange._bottom);
        }

        //測試選取繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expected = 8;
            IGraphicsMock graphics = new IGraphicsMock();

            _selection.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawDotCount);
        }

        //測試選取繪圖(無選取)
        [TestMethod()]
        public void DrawNoSelectTest()
        {
            int expected = 0;
            IGraphicsMock graphics = new IGraphicsMock();

            _selection.Unselect();
            _selection.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawDotCount);
        }

        //測試選取清除選取
        [TestMethod()]
        public void UnselectTest()
        {
            _selection.Unselect();

            Assert.IsNull(_selection.ShapeSelect);
        }

        //測試選取是否在拉選區域
        [TestMethod()]
        [DataRow(400, 300, true)]
        [DataRow(395, 295, false)]
        [DataRow(405, 305, false)]
        public void IsScaleAreaTest(double pointX, double pointY, bool expected)
        {
            _selection.UpdatePosition();

            Assert.AreEqual(expected, _selection.IsScaleArea(pointX, pointY));
        }

        //測試選取是否在拉選區域(無選取物件)
        [TestMethod()]
        [DataRow(400, 300, false)]
        public void IsScaleAreaNullSelectTest(double pointX, double pointY, bool expected)
        {
            _selection.Unselect();

            Assert.AreEqual(expected, _selection.IsScaleArea(pointX, pointY));
        }
    }
}