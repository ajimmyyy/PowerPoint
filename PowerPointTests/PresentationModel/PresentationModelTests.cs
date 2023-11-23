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

        //測試PresentationModel更新鼠標
        [TestMethod()]
        [DataRow(true, false, false, "Cross")]
        [DataRow(false, true, false, "Cross")]
        [DataRow(false, false, true, "Cross")]
        [DataRow(false, false, false, "Default")]
        public void UpdateCursorTest(bool isLinePressed, bool isRectanglePressed,bool isCirclePressed, string expected)
        {
            _presentationModelPrivate.SetField("_isLinePressed", isLinePressed);
            _presentationModelPrivate.SetField("_isRectanglePressed", isRectanglePressed);
            _presentationModelPrivate.SetField("_isCirclePressed", isCirclePressed);;

            _presentationModel.UpdateCursor();

            Assert.AreEqual(expected, _presentationModel.GetCursorType());
        }

        //測試PresentationModel更新鼠標(在縮放區域)
        [TestMethod()]
        public void UpdateCursorInScaleAreaTest()
        {
            string expected = "SizeNWSE";
            _presentationModelPrivate.SetField("_isInScaleArea", true);

            _presentationModel.UpdateCursor();

            Assert.AreEqual(expected, _presentationModel.GetCursorType());
        }

        //測試PresentationModel當滑鼠被按下
        [TestMethod()]
        public void CanvasPressedHandlerTest()
        {
            _presentationModelPrivate.SetField("_isInScaleArea", true);
            _presentationModel.CanvasPressedHandler(0, 0);

            Assert.AreEqual(true, _presentationModelPrivate.GetField("_isScaleMode"));
            _presentationModelPrivate.SetField("_isInScaleArea", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasPressedHandler(0, 0);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasPressedHandler(0, 0);
            _presentationModelPrivate.SetField("_isLinePressed", false);
        }

        //測試PresentationModel當滑鼠移動
        [TestMethod()]
        public void CanvasMoveHandlerTest()
        {
            _presentationModelPrivate.SetField("_isScaleMode", true);
            _presentationModel.CanvasMoveHandler(0, 0);

            Assert.AreEqual(false, _presentationModelPrivate.GetField("_isInScaleArea"));
            _presentationModelPrivate.SetField("_isScaleMode", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasMoveHandler(0, 0);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasMoveHandler(0, 0);
            _presentationModelPrivate.SetField("_isLinePressed", false);
        }

        //測試PresentationModel當滑鼠釋放
        [TestMethod()]
        public void CanvasReleasedHandlerTest()
        {
            _presentationModelPrivate.SetField("_isScaleMode", true);
            _presentationModel.CanvasReleasedHandler(0, 0);

            Assert.AreEqual(true, _presentationModelPrivate.GetField("_isSelectPressed"));
            _presentationModelPrivate.SetField("_isScaleMode", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasReleasedHandler(0, 0);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasReleasedHandler(0, 0);
            _presentationModelPrivate.SetField("_isLinePressed", false);
        }

        //測試PresentationModel當鍵盤刪除按下
        [TestMethod()]
        public void PressKeyboardHandlerTest()
        {
            _presentationModel.PressKeyboardHandler("");

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.PressKeyboardHandler("Delete");
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.PressKeyboardHandler("Delete");
            _presentationModelPrivate.SetField("_isLinePressed", false);
        }

        //測試PresentationModel繪畫區繪圖
        [TestMethod()]
        public void CanvasDrawTest()
        {

        }

        //測試PresentationModel縮圖區繪圖
        [TestMethod()]
        public void SlideDrawTest()
        {

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