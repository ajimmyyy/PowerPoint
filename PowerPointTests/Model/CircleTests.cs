﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        //測試圓形初始化
        [TestInitialize()]
        public void Initialize()
        {
            _circle = new Circle(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
        }

        //測試圓形設定位置
        [TestMethod()]
        public void TestSetPosition()
        {
            _circle.SetPosition(INIT_LEFT + 1, INIT_TOP + 1, INIT_RIGHT + 1, INIT_BOTTOM + 1);

            Assert.AreEqual(INIT_LEFT + 1, _circle.GetPosition()._left);
            Assert.AreEqual(INIT_TOP + 1, _circle.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT + 1, _circle.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM + 1, _circle.GetPosition()._bottom);
        }

        //測試圓形繪圖
        [TestMethod()]
        public void TestDraw()
        {
            
        }
    }
}