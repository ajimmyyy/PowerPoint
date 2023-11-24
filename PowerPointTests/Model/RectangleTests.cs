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
    public class RectangleTests
    {
        const double INIT_LEFT = 0;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 100;
        Rectangle _rectangle;

        //測試矩形初始化
        [TestInitialize()]
        public void Initialize()
        {
            _rectangle = new Rectangle(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
        }

        //測試矩形設定位置
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        [DataRow(0, 0, 100, 200)]
        public void TestSetPosition(double left, double top, double right, double bottom)
        {
            _rectangle.SetPosition(INIT_LEFT + left, INIT_TOP + top, INIT_RIGHT + right, INIT_BOTTOM + bottom);

            Assert.AreEqual(Math.Min(INIT_LEFT + left, INIT_RIGHT + right), _rectangle.GetPosition()._left);
            Assert.AreEqual(Math.Min(INIT_TOP + top, INIT_BOTTOM + bottom), _rectangle.GetPosition()._top);
            Assert.AreEqual(Math.Max(INIT_LEFT + left, INIT_RIGHT + right), _rectangle.GetPosition()._right);
            Assert.AreEqual(Math.Max(INIT_TOP + top, INIT_BOTTOM + bottom), _rectangle.GetPosition()._bottom);
        }

        //測試矩形設定座標
        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        [DataRow(0, 0, 100, 200)]
        public void SetCoordinateTest(double left, double top, double right, double bottom)
        {
            _rectangle.SetPosition(INIT_LEFT + left, INIT_TOP + top, INIT_RIGHT + right, INIT_BOTTOM + bottom);

            Assert.AreEqual(Math.Min(INIT_LEFT + left, INIT_RIGHT + right), _rectangle.GetPosition()._left);
            Assert.AreEqual(Math.Min(INIT_TOP + top, INIT_BOTTOM + bottom), _rectangle.GetPosition()._top);
            Assert.AreEqual(Math.Max(INIT_LEFT + left, INIT_RIGHT + right), _rectangle.GetPosition()._right);
            Assert.AreEqual(Math.Max(INIT_TOP + top, INIT_BOTTOM + bottom), _rectangle.GetPosition()._bottom);
        }

        //測試矩形繪圖
        [TestMethod()]
        public void TestDraw()
        {
            int expected = 1;
            IGraphicsMock graphics = new IGraphicsMock();

            _rectangle.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawRectangleCount);
        }
    }
}