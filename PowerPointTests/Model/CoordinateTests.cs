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
    public class CoordinateTests
    {
        const double INIT_LEFT = 1;
        const double INIT_TOP = 300;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 200;
        Coordinate _coordinate;

        //測試座標初始化
        [TestInitialize()]
        public void Initialize()
        {
            _coordinate = new Coordinate();
            _coordinate._left = INIT_LEFT;
            _coordinate._top = INIT_TOP;
            _coordinate._right = INIT_RIGHT;
            _coordinate._bottom = INIT_BOTTOM;
        }

        //測試座標計算X軸中點
        [TestMethod()]
        public void MiddleXTest()
        {
            Assert.AreEqual((INIT_LEFT + INIT_RIGHT) / 2, _coordinate.middleX);
        }

        //測試座標計算Y軸中點
        [TestMethod()]
        public void MiddleYTest()
        {
            Assert.AreEqual((INIT_BOTTOM + INIT_TOP) / 2, _coordinate.middleY);
        }

        //測試座標判斷是否在範圍內
        [TestMethod()]
        [DataRow(1, 200, true)]
        [DataRow(0, 199, false)]
        [DataRow(400, 300, true)]
        [DataRow(401, 301, false)]
        public void IsInsideTest(double pointX, double pointY, bool expected)
        {
            Assert.AreEqual(expected, _coordinate.IsInside(pointX, pointY));
        }

        //測試座標字串化
        [TestMethod()]
        public void ToStringTest()
        {
            string expected = string.Format("(({0}, {1}), ({2}, {3}))", INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);

            Assert.AreEqual(expected, _coordinate.ToString());
        }

        //測試座標克隆座標
        [TestMethod()]
        public void CloneTest()
        {
            Coordinate coordinate = _coordinate.Clone();

            Assert.AreEqual(INIT_LEFT, coordinate._left);
            Assert.AreEqual(INIT_TOP, coordinate._top);
            Assert.AreEqual(INIT_RIGHT, coordinate._right);
            Assert.AreEqual(INIT_BOTTOM, coordinate._bottom);
            Assert.AreNotSame(_coordinate, coordinate);
        }
    }
}