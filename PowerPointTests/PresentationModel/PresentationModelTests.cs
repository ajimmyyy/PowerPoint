using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        PresentationModel _presentationModel;
        Model _model;
        PrivateObject _modelPrivate;
        PrivateObject _presentationModelPrivate;

        //測試PresentationModel初始化
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _presentationModel = new PresentationModel(_model);
            _modelPrivate = new PrivateObject(_model);
            _presentationModelPrivate = new PrivateObject(_presentationModel);
        }

        //測試PresentationModel當tool按鈕被按下
        [TestMethod()]
        [DataRow(ModeType.LINE_NAME, "_isLinePressed")]
        [DataRow(ModeType.CIRCLE_NAME, "_isCirclePressed")]
        [DataRow(ModeType.RECTANGLE_NAME, "_isRectanglePressed")]
        [DataRow(ModeType.SELECT_NAME, "_isSelectPressed")]
        public void ToolButtonClickHandlerTest(string shapeType, string buttonPressed)
        {
            bool expected = true;
            _presentationModel.ToolButtonClickHandler(shapeType);

            Assert.AreEqual(shapeType, _modelPrivate.GetField("_toolModePressed"));
            Assert.AreEqual(expected, _presentationModelPrivate.GetField(buttonPressed));
        }

        //測試PresentationModel更新鼠標(預設)
        [TestMethod()]
        public void UpdateCursorTest()
        {
            Cursor expected = Cursors.Default;
            _presentationModelPrivate.SetField("_isLinePressed", false);
            _presentationModelPrivate.SetField("_isRectanglePressed", false);
            _presentationModelPrivate.SetField("_isCirclePressed", false);

            _presentationModel.UpdateCursor();

            Assert.AreEqual(expected, _presentationModel.CursorNow);
        }

        //測試PresentationModel更新鼠標(在繪圖模式)
        [TestMethod()]
        [DataRow(true, false, false)]
        [DataRow(false, true, false)]
        [DataRow(false, false, true)]
        public void UpdateCursorToolPressedTest(bool isLinePressed, bool isRectanglePressed,bool isCirclePressed)
        {
            Cursor expected = Cursors.Cross;

            _presentationModelPrivate.SetField("_isLinePressed", isLinePressed);
            _presentationModelPrivate.SetField("_isRectanglePressed", isRectanglePressed);
            _presentationModelPrivate.SetField("_isCirclePressed", isCirclePressed);

            _presentationModel.UpdateCursor();

            Assert.AreEqual(expected, _presentationModel.CursorNow);
        }

        //測試PresentationModel更新鼠標(在縮放區域)
        [TestMethod()]
        public void UpdateCursorInScaleAreaTest()
        {
            Cursor expected = Cursors.SizeNWSE;
            _presentationModelPrivate.SetField("_isInScaleArea", true);

            _presentationModel.UpdateCursor();

            Assert.AreEqual(expected, _presentationModel.CursorNow);
        }

        //測試PresentationModel當滑鼠被按下
        [TestMethod()]
        public void CanvasPressedHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModelPrivate.SetField("_isInScaleArea", true);
            _presentationModel.CanvasPressedHandler(0, 0);
            Assert.AreEqual(true, _presentationModelPrivate.GetField("_isScaleMode"));
            Assert.AreEqual(expectedCount++, modelmock.PressCount);
            _presentationModelPrivate.SetField("_isInScaleArea", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasPressedHandler(0, 0);
            Assert.AreEqual(expectedCount++, modelmock.PressCount);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasPressedHandler(0, 0);
            Assert.AreEqual(expectedCount, modelmock.PressCount);
            _presentationModelPrivate.SetField("_isLinePressed", false);

            _presentationModel.CanvasPressedHandler(0, 0);
            Assert.AreEqual(expectedCount, modelmock.PressCount);
        }

        //測試PresentationModel當滑鼠移動
        [TestMethod()]
        public void CanvasMoveHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModelPrivate.SetField("_isScaleMode", true);
            _presentationModel.CanvasMoveHandler(0, 0);
            Assert.AreEqual(false, _presentationModelPrivate.GetField("_isInScaleArea"));
            Assert.AreEqual(expectedCount++, modelmock.MoveCount);
            _presentationModelPrivate.SetField("_isScaleMode", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasMoveHandler(0, 0);
            Assert.AreEqual(expectedCount++, modelmock.MoveCount);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasMoveHandler(0, 0);
            Assert.AreEqual(expectedCount, modelmock.MoveCount);
            _presentationModelPrivate.SetField("_isLinePressed", false);

            _presentationModel.CanvasMoveHandler(0, 0);
            Assert.AreEqual(expectedCount, modelmock.MoveCount);
        }

        //測試PresentationModel當滑鼠釋放
        [TestMethod()]
        public void CanvasReleasedHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModelPrivate.SetField("_isScaleMode", true);
            _presentationModel.CanvasReleasedHandler(0, 0);
            Assert.AreEqual(false, _presentationModelPrivate.GetField("_isScaleMode"));
            Assert.AreEqual(expectedCount++, modelmock.ReleaseCount);
            _presentationModelPrivate.SetField("_isScaleMode", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasReleasedHandler(0, 0);
            Assert.AreEqual(expectedCount++, modelmock.ReleaseCount);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasReleasedHandler(0, 0);
            Assert.AreEqual(expectedCount, modelmock.ReleaseCount);
            _presentationModelPrivate.SetField("_isLinePressed", false);

            _presentationModelPrivate.SetField("_isSelectPressed", false);
            _presentationModel.CanvasReleasedHandler(0, 0);
            Assert.AreEqual(expectedCount, modelmock.ReleaseCount);
        }

        //測試PresentationModel當鍵盤刪除按下
        [TestMethod()]
        public void PressKeyboardHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);
            _presentationModel.PressKeyboardHandler(Keys.None);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.PressKeyboardHandler(Keys.Delete);
            Assert.AreEqual(expectedCount++, modelmock.DeleteCount);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.PressKeyboardHandler(Keys.Delete);
            Assert.AreEqual(expectedCount, modelmock.DeleteCount);
            _presentationModelPrivate.SetField("_isLinePressed", false);

            _presentationModel.PressKeyboardHandler(Keys.Delete);
            Assert.AreEqual(expectedCount, modelmock.DeleteCount);
        }

        //測試PresentationModel,tool按鈕是否被按下
        [TestMethod()]
        [DataRow(false, false, false, false)]
        [DataRow(true, false, false, true)]
        [DataRow(false, true, false, true)]
        [DataRow(false, false, true, true)]
        public void IsToolButtonPressedTset(bool linePressed, bool rectanglePressed, bool circlePressed, bool expected)
        {
            _presentationModelPrivate.SetField("_isLinePressed", linePressed);
            _presentationModelPrivate.SetField("_isRectanglePressed", rectanglePressed);
            _presentationModelPrivate.SetField("_isCirclePressed", circlePressed);

            Assert.AreEqual(expected, _presentationModelPrivate.Invoke("IsToolButtonPressed"));
        }

        //測試PresentationModel重置tool按鈕
        [TestMethod()]
        public void ToolButtonResetTest()
        {
            _presentationModelPrivate.Invoke("ToolButtonReset");

            Assert.IsFalse(_presentationModel.IsCirclePressed);
            Assert.IsFalse(_presentationModel.IsLinePressed);
            Assert.IsFalse(_presentationModel.IsRectanglePressed);
            Assert.IsFalse(_presentationModel.IsSelectPressed);
        }

        //測試PresentationModel繪畫區繪圖
        [TestMethod()]
        public void CanvasDrawTest()
        {
            int expected = 1;
            ModelMock modelmock = new ModelMock();
            
            _presentationModelPrivate.SetField("_model", modelmock);

            using (var bitmap = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                _presentationModel.CanvasDraw(graphics);

                Assert.AreEqual(expected, modelmock.DrawCount);
            }
        }
        //測試PresentationModel縮圖區繪圖
        [TestMethod()]
        public void SlideDrawTest()
        {
            int expected = 1;
            ModelMock modelmock = new ModelMock();

            _presentationModelPrivate.SetField("_model", modelmock);

            using (var bitmap = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                _presentationModel.SlideDraw(graphics);

                Assert.AreEqual(expected, modelmock.DrawCount);
            }
        }

        //測試PresentationModel通知tool按鈕屬性改變
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            bool eventRaised = false;
            _presentationModel.PropertyChanged += (sender, args) => { eventRaised = true; };

            _presentationModelPrivate.Invoke("NotifyPropertyChanged");
            Assert.IsTrue(eventRaised);
        }

        //測試PresentationModel通知鼠標屬性改變
        [TestMethod()]
        public void NotifyCursorChanged()
        {
            bool eventRaised = false;
            _presentationModel._cursorChanged += () => { eventRaised = true; };

            _presentationModelPrivate.Invoke("NotifyCursorChanged");
            Assert.IsTrue(eventRaised);
        }
    }
}