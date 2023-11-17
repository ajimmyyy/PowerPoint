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

        [TestInitialize()]
        public void Initialize()
        {
            _line = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
        }

        [TestMethod()]
        public void TestGetInfo()
        {
            string expected = string.Format("(({0}, {1}), ({2}, {3}))", INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);

            Assert.AreEqual(expected, _line.GetInfo());
        }

        [TestMethod()]
        public void TestGetShapeName()
        {
            Assert.AreEqual(ModeType.LINE_NAME, _line.GetShapeName());
        }

        [TestMethod()]
        public void TestSetPosition()
        {
            _line.SetPosition(INIT_LEFT + 1, INIT_TOP + 1, INIT_RIGHT + 1, INIT_BOTTOM + 1);

            Assert.AreEqual(INIT_LEFT + 1, _line.GetPosition()._left);
            Assert.AreEqual(INIT_TOP + 1, _line.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT + 1, _line.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM + 1, _line.GetPosition()._bottom);
        }

        [TestMethod()]
        public void TestDraw()
        {
            
        }
    }
}