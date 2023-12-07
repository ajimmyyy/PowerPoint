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
        const int INIT_DRAW_WIDTH = 812;
        const int INIT_SLIDE_WIDTH = 128;
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
        public void UpdateCursorToolPressedTest(bool isLinePressed, bool isRectanglePressed, bool isCirclePressed)
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

        //測試PresentationModel當DataGridView新增按鈕被按下
        [TestMethod()]
        public void AddButtonClickHandlerTest()
        {
            int expected = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModel.AddButtonClickHandler(ModeType.LINE_NAME);

            Assert.AreEqual(expected, modelmock.AddButtonCount);
        }

        //測試PresentationModel當DataGridView刪除按鈕被按下
        [TestMethod()]
        public void DeleteCellClickHandlerTest()
        {
            int expected = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModel.DeleteCellClickHandler(1, 1);

            Assert.AreEqual(expected, modelmock.DeleteButtonCount);
        }

        //測試PresentationModel當滑鼠被按下
        [TestMethod()]
        public void CanvasPressedHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModelPrivate.SetField("_isInScaleArea", true);
            _presentationModel.CanvasPressedHandler(1, 1, INIT_DRAW_WIDTH);
            Assert.AreEqual(expectedCount++, modelmock.PressCount);
            _presentationModelPrivate.SetField("_isInScaleArea", false);

            _presentationModelPrivate.SetField("_isSelectPressed", true);
            _presentationModel.CanvasPressedHandler(1, 1, INIT_DRAW_WIDTH);
            Assert.AreEqual(expectedCount++, modelmock.PressCount);
            _presentationModelPrivate.SetField("_isSelectPressed", false);

            _presentationModelPrivate.SetField("_isLinePressed", true);
            _presentationModel.CanvasPressedHandler(1, 1, INIT_DRAW_WIDTH);
            Assert.AreEqual(expectedCount, modelmock.PressCount);
            _presentationModelPrivate.SetField("_isLinePressed", false);

            _presentationModel.CanvasPressedHandler(0, 0, INIT_DRAW_WIDTH);
            Assert.AreEqual(expectedCount, modelmock.PressCount);
        }

        //測試PresentationModel當滑鼠移動
        [TestMethod()]
        public void CanvasMoveHandlerTest()
        {
            int expectedMoveCount = 1;
            int expectedInAreaCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModel.CanvasMoveHandler(1, 1, INIT_DRAW_WIDTH);

            Assert.AreEqual(expectedMoveCount, modelmock.MoveCount);
            Assert.AreEqual(expectedInAreaCount, modelmock.InScaleAreaCount);
        }

        //測試PresentationModel當滑鼠釋放
        [TestMethod()]
        public void CanvasReleasedHandlerTest()
        {
            int expectedReleaseCount = 1;
            int expectedSetToolCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModel.CanvasReleasedHandler(1, 1);

            Assert.AreEqual(expectedReleaseCount, modelmock.ReleaseCount);
            Assert.AreEqual(false, _presentationModel.IsLinePressed);
            Assert.AreEqual(false, _presentationModel.IsCirclePressed);
            Assert.AreEqual(false, _presentationModel.IsRectanglePressed);
            Assert.AreEqual(true, _presentationModel.IsSelectPressed);
            Assert.AreEqual(expectedSetToolCount, modelmock.SetToolCount);
        }

        //測試PresentationModel當鍵盤刪除按下
        [TestMethod()]
        public void PressKeyboardHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);
            _presentationModel.PressKeyboardHandler(Keys.None);

            _presentationModel.PressKeyboardHandler(Keys.Delete);
            Assert.AreEqual(expectedCount, modelmock.DeleteCount);
        }

        //測試PresentationModel當復原按鈕被按下
        [TestMethod()]
        public void UndoToolButtonClickHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);
            _presentationModelPrivate.SetField("_isUndoEnabled", true);

            _presentationModel.UndoToolButtonClickHandler();

            Assert.AreEqual(expectedCount, modelmock.UndoCount);
        }

        //測試PresentationModel當復原按鈕被按下(unabled)
        [TestMethod()]
        public void UndoToolButtonClickHandlerUnabledTest()
        {
            int expectedCount = 0;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModel.UndoToolButtonClickHandler();

            Assert.AreEqual(expectedCount, modelmock.UndoCount);
        }

        //測試PresentationModel當重做按鈕被按下
        [TestMethod()]
        public void RedoToolButtonClickHandlerTest()
        {
            int expectedCount = 1;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);
            _presentationModelPrivate.SetField("_isRedoEnabled", true);

            _presentationModel.RedoToolButtonClickHandler();

            Assert.AreEqual(expectedCount, modelmock.RedoCount);
        }

        //測試PresentationModel當重做按鈕被按下(unabled)
        [TestMethod()]
        public void RedoToolButtonClickHandlerUnabledTest()
        {
            int expectedCount = 0;
            ModelMock modelmock = new ModelMock();
            _presentationModelPrivate.SetField("_model", modelmock);

            _presentationModel.RedoToolButtonClickHandler();

            Assert.AreEqual(expectedCount, modelmock.RedoCount);
        }

        //測試PresentationModel計算16:9視窗高度
        [TestMethod()]
        [DataRow(160, 91)]
        [DataRow(1, 1)]
        [DataRow(0, 1)]
        public void ResizeWindowTest(int width, int expectedHeight)
        {
            Assert.AreEqual(expectedHeight, _presentationModel.ResizeWindow(width));
        }

        //測試PresentationModel計算視窗置中距離
        [TestMethod()]
        [DataRow(100, 50, 25)]
        public void RepositionWindowTest(int containerHeight, int panelHeight, int expectedPosition)
        {
            Assert.AreEqual(expectedPosition, _presentationModel.RepositionWindow(containerHeight, panelHeight));
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

        //測試PresentationModel, Redo,Undo是否可用
        [TestMethod()]
        public void ToolButtonEnabledCheckTest()
        {
            _model.LogCommand(new DrawCommand(_model, new Line(0, 0, 0, 0)));

            _presentationModelPrivate.Invoke("ToolButtonEnabledCheck");

            Assert.IsTrue(_presentationModel.IsUndoEnabled);
            Assert.IsFalse(_presentationModel.IsRedoEnabled);

            _model.Undo();

            _presentationModelPrivate.Invoke("ToolButtonEnabledCheck");

            Assert.IsFalse(_presentationModel.IsUndoEnabled);
            Assert.IsTrue(_presentationModel.IsRedoEnabled);
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
                _presentationModel.CanvasDraw(graphics, INIT_DRAW_WIDTH);

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
                _presentationModel.SlideDraw(graphics, INIT_SLIDE_WIDTH);

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