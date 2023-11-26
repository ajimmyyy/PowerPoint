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
    public class ShapeTests
    {
        const double INIT_LEFT = 0;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 100;
        Shape _shape;
        PrivateObject _shapePrivate;

        //測試圖形初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _shapePrivate = new PrivateObject(_shape);
        }

        //測試圖形取得Info
        [TestMethod()]
        public void InfoTest()
        {
            string expected = "((0, 200), (400, 100))";

            Assert.AreEqual(expected, _shape.Info);
        }
        //測試圖形取得ShapeName
        [TestMethod()]
        public void ShapeNameTest()
        {
            string expected = ModeType.LINE_NAME;

            Assert.AreEqual(expected, _shape.ShapeName);
        }

        //測試圖形取得選取框資訊
        [TestMethod()]
        public void GetSelectionTest()
        {
            Assert.AreSame(_shapePrivate.GetField("_selection"), _shape.GetSelection());
        }

        //測試圖形是否被選取
        [TestMethod()]
        public void IsSelectTest()
        {
            bool expected = false;

            Assert.AreEqual(expected, _shape.IsSelect());
        }

        //測試圖形通知資料改變
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            bool eventRaised = false;
            _shape.PropertyChanged += (sender, args) => { eventRaised = true; };

            _shapePrivate.Invoke("NotifyPropertyChanged", "PropertyName");
            Assert.IsTrue(eventRaised);
        }
    }
}