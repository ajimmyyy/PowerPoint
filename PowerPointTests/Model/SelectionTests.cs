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
    public class SelectionTests
    {
        const double INIT_LEFT = 1;
        const double INIT_TOP = 200;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 300;
        Selection _selection;
        PrivateObject _selectionPrivate;
        Shape _shape;

        //測試選取初始化
        [TestInitialize()]
        public void Initialize()
        {
            _selection = new Selection();
            _selectionPrivate = new PrivateObject(_selection);
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
        }

        //測試選取設定位置
        [TestMethod()]
        public void SetPositionTest()
        {
            Coordinate expectd = new Coordinate();

            _selection.SetPosition(expectd);

            Assert.AreSame(expectd, _selectionPrivate.GetField("_position"));
        }

        //測試選取繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expected = 8;
            IGraphicsMock graphics = new IGraphicsMock();

            _selection.Draw(graphics);

            Assert.AreEqual(expected, graphics.DrawDotCount);
        }

        //測試選取是否在拉選區域
        [TestMethod()]
        [DataRow(400, 300, true)]
        [DataRow(395, 295, false)]
        [DataRow(405, 305, false)]
        public void IsScaleAreaTest(double pointX, double pointY, bool expected)
        {
            _selection.SetPosition(_shape.GetPosition());

            Assert.AreEqual(expected, _selection.IsScaleArea(pointX, pointY));
        }
    }
}