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

        [TestInitialize()]
        public void Initialize()
        {
            _rectangle = new Rectangle(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
        }

        [TestMethod()]
        public void TestGetInfo()
        {
            string expected = string.Format("(({0}, {1}), ({2}, {3}))", INIT_LEFT, INIT_BOTTOM, INIT_RIGHT, INIT_TOP);

            Assert.AreEqual(expected, _rectangle.GetInfo());
        }

        [TestMethod()]
        public void TestGetShapeName()
        {
            Assert.AreEqual(ModeType.RECTANGLE_NAME, _rectangle.GetShapeName());
        }

        [TestMethod()]
        public void TestSetPosition()
        {
            _rectangle.SetPosition(INIT_LEFT + 1, INIT_TOP + 1, INIT_RIGHT + 100, INIT_BOTTOM + 200);

            Assert.AreEqual(INIT_LEFT + 1, _rectangle.GetPosition()._left);
            Assert.AreEqual(INIT_TOP + 1, _rectangle.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT + 100, _rectangle.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM + 200, _rectangle.GetPosition()._bottom);
        }

        [TestMethod()]
        public void TestDraw()
        {
            
        }
    }
}