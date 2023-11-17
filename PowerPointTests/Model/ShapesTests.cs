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
    public class ShapesTests
    {
        Shapes _shapes;
        PrivateObject _shapePrivate;

        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
            _shapePrivate = new PrivateObject(_shapes);
        }

        [TestMethod()]
        public void AddNewShapeTest()
        {
            List<string> testShapeName = new List<string> { ModeType.LINE_NAME, ModeType.CIRCLE_NAME, ModeType.RECTANGLE_NAME };
            List<Type> testShapeType = new List<Type> { typeof(Line), typeof(Circle), typeof(Rectangle) };
            List<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as List<Shape>;

            for (int i = 0; i < testShapeName.Count; i ++)
            {
                _shapes.AddNewShape(testShapeName[i]);
                Assert.IsInstanceOfType(shapeList[i], testShapeType[i]);
            }

            _shapes.AddNewShape("");
            Assert.AreEqual(testShapeName.Count, shapeList.Count);
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            Shape testShape = Factory.CreateShape(ModeType.LINE_NAME);
            List<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as List<Shape>;

            _shapes.AddShape(testShape);
            Assert.AreEqual(1, shapeList.Count);
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            List<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as List<Shape>;

            _shapes.AddNewShape(ModeType.LINE_NAME);
            _shapes.AddNewShape(ModeType.CIRCLE_NAME);

            _shapes.DeleteShape(0);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsInstanceOfType(shapeList[0], typeof(Circle));
            _shapes.DeleteShape(0);
            Assert.AreEqual(0, shapeList.Count);
            _shapes.DeleteShape(0);
            Assert.AreEqual(0, shapeList.Count);
        }

        [TestMethod()]
        public void DeleteShapeByShapeTest()
        {
            List<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as List<Shape>;
            Shape testLine = Factory.CreateShape(ModeType.LINE_NAME);
            Shape testCircle = Factory.CreateShape(ModeType.CIRCLE_NAME);

            _shapes.AddShape(testLine);
            _shapes.AddShape(testCircle);

            _shapes.DeleteShape(testCircle);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsInstanceOfType(shapeList[0], typeof(Line));
            _shapes.DeleteShape(testLine);
            Assert.AreEqual(0, shapeList.Count);
            _shapes.DeleteShape(testLine);
            Assert.AreEqual(0, shapeList.Count);
        }

        [TestMethod()]
        public void FindShapeTest()
        {
            Shape testLine = Factory.CreateShape(ModeType.LINE_NAME);
            testLine.SetPosition(0, 100, 200, 300);
        }

        [TestMethod()]
        public void GetShapeListInfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DrawTest()
        {
            
        }
    }
}