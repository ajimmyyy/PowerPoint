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
    public class CircleTests
    {
        const double INIT_LEFT = 0;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 100;
        Circle _circle;
        PrivateObject _circlePrivate;

        //測試圓形初始化
        [TestInitialize()]
        public void Initialize()
        {
            _circle = new Circle(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _circlePrivate = new PrivateObject(_circle);
        }

        //測試圓形設定位置
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        [DataRow(0, 0, 100, 200)]
        public void SetPositionTest(double left, double top, double right, double bottom)
        {
            _circle.SetPosition(INIT_LEFT + left, INIT_TOP + top, INIT_RIGHT + right, INIT_BOTTOM + bottom);

            Assert.AreEqual(Math.Min(INIT_LEFT + left, INIT_RIGHT + right), _circle.GetPosition()._left);
            Assert.AreEqual(Math.Min(INIT_TOP + top, INIT_BOTTOM + bottom), _circle.GetPosition()._top);
            Assert.AreEqual(Math.Max(INIT_LEFT + left, INIT_RIGHT + right), _circle.GetPosition()._right);
            Assert.AreEqual(Math.Max(INIT_TOP + top, INIT_BOTTOM + bottom), _circle.GetPosition()._bottom);
        }

        //測試圓形設定座標
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        [DataRow(0, 0, 100, 200)]
        public void SetCoordinateTest(double left, double top, double right, double bottom)
        {
            _circle.SetCoordinate(INIT_LEFT + left, INIT_TOP + top, INIT_RIGHT + right, INIT_BOTTOM + bottom);

            Assert.AreEqual(Math.Min(INIT_LEFT + left, INIT_RIGHT + right), _circle.GetPosition()._left);
            Assert.AreEqual(Math.Min(INIT_TOP + top, INIT_BOTTOM + bottom), _circle.GetPosition()._top);
            Assert.AreEqual(Math.Max(INIT_LEFT + left, INIT_RIGHT + right), _circle.GetPosition()._right);
            Assert.AreEqual(Math.Max(INIT_TOP + top, INIT_BOTTOM + bottom), _circle.GetPosition()._bottom);
        }

        //測試取得座標
        [TestMethod()]
        public void GetPositionTest()
        {
            Coordinate coordinate = _circle.GetPosition();

            Assert.AreSame(coordinate, _circlePrivate.GetField("_position"));
        }

        //測試圓形繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expected = 1;
            IGraphicsMock graphics = new IGraphicsMock();

            _circle.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawCircleCount);
        }

        //測試圓形選取繪圖
        [TestMethod()]
        public void SelectDrawTest()
        {
            int expected = 1;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();
            
            _circle.SetIsSelect(true);
            _circle.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawCircleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }
    }
}