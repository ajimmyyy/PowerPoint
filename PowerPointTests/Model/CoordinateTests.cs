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

        [TestInitialize()]
        public void Initialize()
        {
            _coordinate = new Coordinate();
            _coordinate._left = INIT_LEFT;
            _coordinate._top = INIT_TOP;
            _coordinate._right = INIT_RIGHT;
            _coordinate._bottom = INIT_BOTTOM;
        }

        [TestMethod()]
        public void TestMiddleX()
        {
            Assert.AreEqual((INIT_LEFT + INIT_RIGHT) / 2, _coordinate.middleX);
        }

        [TestMethod()]
        public void TestMiddleY()
        {
            Assert.AreEqual((INIT_BOTTOM + INIT_TOP) / 2, _coordinate.middleY);
        }

        [TestMethod()]
        [DataRow(1, 200, true)]
        [DataRow(0, 200, false)]
        [DataRow(400, 200, true)]
        [DataRow(400, 199, false)]
        public void TestIsInside(double pointX, double pointY, bool expected)
        {
            Assert.AreEqual(expected, _coordinate.IsInside(pointX, pointY));
        }

        [TestMethod()]
        public void TestToString()
        {
            string expected = string.Format("(({0}, {1}), ({2}, {3}))", INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);

            Assert.AreEqual(expected, _coordinate.ToString());
        }
    }
}