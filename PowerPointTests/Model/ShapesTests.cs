using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes _shapes;
        PrivateObject _shapePrivate;

        //測試Shapes初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
            _shapePrivate = new PrivateObject(_shapes);
        }

        //測試Shapes取得binding List
        [TestMethod()]
        public void GetShapeListTest()
        {
            BindingList<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as BindingList<Shape>;

            Assert.AreSame(shapeList, _shapes.GetShapeList);
        }

        //測試Shapes創建形狀並加入到list裡
        [TestMethod()]
        public void AddNewShapeTest()
        {
            List<string> testShapeName = new List<string> { ModeType.LINE_NAME, ModeType.CIRCLE_NAME, ModeType.RECTANGLE_NAME };
            List<Type> testShapeType = new List<Type> { typeof(Line), typeof(Circle), typeof(Rectangle) };
            BindingList<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as BindingList<Shape>;

            for (int i = 0; i < testShapeName.Count; i++)
            {
                _shapes.AddNewShape(testShapeName[i]);
                Assert.IsInstanceOfType(shapeList[i], testShapeType[i]);
            }
        }

        //測試Shapes加入現有形狀
        [TestMethod()]
        public void AddShapeTest()
        {
            int expected = 1;
            Shape testShape = Factory.CreateShape(ModeType.LINE_NAME);
            BindingList<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as BindingList<Shape>;

            _shapes.AddShape(testShape);
            Assert.AreEqual(expected, shapeList.Count);
        }

        //測試Shapes加入現有形狀(無形狀)
        [TestMethod()]
        public void AddShapeNullShapeTest()
        {
            int expected = 0;
            Shape testShape = null;
            BindingList<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as BindingList<Shape>;

            _shapes.AddShape(testShape);
            Assert.AreEqual(expected, shapeList.Count);
        }

        //測試Shapes刪除list裡的形狀(by index)
        [TestMethod()]
        public void DeleteShapeByIndexTest()
        {
            BindingList<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as BindingList<Shape>;

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

        //測試Shapes刪除list裡的形狀(by shape)
        [TestMethod()]
        public void DeleteShapeByShapeTest()
        {
            BindingList<Shape> shapeList = _shapePrivate.GetFieldOrProperty("_shapeList") as BindingList<Shape>;
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

        //測試Shapes選取形狀
        [TestMethod()]
        [DataRow(0, 100, true)]
        [DataRow(200, 300, true)]
        [DataRow(1, 301, false)]
        public void FindShapeTest(double pointX, double pointY, bool expected)
        {
            Shape testLine = Factory.CreateShape(ModeType.LINE_NAME);
            testLine.SetPosition(0, 100, 200, 300);

            _shapes.AddShape(testLine);

            Assert.AreEqual(expected, _shapes.FindShape(pointX, pointY) != null);
        }

        //測試Shapes選取形狀(by index)
        [TestMethod()]
        public void FindShapeByIndexTest()
        {
            Shape testLine = Factory.CreateShape(ModeType.LINE_NAME);
            Shape testCircle = Factory.CreateShape(ModeType.CIRCLE_NAME);

            Assert.IsNull(_shapes.FindShape(0));

            _shapes.AddShape(testLine);
            _shapes.AddShape(testCircle);

            Assert.AreSame(testLine, _shapes.FindShape(0));
            Assert.AreSame(testCircle, _shapes.FindShape(1));
        }

        //測試Shapes繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expectedLine = 2;
            int expectedCircle = 1;
            int expectedRectengle = 1;
            IGraphicsMock graphics = new IGraphicsMock();

            _shapes.AddNewShape(ModeType.LINE_NAME);
            _shapes.AddNewShape(ModeType.LINE_NAME);
            _shapes.AddNewShape(ModeType.CIRCLE_NAME);
            _shapes.AddNewShape(ModeType.RECTANGLE_NAME);

            _shapes.Draw(graphics);

            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectengle, graphics.DrawRectangleCount);
        }

        //測試Shapes取得形狀數量
        [TestMethod()]
        public void CountTest()
        {
            int expected = 1;
            Shape testLine = Factory.CreateShape(ModeType.LINE_NAME);

            _shapes.AddShape(testLine);

            Assert.AreEqual(expected, _shapes.GetCount());
        }
    }
}