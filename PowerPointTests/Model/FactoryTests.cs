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
    public class FactoryTests
    {
        [TestMethod()]
        public void CreateShapeLineTest()
        {
            Shape shape = Factory.CreateShape(ModeType.LINE_NAME);
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Line));
        }

        [TestMethod()]
        public void CreateShapeCircleTest()
        {
            Shape shape = Factory.CreateShape(ModeType.CIRCLE_NAME);
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Circle));
        }

        [TestMethod()]
        public void CreateShapeRectangleTest()
        {
            Shape shape = Factory.CreateShape(ModeType.RECTANGLE_NAME);
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Rectangle));
        }

        [TestMethod()]
        public void CreateShapeNullTest()
        {
            Shape shape = Factory.CreateShape("");
            Assert.IsNull(shape);
        }
    }
}