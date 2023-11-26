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
            _modelPrivate.SetField("_state", state);

            _model.PressPointer();

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedPressPointer, state.MouseDownCount);
        }

        //測試Model滑鼠移動
        [TestMethod()]
        public void MovePointerTest()
        {
            int expectedMovePointer = 1;
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", true);

            _model.MovePointer(0, 0);

            Assert.AreEqual(expectedMovePointer, state.MouseMoveCount);
        }

        //測試Model滑鼠移動(未按下)
        [TestMethod()]
        public void MovePointerNullPressTest()
        {
            int expectedMovePointer = 0;
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", false);

            _model.MovePointer(0, 0);

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
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", true);

            _model.ReleasePointer();

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedToolModePressed, _modelPrivate.GetField("_toolModePressed"));
            Assert.AreEqual(expectedReleasePointer, state.MouseReleaseCount);
        }

        //測試Model滑鼠釋放(未按下)
        [TestMethod()]
        public void ReleasePointerNullPressTest()
        {
            int expectedReleasePointer = 0;
            bool expectedIsPressed = false;
            String expectedToolModePressed = "";
            IStateMock state = new IStateMock();
            _modelPrivate.SetField("_state", state);
            _modelPrivate.SetField("_isPressed", false);

            _model.ReleasePointer();

            Assert.AreEqual(expectedIsPressed, _modelPrivate.GetField("_isPressed"));
            Assert.AreEqual(expectedToolModePressed, _modelPrivate.GetField("_toolModePressed"));
            Assert.AreEqual(expectedReleasePointer, state.MouseReleaseCount);
        }

        //測試Model鍵盤刪除按下
        [TestMethod()]
        public void PressDeleteTest()
        {
            int expected = 0;
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);

            _modelPrivate.SetField("_selection", _shape);
            _model.PressDelete();

            Assert.AreEqual(expected, shapes.GetCount());
            Assert.IsNull(_modelPrivate.GetField("_selection"));
        }

        //測試Model改變操作模式(縮放模式)
        [TestMethod()]
        public void ChangeStateScaleTest()
        {
            _modelPrivate.SetField("_selection", _shape);
            _modelPrivate.SetField("_isInScaleArea", true);
            _model.ChangeState(0, 0);

            IState state = _modelPrivate.GetField("_state") as IState;

            Assert.IsNotNull(state);
        }

        //測試Model改變操作模式(圖形模式)
        [TestMethod()]
        public void ChangeStateToolTest()
        {
            _modelPrivate.SetField("_selection", _shape);
            _modelPrivate.SetField("_toolModePressed", ModeType.LINE_NAME);
            _model.ChangeState(0, 0);

            IState state = _modelPrivate.GetField("_state") as IState;
            Shape hint = _modelPrivate.GetField("_hint") as Shape;

            Assert.IsNotNull(state);
            Assert.IsNotNull(hint);
        }

        //測試Model改變操作模式(選取模式)
        [TestMethod()]
        public void ChangeStateSelectTest()
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_selection", _shape);
            _modelPrivate.SetField("_toolModePressed", ModeType.SELECT_NAME);
            _model.ChangeState(INIT_LEFT, INIT_TOP);

            IState state = _modelPrivate.GetField("_state") as IState;
            Shape selection = _modelPrivate.GetField("_selection") as Shape;

            Assert.IsNotNull(state);
            Assert.IsNotNull(selection);
        }

        //測試Model選取圖形
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(INIT_LEFT, INIT_TOP, true)]
        public void SelectShapeTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _shape.SetIsSelect(true);
            _modelPrivate.SetField("_selection", _shape);
            
            shapes.AddShape(_shape);
            _model.SelectShape(pointX, pointY);

            Shape selection = _modelPrivate.GetField("_selection") as Shape;

            Assert.AreEqual(expected, selection != null);
            Assert.AreEqual(false, _shape.IsSelect());
        }

        //測試Model選取圖形(已選取)
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(INIT_LEFT, INIT_TOP, true)]
        public void SelectShapeHadSelectTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;


            shapes.AddShape(_shape);
            _model.SelectShape(pointX, pointY);

            Shape selection = _modelPrivate.GetField("_selection") as Shape;

            Assert.AreEqual(expected, selection != null);
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
            Shape hint = Factory.CreateShape(ModeType.CIRCLE_NAME);
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", true);

            shapes.AddShape(_shape);
            _shape.SetIsSelect(true);
            _modelPrivate.SetField("_hint", hint);

            _model.Draw(graphics);

            Assert.AreEqual(expectedClear, graphics.ClearAllCount);
            Assert.AreEqual(expectedLine, graphics.DrawLineCount);
            Assert.AreEqual(expectedCircle, graphics.DrawCircleCount);
            Assert.AreEqual(expectedRectangle, graphics.DrawRectangleCount);
            Assert.AreEqual(expectedDot, graphics.DrawDotCount);
        }

        //測試Model繪圖(無即時形狀)
        [TestMethod()]
        public void DrawTestNoHint()
        {
            int expectedClear = 1;
            int expectedLine = 1;
            int expectedCircle = 0;
            int expectedRectangle = 0;
            int expectedDot = 8;
            IGraphicsMock graphics = new IGraphicsMock();
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            _modelPrivate.SetField("_toolModePressed", ModeType.CIRCLE_NAME);
            _modelPrivate.SetField("_isPressed", false);

            shapes.AddShape(_shape);
            _shape.SetIsSelect(true);

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

        //測試Model是否在縮放區域
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(400, 300, true)]
        public void IsInScaleAreaTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_selection", _shape);

            _model.IsInScaleArea(pointX, pointY);

            Assert.AreEqual(expected, _modelPrivate.GetField("_isInScaleArea"));
        }

        //測試Model是否在縮放區域(無選取)
        [TestMethod()]
        [DataRow(0, 0, false)]
        [DataRow(400, 300, false)]
        public void IsInScaleAreaNullSelectTest(double pointX, double pointY, bool expected)
        {
            Shapes shapes = _modelPrivate.GetFieldOrProperty("_shapes") as Shapes;

            shapes.AddShape(_shape);
            _modelPrivate.SetField("_selection", null);

            _model.IsInScaleArea(pointX, pointY);

            Assert.AreEqual(expected, _modelPrivate.GetField("_isInScaleArea"));
        }

        //測試Model取得binding List
        [TestMethod()]
        public void GetShapeListTest()
        {
            Assert.IsNotNull(_model.ShapeList);
        }
    }
}