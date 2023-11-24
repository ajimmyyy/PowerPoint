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
    public class FactoryTests
    {
        //測試工廠創建線實體
        [TestMethod()]
        public void CreateShapeLineTest()
        {
            Shape shape = Factory.CreateShape(ModeType.LINE_NAME);
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Line));
        }

        //測試工廠創建圓形實體
        [TestMethod()]
        public void CreateShapeCircleTest()
        {
            Shape shape = Factory.CreateShape(ModeType.CIRCLE_NAME);
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Circle));
        }

        //測試工廠創建矩形實體
        [TestMethod()]
        public void CreateShapeRectangleTest()
        {
            Shape shape = Factory.CreateShape(ModeType.RECTANGLE_NAME);
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Rectangle));
        }

        //測試工廠創建圖形實體(輸入空字串)
        [TestMethod()]
        public void CreateShapeNullTest()
        {
            Shape shape = Factory.CreateShape("");
            Assert.IsNull(shape);
        }
    }
}