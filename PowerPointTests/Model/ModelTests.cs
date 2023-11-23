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
    public class ModelTests
    {
        const double INIT_LEFT = 1;
        const double INIT_TOP = 300;
        const double INIT_RIGHT = 400;
        const double INIT_BOTTOM = 200;
        Shape _shape;
        Model _model;
        PrivateObject _modelPrivate;

        //測試Model初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line(INIT_LEFT, INIT_TOP, INIT_RIGHT, INIT_BOTTOM);
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
        }

        //測試Model當DataGridView新增按鈕被按下的處理
        [TestMethod()]
        public void AddButtonClickEventTest()
        {
            List<string> testShapeName = new List<string> { ModeType.LINE_NAME, ModeType.CIRCLE_NAME, ModeType.RECTANGLE_NAME };
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            for (int i = 0; i < testShapeName.Count; i++)
            {
                _model.AddButtonClickEvent(testShapeName[i]);
                Assert.IsTrue(shapes.GetCount() == i + 1);
            }
            _model.AddButtonClickEvent("");
            Assert.IsTrue(shapes.GetCount() == testShapeName.Count);
        }

        //測試Model當DataGridView刪除按鈕被按下的處理
        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(-1, 0, 1)]
        [DataRow(0, 1, 1)]
        public void DeleteButtonClickEventTest(int rowIndex, int columnIndex, int expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _model.AddButtonClickEvent(ModeType.LINE_NAME);
            _model.DeleteButtonClickEvent(rowIndex, columnIndex);

            Assert.AreEqual(expected, shapes.GetCount());
        }

        //測試Model滑鼠被按下
        [TestMethod()]
        public void PressPointerTest()
        {
            bool expectedIsPressed = true;
            int expectedPressPointer = 1;
            IStateMock state = new IStateMock();
            _model.PressPointer(state);

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedPressPointer, state.MouseDownCount);
        }

        //測試Model滑鼠移動
        [TestMethod()]
        public void MovePointerTest()
        {
            int expectedMovePointer = 1;
            IStateMock state = new IStateMock();
            _model.MovePointer(state);

            Assert.AreEqual(expectedMovePointer, state.MouseMoveCount);
        }

        //測試Model滑鼠釋放
        [TestMethod()]
        public void ReleasePointerTest()
        {
            int expectedReleasePointer = 1;
            bool expectedIsPressed = false;
            String expectedToolModePressed = "";
            IStateMock state = new IStateMock();

            _model.ReleasePointer(state);

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedToolModePressed, _modelPrivate.GetField("_toolModePressed"));
            Assert.AreEqual(expectedReleasePointer, state.MouseReleaseCount);
        }

        //測試Model鍵盤刪除按下
        [TestMethod()]
        public void PressDeleteTest()
        {
            int expectedPressDelete = 1;
            IStateMock state = new IStateMock();
            _model.PressDelete(state);

            Assert.AreEqual(expectedPressDelete, state.DeletePressCount);
        }

        //測試Model創建即時形狀
        [TestMethod()]
        [DataRow(ModeType.LINE_NAME, typeof(Line))]
        [DataRow(ModeType.CIRCLE_NAME, typeof(Circle))]
        [DataRow(ModeType.RECTANGLE_NAME, typeof(Rectangle))]
        public void CreateHintTest(string shapeName, Type type)
        {
            _modelPrivate.SetField("_toolModePressed", shapeName);
            _model.CreateHint();

            Assert.IsInstanceOfType(_modelPrivate.GetFieldOrProperty("_hint"), type);
        }

        //測試Model創建即時形狀(輸入空字串)
        [TestMethod()]
        public void CreateHintNullTypeTest()
        {
            _modelPrivate.SetField("_toolModePressed", "");
            _model.CreateHint();

            Assert.IsNull(_modelPrivate.GetFieldOrProperty("_hint"));
        }

        //測試Model設定即時形狀位置
        [TestMethod()]
        [DataRow(0, 0, 0, 0)]
        public void SetHintPositionTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            _modelPrivate.SetField("_hint", _shape);
            _modelPrivate.SetField("_isPressed", true);

            _model.SetFirstPoint(firstPointX, firstPointY);
            _model.SetHintPosition(pointX, pointY);

            Assert.AreEqual(firstPointX, _shape.GetPosition()._left);
            Assert.AreEqual(firstPointY, _shape.GetPosition()._top);
            Assert.AreEqual(pointX, _shape.GetPosition()._right);
            Assert.AreEqual(pointY, _shape.GetPosition()._bottom);
        }

        //測試Model設定即時形狀位置(未按下)
        [TestMethod()]
        [DataRow(0, 0, 0, 0)]
        public void SetHintPositionNullPressedTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            _modelPrivate.SetField("_hint", _shape);
            _modelPrivate.SetField("_isPressed", false);

            _model.SetFirstPoint(firstPointX, firstPointY);
            _model.SetHintPosition(pointX, pointY);

            Assert.AreEqual(INIT_LEFT, _shape.GetPosition()._left);
            Assert.AreEqual(INIT_TOP, _shape.GetPosition()._top);
            Assert.AreEqual(INIT_RIGHT, _shape.GetPosition()._right);
            Assert.AreEqual(INIT_BOTTOM, _shape.GetPosition()._bottom);
        }

        //測試Model加入即時形狀
        [TestMethod()]
        public void AddHintTest()
        {
            int expected = 1;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_hint", _shape);
            _modelPrivate.SetField("_isPressed", true);

            _model.AddHint();

            Assert.AreEqual(expected, shapes.GetCount());
            Assert.IsNull(_modelPrivate.GetField("_hint"));
        }

        //測試Model加入即時形狀(未按下)
        [TestMethod()]
        public void AddHintNullPressedTest()
        {
            int expected = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_hint", _shape);
            _modelPrivate.SetField("_isPressed", false);

            _model.AddHint();

            Assert.AreEqual(expected, shapes.GetCount());
            Assert.IsNotNull(_modelPrivate.GetField("_hint"));
        }

        //測試Model設定起始點
        [TestMethod()]
        [DataRow(0, 0)]
        public void SetFirstPointTest(double pointX, double pointY)
        {
            _model.SetFirstPoint(pointX, pointY);

            Assert.AreEqual(pointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(pointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model選擇形狀
        [TestMethod()]
        [DataRow(1, 300, true)]
        [DataRow(400, 200, true)]
        [DataRow(401, 301, false)]
        public void SelectShapeTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            shapes.AddShape(_shape);

            _model.SelectShape(pointX, pointY);

            Assert.AreEqual(expected, selection.ShapeSelect != null);
            Assert.AreEqual(pointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(pointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model移動形狀
        [TestMethod()]
        [DataRow(400, 300, 500, 400)]
        [DataRow(400, 300, 300, 200)]
        public void MoveShapeTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            _modelPrivate.SetField("_isPressed", true);
            shapes.AddShape(_shape);

            _model.SelectShape(firstPointX, firstPointY);
            _model.MoveShape(pointX, pointY);

            Assert.AreEqual(INIT_LEFT + (pointX - firstPointX), selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP + (pointY - firstPointY), selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT + (pointX - firstPointX), selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM + (pointY - firstPointY), selection.ShapeRange._bottom);
            Assert.AreEqual(pointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(pointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model移動形狀(未按下)
        [TestMethod()]
        [DataRow(400, 300, 500, 400)]
        public void MoveShapeNullPressedTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            _modelPrivate.SetField("_isPressed", false);
            shapes.AddShape(_shape);

            _model.SelectShape(firstPointX, firstPointY);
            _model.MoveShape(pointX, pointY);

            Assert.AreEqual(INIT_LEFT, selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP, selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT, selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM, selection.ShapeRange._bottom);
            Assert.AreEqual(firstPointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(firstPointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model停止移動形狀
        [TestMethod()]
        [DataRow(400, 300, 500, 400)]
        public void StopMoveShapeTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            _modelPrivate.SetField("_isPressed", true);
            shapes.AddShape(_shape);

            _model.SelectShape(firstPointX, firstPointY);
            _model.MoveShape(pointX, pointY);
            _model.StopMoveShape();

            Assert.AreEqual(INIT_LEFT + (pointX - firstPointX), selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP + (pointY - firstPointY), selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT + (pointX - firstPointX), selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM + (pointY - firstPointY), selection.ShapeRange._bottom);
            Assert.AreEqual(pointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(pointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model停止移動形狀(未按下)
        [TestMethod()]
        [DataRow(400, 300, 500, 400)]
        public void StopMoveShapeNullPressedTest(double firstPointX, double firstPointY, double pointX, double pointY)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            _modelPrivate.SetField("_isPressed", false);
            shapes.AddShape(_shape);

            _model.SelectShape(firstPointX, firstPointY);
            _model.MoveShape(pointX, pointY);
            _model.StopMoveShape();

            Assert.AreEqual(INIT_LEFT, selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP, selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT, selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM, selection.ShapeRange._bottom);
            Assert.AreEqual(firstPointX, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(firstPointY, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model刪除選取形狀
        [TestMethod()]
        public void DeleteShapeTest()
        {
            int excepted = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            shapes.AddShape(_shape);

            _model.SelectShape(INIT_LEFT, INIT_TOP);
            _model.DeleteShape();

            Assert.AreEqual(excepted, shapes.GetCount());
            Assert.IsNull(selection.ShapeSelect);
        }

        //測試Model繪圖
        [TestMethod()]
        public void DrawTest()
        {
            int expectedClear = 1;
            int expectedLine = 1;
            int expectedCircle = 1;
            int expectedRectangle = 0;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", true);

            shapes.AddShape(_shape);
            _model.SelectShape(INIT_LEFT, INIT_TOP);
            _model.CreateHint();
            _model.Draw(graphics);

            Assert.AreEqual(expectedClear, graphics.ClearAllCount);
            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectangle, graphics.DrawRectangleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }

        //測試Model通知模型改變
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            bool eventRaised = false;
            _model._modelChanged += () => eventRaised = true;

            _modelPrivate.Invoke("NotifyModelChanged");
            Assert.IsTrue(eventRaised);
        }

        //測試Model設定繪圖模式
        [TestMethod()]
        [DataRow(ModeType.LINE_NAME)]
        [DataRow(ModeType.CIRCLE_NAME)]
        [DataRow(ModeType.RECTANGLE_NAME)]
        public void SetToolModeTest(string shapeType)
        {
            _model.SetToolMode(shapeType);

            Assert.AreEqual(shapeType, _modelPrivate.GetField("_toolModePressed"));
        }

        //測試Model設定縮放固定點
        [TestMethod()]
        public void PinScalePointTest()
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            shapes.AddShape(_shape);

            _model.SelectShape(INIT_LEFT, INIT_TOP);
            _model.PinScalePoint();

            Assert.AreEqual(INIT_LEFT, _modelPrivate.GetField("_firstPointX"));
            Assert.AreEqual(INIT_TOP, _modelPrivate.GetField("_firstPointY"));
        }

        //測試Model縮放圖形
        [TestMethod()]
        [DataRow(400, 400)]
        [DataRow(1, 300)]
        public void ScaleShapeTest(double pointX, double pointY)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_isPressed", true);

            _model.SelectShape(INIT_LEFT, INIT_TOP);
            _model.PinScalePoint();
            _model.ScaleShape(pointX, pointY);

            Assert.AreEqual(INIT_LEFT, selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP, selection.ShapeRange._top);
            Assert.AreEqual(pointX, selection.ShapeRange._right);
            Assert.AreEqual(pointY, selection.ShapeRange._bottom);
        }

        //測試Model縮放圖形(未按下)
        [TestMethod()]
        [DataRow(400, 400)]
        [DataRow(1, 300)]
        public void ScaleShapeNullPressedTest(double pointX, double pointY)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;
            Selection selection = _modelPrivate.GetFieldOrProperty("_selection") as Selection;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_isPressed", false);

            _model.SelectShape(INIT_LEFT, INIT_TOP);
            _model.PinScalePoint();
            _model.ScaleShape(pointX, pointY);

            Assert.AreEqual(INIT_LEFT, selection.ShapeRange._left);
            Assert.AreEqual(INIT_TOP, selection.ShapeRange._top);
            Assert.AreEqual(INIT_RIGHT, selection.ShapeRange._right);
            Assert.AreEqual(INIT_BOTTOM, selection.ShapeRange._bottom);
        }

        //測試Model是否在縮放區域
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(400, 300, true)]
        public void IsInScaleAreaTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_isPressed", true);

            _model.SelectShape(INIT_LEFT, INIT_TOP);

            Assert.AreEqual(expected, _model.IsInScaleArea(pointX, pointY));
        }

        //測試Model取得binding List
        [TestMethod()]
        public void GetShapeListTest()
        {
            Assert.IsNotNull(_model.ShapeList);
        }
    }
}