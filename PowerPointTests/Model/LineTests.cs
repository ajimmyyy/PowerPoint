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
    public class LineTests
    {
        const double INIT_LEFT = 0;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 100;
        Line _line;
        PrivateObject _linePrivate;

        //測試線初始化
        [TestInitialize()]
        public void Initialize()
        {
            _line = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _linePrivate = new PrivateObject(_line);
        }

        //測試線設定位置
        [TestMethod()]
        public void SetPositionTest()
        {
            _line.SetPosition(INIT_LEFT + 1, INIT_TOP + 1, INIT_RIGHT + 1, INIT_BOTTOM + 1);

            Assert.AreEqual(INIT_LEFT + 1, _line.GetPosition()._left);
            Assert.AreEqual(INIT_TOP + 1, _line.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT + 1, _line.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM + 1, _line.GetPosition()._bottom);
        }

        //測試線設定座標
        [TestMethod()]
        public void SetCoordinateTest()
        {
            _line.SetCoordinate(INIT_LEFT + 1, INIT_TOP + 1, INIT_RIGHT + 1, INIT_BOTTOM + 1);

            Assert.AreEqual(INIT_LEFT + 1, _line.GetPosition()._left);
            Assert.AreEqual(INIT_TOP + 1, _line.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT + 1, _line.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM + 1, _line.GetPosition()._bottom);
        }

        //測試取得座標
        [TestMethod()]
        public void GetPositionTest()
        {
            Coordinate coordinate = _line.GetPosition();

            Assert.AreSame(coordinate, _linePrivate.GetField("_position"));
        }

        //測試線繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expected = 1;
            IGraphicsMock graphics = new IGraphicsMock();

            _line.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawLineCount);
        }

        //測試線選取繪圖
        [TestMethod()]
        public void SelectDrawTest()
        {
            int expected = 1;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();

            _line.SetSelect(true);
            _line.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawLineCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }
    }
}