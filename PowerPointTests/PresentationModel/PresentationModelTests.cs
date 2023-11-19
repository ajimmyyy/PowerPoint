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

        //測試PresentationModel當滑鼠被按下
        [TestMethod()]
        public void CanvasPressedHandlerTest()
        {
            Assert.Fail();
        }

        //測試PresentationModel當滑鼠移動
        [TestMethod()]
        public void CanvasMoveHandlerTest()
        {
            Assert.Fail();
        }

        //測試PresentationModel當滑鼠釋放
        [TestMethod()]
        public void CanvasReleasedHandlerTest()
        {
            Assert.Fail();
        }

        //測試PresentationModel當鍵盤刪除按下
        [TestMethod()]
        public void PressKeyboardHandlerTest()
        {
            Assert.Fail();
        }

        //測試PresentationModel繪畫區繪圖
        [TestMethod()]
        public void CanvasDrawTest()
        {
            Assert.Fail();
        }

        //測試PresentationModel縮圖區繪圖
        [TestMethod()]
        public void SlideDrawTest()
        {
            Assert.Fail();
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
    }
}